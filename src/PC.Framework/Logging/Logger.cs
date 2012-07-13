using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;

using ELAB = Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;

using PebbleCode.Collections;

namespace PebbleCode.Framework.Logging
{
    /// <summary>
    /// Central class for all log messages to pass through. Abstracts out the use of ELAB
    /// </summary>
    public static class Logger
    {
        private const TraceEventType ERROR = TraceEventType.Error;
        private const TraceEventType WARNING = TraceEventType.Warning;
        private const TraceEventType DEBUG = TraceEventType.Verbose;
        private const TraceEventType INFO = TraceEventType.Information;

        private static Dictionary<string, bool> _shouldLogInfo = new Dictionary<string, bool>();
        private static Dictionary<string, bool> _shouldLogDebug = new Dictionary<string, bool>();
        private static Dictionary<string, bool> _shouldLogWarning = new Dictionary<string, bool>();
        private static Dictionary<string, bool> _shouldLogError = new Dictionary<string, bool>();

        public static int ErrorCount { get; private set; }
        public static bool ErrorsWrittenToLog { get { return ErrorCount > 0; } }
        public static int WarningCount { get; private set; }
        public static bool WarningsWrittenToLog { get { return WarningCount > 0; } }

#if DEBUG
        public const int LATEST_LOGS_QUEUE_SIZE = 100;
#else
        public const int LATEST_LOGS_QUEUE_SIZE = 5;
#endif
        private static FifoBuffer<ELAB.LogEntry> _latestLogs = new FifoBuffer<ELAB.LogEntry>(LATEST_LOGS_QUEUE_SIZE);
        public static FifoBuffer<ELAB.LogEntry> LatestLogs { get { return _latestLogs; } }

        /// <summary>
        /// Check if a particular category should be logged
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool ShouldLogInfo(string category)
        {
            return ShouldLog(category, INFO, _shouldLogInfo);
        }

        /// <summary>
        /// Check if a particular category should be logged
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool ShouldLogDebug(string category)
        {
            return ShouldLog(category, DEBUG, _shouldLogDebug);
        }

        /// <summary>
        /// Check if a particular category should be logged
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool ShouldLogWarning(string category)
        {
            return ShouldLog(category, WARNING, _shouldLogWarning);
        }

        /// <summary>
        /// Check if a particular category should be logged
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool ShouldLogError(string category)
        {
            return ShouldLog(category, ERROR, _shouldLogError);
        }

        /// <summary>
        /// Internal method to check should log
        /// </summary>
        /// <param name="category"></param>
        /// <param name="severity"></param>
        /// <returns></returns>
        private static bool ShouldLog(string category, TraceEventType severity, Dictionary<string, bool> answerCache)
        {
            try
            {
                // No need to worry about locking.
                // Although all methods are static, we only ever ADD to the cache. If we set the value
                // of a particular entry twice, then so be it. It doesn't matter.

                // Check cache.
                if (answerCache.ContainsKey(category))
                    return answerCache[category];

                // Find out and answer
                ELAB.LogEntry logEntry = new ELAB.LogEntry();
                logEntry.Categories.Add(category.ToString());
                logEntry.Severity = severity;
                bool answer = ELAB.Logger.ShouldLog(logEntry);

                // Cache answer
                answerCache[category] = answer;

                // And return it
                return answer;
            }
            catch (Exception e)
            {
                DumpException(e);
                return false;
            }
        }

        /// <summary>
        /// Log an unexpected exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="additionalMessage"></param>
        /// <param name="category"></param>
        public static Exception WriteUnexpectedException(Exception exception, string additionalMessage, string category)
        {
            try
            {
                WriteException(exception, additionalMessage, category, TraceEventType.Error);
                if (exception != null)
                {
                    while (exception.InnerException != null)
                    {
                        exception = exception.InnerException;
                        WriteException(exception, "Inner Exception", category, TraceEventType.Error);
                    }
                }
            }
            catch (Exception e)
            {
                DumpException(e);
            }
            finally
            {
                ErrorCount += 1;
            }
            return new Exception(additionalMessage, exception);
        }

