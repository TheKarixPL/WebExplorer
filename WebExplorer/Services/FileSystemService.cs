using System;
using System.IO;
using System.Linq;
using WebExplorer.Models;

namespace WebExplorer.Services
{
    public class FileSystemService
    {
        private readonly IServiceProvider _provider;

        public FileSystemService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public FileSystemElement[] ListDirectory(string directory)
        {
            if (directory == null) throw new ArgumentNullException(nameof(directory));

            var files = Directory.GetFiles(directory).Select(f => new FileSystemElement(new FileInfo(f).Name,
                f,
                FileSystemElementType.File,
                new FileInfo(f).Length,
                File.GetCreationTime(f),
                File.GetLastWriteTime(f))).OrderBy(f => f.Name);
            var directories = Directory.GetDirectories(directory).Select(d => new FileSystemElement(new DirectoryInfo(d).Name,
                d,
                FileSystemElementType.Directory,
                null,
                Directory.GetCreationTime(d),
                Directory.GetLastWriteTime(d))).OrderBy(d => d.Name);

            return directories.Concat(files).ToArray();
        }
    }
}