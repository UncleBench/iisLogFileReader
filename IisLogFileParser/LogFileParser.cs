using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IisLogFileParser
{
    public class LogFileParser : ILogFileParser
    {
        public async Task<List<LogEntry>> Parse(FileInfo fileInfo)
        {
            var content = await ReadAllTextAsync(fileInfo.FullName);
            var lines = content
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var logEntries = new List<LogEntry>();

            foreach (var line in lines)
            {
                if (!line.StartsWith("#"))
                {
                    string[] entries = line.Split(' ');

                    var entry = new LogEntry();
                    entry.ClientIp = entries[8];

                    var queryString = (entries[5] != "-") ? "?" + entries[5] : string.Empty;
                    entry.FqdnOfClientIp = entries[3] + " " + entries[2] + ":" + entries[6] + entries[4] + queryString;
                    logEntries.Add(entry);
                }
            }

            var filteredLogEntries = logEntries.GroupBy(x => new { x.ClientIp, x.FqdnOfClientIp })
                .Select(x => new LogEntry
                {
                    ClientIp = x.Key.ClientIp,
                    FqdnOfClientIp = x.Key.FqdnOfClientIp,
                    TotalCallsPerClientIp = x.Count(),
                }).ToList();

            return filteredLogEntries;
        }

        private static async Task<string> ReadAllTextAsync(string filePath)
        {
            var stringBuilder = new StringBuilder();
            using var fileStream = File.OpenRead(filePath);
            using var streamReader = new StreamReader(fileStream);
            string line = await streamReader.ReadLineAsync();

            while (line != null)
            {
                stringBuilder.AppendLine(line);
                line = await streamReader.ReadLineAsync();
            }

            return stringBuilder.ToString();
        }
    }
}