        /// <summary>
        /// Internal helper to format and write exceptions
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="additionalMessage"></param>
        /// <param name="category"></param>
        /// <param name="level"></param>
        private static void WriteException(Exception exception, string additionalMessage, string category, TraceEventType level)
        {
            if (exception == null)
                return;

            // Build message.
            StringBuilder message = new StringBuilder();
            message.AppendLine(exception.Message);

            // Add other basic info
            message.Append("  Type: ").AppendLine(exception.GetType().Name);
            if (!string.IsNullOrEmpty(additionalMessage))
                message.Append("  Additional: ").AppendLine(additionalMessage);
            message.AppendLine("  Stack Trace: ");
            message.Append(exception.StackTrace);

            // Log
            WriteToEalbLogger(message.ToString(), category, level);
        }

        /// <summary>
        /// Write an error message to the log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        [DebuggerStepThrough]
        public static Exception WriteError(string message, string category, params object[] args)
        {
            try
            {
                FormatMessage(ref message, args);
                WriteToEalbLogger(message, category, ERROR);
                ErrorCount += 1;

                return new Exception(message);
            }
            catch (Exception e)
            {
                DumpException(e);
                return null;
            }
        }

        /// <summary>
        /// Write a warning message to the log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        [DebuggerStepThrough]
        public static void WriteWarning(string message, string category, params object[] args)
        {
            try
            {
                FormatMessage(ref message, args);
                WriteToEalbLogger(message, category, WARNING);
                WarningCount += 1;
            }
            catch (Exception e)
            {
                DumpException(e);
            }
        }

        /// <summary>
        /// Write a normal message to the log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        [DebuggerStepThrough]
        public static void WriteInfo(string message, string category, params object[] args)
        {
            try
            {
                FormatMessage(ref message, args);
                WriteToEalbLogger(message, category, INFO);
            }
            catch (Exception e)
            {
                DumpException(e);
            }
        }

        /// <summary>
        /// Write a normal message to the log
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        [DebuggerStepThrough]
        public static void WriteDebug(string message, string category, params object[] args)
        {
            try
            {
                FormatMessage(ref message, args);
                WriteToEalbLogger(message, category, DEBUG);
            }
            catch (Exception e)
            {
                DumpException(e);
            }
        }

        /// <summary>
        /// Reset the flag used to record whether errors have been written
        /// </summary>
        [DebuggerStepThrough]
        public static void ResetErrorFlags()
        {
            ErrorCount = 0;
            WarningCount = 0;
        } 

        /// <summary>
        /// Utility method to format a message string if format arguments are specified.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        [DebuggerStepThrough]
        private static void FormatMessage(ref string message, object[] args)
        {
            try
            {
                if (args != null && args.Length > 0)
                {
                    message = string.Format(message, args);
                }
            }
            catch
            {
                //Don't bring application crashing down just because an obscure error message has wrong number of formatting arguments
                WriteError("Incorrectly formatted log message at {0}", Category.General, (new StackTrace()).ToString());
            }
        }

        /// <summary>
        /// Internal method to do ALL logging. ALL logs come through this method.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        /// <param name="level"></param>
        [DebuggerStepThrough]
        private static void WriteToEalbLogger(string message, string category, TraceEventType level)
        {
            if (level == TraceEventType.Error)
                category = Category.GeneralError;

            ELAB.LogEntry logEntry = new ELAB.LogEntry();
            logEntry.Categories.Add(category.ToString());
            logEntry.Message = message;
            logEntry.Priority = 1;
            logEntry.Severity = level;
            _latestLogs.Add(logEntry);
            ELAB.Logger.Write(logEntry);
        }

        /// <summary>
        /// Dump an exception out to last resort log. Do not throw exceptions out of here.
        /// </summary>
        /// <param name="e"></param>
        private static void DumpException(Exception e)
        {
            try
            {
                string exDumpFile = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "exceptionDump.txt");
                ExceptionDump.Dump(e, "LoggingError", exDumpFile);
            }
            catch(Exception)
            {
                // Argh! This is really bad news. Nothing we can do now.
                // Simply ignore it.
            }
        }
    }
}
