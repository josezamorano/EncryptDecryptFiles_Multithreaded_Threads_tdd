using FileEncryptDecrypt.Utils.Interfaces;
using FileEncryptor;
using System.Security.Cryptography;

namespace FileEncryptDecryptTests.MockingClasses
{
    public class Mock_CipherHelper : ICipherHelper
    {
        public string ResolveDecryption(FileStream fileStreamIn, FileStream fileStreamOut, SymmetricAlgorithm sma, Form1.ProgressCallback callback)
        {
            return string.Empty;
        }

        public string ResolveEncryption(FileStream fileStreamIn, FileStream fileStreamOut, SymmetricAlgorithm sma, Form1.ProgressCallback callback)
        {
            return string.Empty;
        }
    }
}
