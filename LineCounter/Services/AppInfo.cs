namespace LineCounter.Services
{
    public static class AppInfo
    {
        public static string Version { get; }

        public static string Developer { get; }

        static AppInfo()
        {
            Version = "1.0.0";
            Developer = "Diana Budova";
        }
    }
}
