namespace LineCounter.Services
{
    public static class SupportedTypes
    {
        public static string[] Types { get; }

        static SupportedTypes()
        {
            Types = new[]
            {
                ".cpp",
                ".cs",
                ".csproj",
                ".h",
                ".json",
                ".txt",
                ".xml",
            };
        }

        public static bool IsSupported(string? type)
        {
            if (type == null || type.Length == 0)
                return false;

            foreach (string t in Types)
            {
                if (t == type)
                    return true;
            }
            return false;
        }
    }
}
