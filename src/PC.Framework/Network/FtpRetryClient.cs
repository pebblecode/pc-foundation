using System;
using System.IO;
using System.Threading;
using PebbleCode.Framework.Configuration;
using Starksoft.Net.Ftp;
using PebbleCode.Framework.Logging;

namespace PebbleCode.Framework.Network
{
    /// <summary>
    /// A wrapper for the starksoft FTP client object.  Provides retry capability
    /// for establishing a connection and wraps the connection with teh disposable pattern.
    /// 
    /// Also provides locking to prevent multiple connections being established at once.
    /// </summary>
    public class FtpRetryClient : IDisposable
    {
        private static readonly AutoResetEvent _ftpConnectionSync = new AutoResetEvent(true);
        private readonly static TimeSpan _connectionOpenWait = TimeSpan.FromSeconds(15);
        private readonly string _username;
        private readonly string _password;
        private readonly FtpClient _connection;

        /// <summary>
        /// Blocks the caller until the FTP connection is available, and ensures that
        /// the connection is open
        /// </summary>
        public FtpRetryClient(string host, 
            int portNumber, 
            string username,
            string password,
            FtpSecurityProtocol securityProtocol = FtpSecurityProtocol.None)
        {
            _username = username;
            _password = password;

            try
            {
                //Get the lock 
                _ftpConnectionSync.WaitOne();
                _connection = new FtpClient(host, portNumber, securityProtocol);
            }
            catch (Exception ex)
            {
                Exception ex2 = Logger.WriteUnexpectedException(ex, "Failed to open connection to bloomberg", Category.Ftp);

                //If we fail to open a connection, don't prevent other threads from trying to do so.
                _ftpConnectionSync.Set();

                throw ex2;
            }
        }

        /// <summary>
        /// Encapsulates a retry loop attempting to open a connection to Bloomberg
        /// </summary>
        private void OpenFtpConnectionIfClosed()
        {
            int connectionRetries = FtpSettings.ConnectionRetries;

            while (!_connection.IsConnected && connectionRetries > 0)
            {
                try
                {
                    _connection.Open(_username, _password);
                    Logger.WriteDebug("Connected to server: {0}".fmt(_connection.Host), Category.Ftp);
                }
                catch (Exception ex)
                {
                    Logger.WriteUnexpectedException(ex,
                        "Failed to open FTP connection.",
                        Category.Ftp);

                    //Do we have retries remaining?
                    if (connectionRetries > 0)
                    {
                        connectionRetries--;
                        Logger.WriteDebug("{0} tries remaining.  Retrying in {1}".fmt(connectionRetries, _connectionOpenWait), Category.Ftp);
                        Thread.Sleep(_connectionOpenWait);
                    }
                    else
                    {
                        //Fail the operation
                        throw new Exception("Failed to open ftp connection to " + _connection.Host, ex);
                    }
                }
            }
        }

        /// <summary>
        /// Put file to a remote ftp location
        /// </summary>
        /// <param name="inputStream"></param>
        /// <param name="remotePath"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool PutFile(Stream inputStream, string remotePath, FileAction action)
        {
            return DoAction(
                () =>
                    {
                        _connection.PutFile(inputStream, remotePath, action);
                        return true;
                    },
                "PutFile");
        }

        /// <summary>
        /// Get remote FTP file
        /// </summary>
        /// <param name="remotePath"></param>
        /// <param name="localPath"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool GetFile(string remotePath, string localPath, FileAction action)
        {
            return DoAction(
                () =>
                    {
                        _connection.GetFile(remotePath, localPath, action);
                        return true;
                    },
                "GetFile");
        }

        /// <summary>
        /// Checking a given path is exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Exists(string path)
        {
            return DoAction(() => _connection.Exists(path), "check file exist");
        }

        /// <summary>
        /// FTP action with retries
        /// </summary>
        /// <param name="action"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        private bool DoAction(Func<bool> action, string actionName)
        {
            int actionRetries = FtpSettings.ActionRetries;
            do
            {
                //this never throws an exception
                OpenFtpConnectionIfClosed();
                try
                {    
                    return action();
                }
                catch (Exception ex)
                {
                    Logger.WriteUnexpectedException(ex, "Failed to {0}.".fmt(actionName), Category.Ftp);
                    actionRetries--;
                }
            } while (actionRetries > 0);
            return false;
        }

        /// <summary>
        /// Releases the lock on the FTP connection
        /// </summary>
        public void Dispose()
        {
            try
            {
                _connection.Close();
                _connection.Dispose();
            }
            catch
            {
            }
            finally
            {
                _ftpConnectionSync.Set();
            }
        }
    }
}
