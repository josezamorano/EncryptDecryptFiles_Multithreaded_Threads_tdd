namespace FileEncryptDecrypt.Utils.Interfaces
{
    public interface IDirectoryProvider
    {
        string[] GetAllFiles(string fullDirectoryPath);

        string[] GetAllDirectories(string fullDirectoryPath);

        bool DirectoryExists(string fullDirectoryPath);

        DirectoryInfo CreateDirectoryInPath(string fullDirectoryPath);
    }
}
