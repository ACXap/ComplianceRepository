using System.Collections.Generic;

namespace Logger
{
    public interface ILogger
    {
        void AddLog(string message);
        IEnumerable<string> GetLogs();
    }
}