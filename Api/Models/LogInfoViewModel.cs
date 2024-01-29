using IisLogFileParser;
using System.Collections.Generic;

namespace Api.Models
{
  public class LogInfoViewModel
    {
        public List<LogEntry> LogEntries { get; set; }
    }
}
