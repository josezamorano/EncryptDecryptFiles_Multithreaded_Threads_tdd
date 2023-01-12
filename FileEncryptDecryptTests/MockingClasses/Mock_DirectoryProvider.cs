using FileEncryptDecrypt.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptDecryptTests.MockingClasses
{
    public class Mock_DirectoryProvider : IDirectoryProvider
    {
        public DirectoryInfo CreateDirectoryInPath(string fullDirectoryPath)
        {
            throw new NotImplementedException();
        }

        public bool DirectoryExists(string fullDirectoryPath)
        {
            throw new NotImplementedException();
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
