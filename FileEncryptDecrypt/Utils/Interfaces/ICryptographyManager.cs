using FileEncryptDecrypt.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncryptDecrypt.Utils.Interfaces
{
    public interface ICryptographyManager
    {

        FolderContentInfo GetAllFiles(string folder);

        void CipherProcessAllFilesThread(CipherInvocationInfo cipherInvocationInfo);
    }
}
