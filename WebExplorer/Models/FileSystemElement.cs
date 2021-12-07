using System;

namespace WebExplorer.Models
{
    public class FileSystemElement
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public FileSystemElementType Type { get; set; }
        public long? Size { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        
        public FileSystemElement(string name, string path, FileSystemElementType type, long? size = null, DateTime? creationTime = null, DateTime? modificationTime = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Type = type;
            Size = size;
            CreationTime = creationTime;
            ModificationTime = modificationTime;
        }
    }
}