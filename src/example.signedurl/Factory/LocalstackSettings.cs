namespace example.signedurl.Factory
{
    public class LocalstackSettings
    {
        public string ServiceUrl => $"http://{ProxyHostname}:{ProxyPort}/";
        public string ProxyHostname { get; set; } = "localhost";
        public int ProxyPort { get; set; } = 4572;
        public string Bucket { get; set; } = "mybucket";
        public string DashboardGraphUrl { get; set; } = "http://localhost:8080/graph";
    }
}