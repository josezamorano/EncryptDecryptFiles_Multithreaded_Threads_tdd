using FileEncryptDecrypt.Services.Enumerations;
using FileEncryptDecrypt.Services.Messages;
using FileEncryptDecrypt.Utils.Interfaces;

namespace FileEncryptDecrypt.DataAccessLayer.IOFiles
{
    public class FileService : IFileService
    {
        IDirectoryProvider _directoryProvider;
        private string? ENCRYPTED;
        private string? DECRYPTED;
        public FileService(IDirectoryProvider directoryProvider) 
        {
            ENCRYPTED = Enum.GetName(typeof(CipherState), CipherState.Encrypted);
            DECRYPTED = Enum.GetName(typeof(CipherState), CipherState.Decrypted);
            _directoryProvider = directoryProvider;


        }

        //Test
        public List<string> GetAllFilesInDirectory(string directory)
        {            
            List<string> files = new List<string>();
            try
            {
                foreach (string file in _directoryProvider.GetAllFiles(directory))
                {
                    files.Add(file);
                }
                foreach (string dir in _directoryProvider.GetAllDirectories(directory))
                {
                    files.AddRange(GetAllFilesInDirectory(dir));
                }
            }
            catch (Exception ex)
            {
                files.Add(ex.Message);
            }

            return files;            
        }
               
        public string CreateCipherFileName(string originalDirectory, string fullPathOriginalFile, CipherState cipherState)
        {
            string outputDirectory = CreateCipherFolderName(originalDirectory , cipherState);
            string newPathFile = fullPathOriginalFile.Replace(originalDirectory, outputDirectory);
            string cleanNewPathFile = RemoveCipherSuffix(newPathFile);

            string newPathCipherFile = cleanNewPathFile + Notification.UNDERSCORE_CHARACTER + Enum.GetName(typeof(CipherState), cipherState);
            ResolveCreateDirectoryIfNoExists(newPathCipherFile);
            return newPathCipherFile;
        }

        public string RemoveCipherSuffix(string fullPathFileName)
        {
            if (String.IsNullOrEmpty(fullPathFileName))
            {
                throw new ArgumentException("Input path is invalid", "fullPathFileName");
            }

            int initialEncryptionPathIndex = (fullPathFileName.Length - ENCRYPTED.Length) > 0 ? (fullPathFileName.Length - ENCRYPTED.Length) : 0;
            int initialDecryptionPathIndex = (fullPathFileName.Length - DECRYPTED.Length) > 0 ? (fullPathFileName.Length - DECRYPTED.Length) : 0;
            int safeEncryptedPathLength = (fullPathFileName.Length - ENCRYPTED.Length) > 0 ? ENCRYPTED.Length : fullPathFileName.Length;
            int safeDecryptedPathLength = (fullPathFileName.Length - DECRYPTED.Length) > 0 ? DECRYPTED.Length : fullPathFileName.Length;

            string expectedEncryptedWord = fullPathFileName.Substring(initialEncryptionPathIndex, safeEncryptedPathLength);
            string expectedDecryptedWord = fullPathFileName.Substring(initialDecryptionPathIndex, safeDecryptedPathLength);

            if (expectedEncryptedWord == ENCRYPTED || expectedDecryptedWord == DECRYPTED)
            {
                int index = fullPathFileName.LastIndexOf('_');

                if (index != -1)
                {
                    string result = fullPathFileName.Substring(0, index);
                    return result;
                }
            }
            return fullPathFileName;
        }

        public string CreateCipherFolderName(string originalDirectory, CipherState cipherState)
        {
            string cleanOriginalDirectory = RemoveCipherSuffix(originalDirectory);
            string outputDirectory = cleanOriginalDirectory + Notification.UNDERSCORE_CHARACTER + Enum.GetName(typeof(CipherState), cipherState);
            bool exists = _directoryProvider.DirectoryExists(outputDirectory);
            if (!exists)
            {
                _directoryProvider.CreateDirectoryInPath(outputDirectory);
            }
            return outputDirectory;
        }

        #region Private Methods
        private void ResolveCreateDirectoryIfNoExists(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Directory.Exists)
            {
                _directoryProvider.CreateDirectoryInPath(fileInfo.DirectoryName);
            }
        }

        #endregion Private Methods
    }
}
