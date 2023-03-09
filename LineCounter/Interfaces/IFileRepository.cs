using LineCounter.Collections;
using LineCounter.Models;

namespace LineCounter.Interfaces
{
    public interface IFileRepository
    {
        public FileCollection Collection { get; }

        public void AddItem(FileItem? item);

        public void ClearAll();
    }
}
