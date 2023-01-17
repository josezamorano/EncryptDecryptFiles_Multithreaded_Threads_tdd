using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static FileEncryptor.Form1;

namespace FileEncryptDecrypt.Utils.Interfaces
{
    public interface ICipherHelper
    {
        string ResolveEncryption(FileStream fileStreamIn, FileStream fileStreamOut, SymmetricAlgorithm sma, ProgressCallback callback);

        string ResolveDecryption(FileStream fileStreamIn, FileStream fileStreamOut, SymmetricAlgorithm sma, ProgressCallback callback);
    }
}