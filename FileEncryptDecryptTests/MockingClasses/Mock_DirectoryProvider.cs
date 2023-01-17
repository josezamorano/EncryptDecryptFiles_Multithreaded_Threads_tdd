using FileEncryptDecrypt.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptDecryptTests.MockingClasses
{
    public class Mock_DirectoryProvider : IDirectoryProvider
    {
        public DirectoryInfo CreateDirectoryInPath(string fullDirectoryPath)
        {
            var dir = new DirectoryInfo(fullDirectoryPath);
            return dir;
        }

        public bool DirectoryExists(string fullDirectoryPath)
        {
            return true;
        }

        public string[] GetAllDirectories(string fullDirectoryPath)
        {
            string[] noFiles = new string[0];
            return noFiles;
        }

        public string[] GetAllFiles(string fullDirectoryPath)
        {
            string[] allFiles = new string[2] {"file1.txt","file2.txt" };
            return allFiles;
        }
    }
}
