using System.Diagnostics.CodeAnalysis;
using LineCounter.Models;

namespace LineCounter.Services
{
    public class FileEqualityComparer : IEqualityComparer<FileItem>
    {
        public bool Equals(FileItem? x, FileItem? y)
        {
            if (x.Path == y.Path)
                if (x.Type == y.Type)
                    if (x.Size == y.Size)
                        return true;
            return false;
        }

        public int GetHashCode([DisallowNull] FileItem obj)
        {
            return (int)(obj.Type.Length + obj.Size * 0.5);
        }
    }
}
