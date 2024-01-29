namespace IisLogFileParser
{
    public class LogEntry
    {
        public string ClientIp { get; set; }
        public string FqdnOfClientIp { get; set; }
        public int TotalCallsPerClientIp { get; set; }
    }
}
