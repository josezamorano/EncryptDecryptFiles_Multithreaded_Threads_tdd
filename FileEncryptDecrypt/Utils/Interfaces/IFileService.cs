using FileEncryptDecrypt.Services.Enumerations;

namespace FileEncryptDecrypt.Utils.Interfaces
{
    public interface IFileService
    {
        List<string> GetAllFilesInDirectory(string directory);
        
        string CreateCipherFileName(string originalDirectory, string fullPathOriginalFile, CipherState cipherState);

        string RemoveCipherSuffix(string fullPathFileName);

        string CreateCipherFolderName(string originalDirectory, CipherState cipherState);
    }
}
