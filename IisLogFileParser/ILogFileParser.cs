using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IisLogFileParser
{
    public interface ILogFileParser
    {
        public Task<List<LogEntry>> Parse(FileInfo filename);
    }
}
