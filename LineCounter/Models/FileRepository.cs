using LineCounter.Interfaces;
using LineCounter.Services;
using LineCounter.Collections;

namespace LineCounter.Models
{
    public class FileRepository : IFileRepository
    {
        private FileCollection collection;

        public FileRepository()
        {
            collection = new();
        }

        public void AddItem(FileItem? item)
        {
            if (item == null)
                throw new Exception("Item is null");

            if (!File.Exists(item.Path))
                throw new Exception("Path in item does not exist");

            if (!SupportedTypes.IsSupported(item.Type))
                throw new Exception("Type in item is not supported");

            if (collection.Items.Contains(item, new FileEqualityComparer()))
                throw new Exception("Item is already exists");

            collection.Items.Add(item);
        }

        public void ClearAll()
        {
            collection.Items.Clear();
        }

        public FileCollection Collection => collection;
    }
}
