using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Logger
{
    public class LoggerFile : ILogger
    {
        public LoggerFile()
        {
            Directory.CreateDirectory(_path);
            _fileLog = CreateNameFile(_path);
        }

        #region PrivateField
        private readonly List<string> _logs = new List<string>();
        private readonly string _path = "Log";
        private readonly string _fileLog;
        private object _lock = new object();
        #endregion PrivateField

        #region PrivateMethod
        private string CreateNameFile(string path)
        {
            var fileName = $"{DateTime.Now:yyyy_MM_dd}_log.txt";

            return Path.Combine(path, fileName);

        }
        #endregion PrivateMethod

        #region PublicMethod
        public void AddLog(string message)
        {
            var mes = $"{DateTime.Now} - {message}";
            lock (_lock)
            {
                try
                {
                    File.AppendAllLines(_fileLog, new string[] { mes });
                    _logs.Add(mes);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        public IEnumerable<string> GetLogs()
        {
            return _logs;
        }
        #endregion PublicMethod
    }
}