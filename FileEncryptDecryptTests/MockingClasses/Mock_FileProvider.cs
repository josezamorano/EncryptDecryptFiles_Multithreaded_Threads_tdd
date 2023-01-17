using FileEncryptDecrypt.Utils.Interfaces;

namespace FileEncryptDecryptTests.MockingClasses
{
    internal class Mock_FileProvider : IFileProvider
    {
        public FileStream FileOpenRead(string inFile)
        {
            return null;
        }

        public FileStream FileOpenWrite(string outFile)
        {
            return null;
        }
    }
}
