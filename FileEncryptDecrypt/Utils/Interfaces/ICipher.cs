using FileEncryptDecrypt.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptDecrypt.Utils.Interfaces
{
    public interface ICipher
    {
        string EncryptFile(CipherActionInfo cipherActionInfo);

        string DecryptFile(CipherActionInfo cipherActionInfo);
    }
}
