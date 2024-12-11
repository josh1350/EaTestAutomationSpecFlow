namespace EaFramework.Config
{
    public class TestSettings
    {
        public string[] Args { get; set; } = null!;

        public string ApplicationUrl { get; set; } = null!;

        public float Timeout { get; set; }
        public bool Headless { get; set; }

        public bool DevTools { get; set; }

        public float SlowMo { get; set; }

        public DriverType DriverType { get; set; }
    }


    public enum DriverType
    {
        Chromium,
        Firefox,
        Edge,
        Chrome,
        WebKit
    }
}