namespace WKH.GlobalIdentifiers
{
    public class RemoteEnvConfigEntity : EnvConfigEntity
    {
        public string OS { get; set; }
        public string OSVersion { get; set; }
        public string Key { get; set; }
        public string User { get; set; }
        public string TestId { get; set; }

        public RemoteEnvConfigEntity() : base()
        {
            OS = "Windows";
            OSVersion = "7";
            Key = null;
            User = null;
            TestId = null;
        }
    }
}
