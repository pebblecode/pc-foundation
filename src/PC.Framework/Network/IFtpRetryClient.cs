using System.IO;
using Starksoft.Net.Ftp;

namespace PebbleCode.Framework.Network
{
    public interface IFtpRetryClient
    {
        bool PutFile(Stream inputStream, string remotePath, FileAction action);
        bool GetFile(string remotePath, string localPath, FileAction action);
        bool Exists(string path);
    }
}
