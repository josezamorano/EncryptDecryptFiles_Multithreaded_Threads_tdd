using FileEncryptDecrypt.Utils.Interfaces;

namespace FileEncryptDecrypt.DataAccessLayer.IOFiles
{
    public class FileProvider : IFileProvider
    {
        public FileStream FileOpenRead(string inFile)
        {
            FileStream fileStreamIn = File.OpenRead(inFile);
            return fileStreamIn;
        }

        public FileStream FileOpenWrite(string outFile)
        {
            FileStream fileStreamOut = File.OpenWrite(outFile);
            return fileStreamOut;
        }
    }
}
