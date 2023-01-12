using FileEncryptDecrypt.Utils.Interfaces;

namespace FileEncryptDecrypt.DataAccessLayer.IOFiles
{
    public class DirectoryProvider : IDirectoryProvider
    {

        public string[] GetAllFiles(string fullDirectoryPath)
        {
            return Directory.GetFiles(fullDirectoryPath);
        }

        public string[] GetAllDirectories(string fullDirectoryPath)
        {
            return Directory.GetDirectories(fullDirectoryPath);
        }

        public bool DirectoryExists(string fullDirectoryPath)
        {
            return System.IO.Directory.Exists(fullDirectoryPath);
        }

        public DirectoryInfo CreateDirectoryInPath(string fullDirectoryPath)
        {
            return System.IO.Directory.CreateDirectory(fullDirectoryPath);
        }
    }
}
