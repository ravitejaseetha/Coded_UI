namespace WKH.GlobalIdentifiers
{
    public class EnvConfigEntity :  BaseEntity
    {
        public EnvConfigEntity()
        {
            URL = null;
            Browser = "Firefox";
        }
        public string URL { get; set; }
        public string Browser { get; set; }
    }
}
