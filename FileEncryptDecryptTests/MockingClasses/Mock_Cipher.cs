using FileEncryptDecrypt.DomainLayer.Models;
using FileEncryptDecrypt.Utils.Interfaces;

namespace FileEncryptDecryptTests.MockingClasses
{
    public class Mock_Cipher : ICipher
    {
        public string DecryptFile(CipherActionInfo cipherActionInfo)
        {
            throw new NotImplementedException();
        }

        public string EncryptFile(CipherActionInfo cipherActionInfo)
        {
            throw new NotImplementedException();
        }
    }
}
