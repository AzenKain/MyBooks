using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Utils
{
    public static class FS
    {
        public static void AddDirectoryToZip(ZipArchive zip, string sourceDir, string entryName)
        {
            foreach (var file in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
            {
                var relativePath = Path.GetRelativePath(sourceDir, file);
                var zipEntryPath = Path.Combine(entryName, relativePath).Replace("\\", "/");
                zip.CreateEntryFromFile(file, zipEntryPath, CompressionLevel.Optimal);
            }
        }

        public static void CopyDirectory(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var name = Path.GetFileName(file);
                var dest = Path.Combine(targetDir, name);
                File.Copy(file, dest, true);
            }

            foreach (var dir in Directory.GetDirectories(sourceDir))
            {
                var name = Path.GetFileName(dir);
                var dest = Path.Combine(targetDir, name);
                CopyDirectory(dir, dest);
            }
        }
    }
}
