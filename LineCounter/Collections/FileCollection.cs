using LineCounter.Models;

namespace LineCounter.Collections
{
    public class FileCollection
    {
        private List<FileItem> items;

        public FileCollection()
        {
            items = new List<FileItem>();
        }

        public List<FileItem> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
