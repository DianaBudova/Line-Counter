using LineCounter.Services;

namespace LineCounter.Models
{
    public class FileItem
    {
        private string path;
        private string type;
        private long size;

        public FileItem(string path)
        {
            this.path = path;
            type = System.IO.Path.GetExtension(path);
            size = new FileInfo(path).Length;
        }

        public FileItem(string path, string type, long size)
        {
            this.path = path;
            this.type = type;
            this.size = size;
        }

        public static int CountLines(FileItem? item)
        {
            if (item == null)
                throw new Exception("Item is null");

            if (!File.Exists(item.Path))
                throw new Exception("Path in item does not exist");

            if (!SupportedTypes.IsSupported(item.Type))
                throw new Exception("Type in item is not supported");

            return File.ReadAllLines(item.Path).Length;
        }

        public string Path => path;
        public string Type => type;
        public long Size => size;
    }
}
