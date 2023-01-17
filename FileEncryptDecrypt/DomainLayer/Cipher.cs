using FileEncryptDecrypt.DomainLayer.Models;
using FileEncryptDecrypt.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static FileEncryptor.Form1;

namespace FileEncryptDecrypt.DomainLayer
{
    public class Cipher : ICipher
    {
        ICipherHelper _cipherHelper;
        IFileProvider _fileProvider;
        public Cipher(ICipherHelper cipherHelper , IFileProvider fileProvider)
        {
            _cipherHelper= cipherHelper;
            _fileProvider= fileProvider;
        }
        
		// Crypto Random number generator for use in EncryptFile		
		private static RandomNumberGenerator CryptoRandomNumber = new RNGCryptoServiceProvider();
       
        private static string HASH_NAME = "SHA256";


        //Test
        public string EncryptFile(CipherActionInfo cipherActionInfo )
        {

            string inFile = cipherActionInfo.InFile;
            string outFile = cipherActionInfo.OutFile;
            string password = cipherActionInfo.Password;
            ProgressCallback callback = cipherActionInfo.ProgressCallback;
            FileStream fileStreamIn = _fileProvider.FileOpenRead(inFile);
            FileStream fileStreamOut = _fileProvider.FileOpenWrite(outFile);

            // generate IV and Salt
            byte[] IV = GenerateRandomBytes(16);
            byte[] salt = GenerateRandomBytes(16);

            SymmetricAlgorithm sma = CreateRijndaelEncryptor(password, salt);
            sma.IV = IV;

            if(fileStreamOut != null)
            {
                // write the IV and salt to the beginning of the file
                fileStreamOut.Write(IV, 0, IV.Length);
                fileStreamOut.Write(salt, 0, salt.Length);
            }            

            string fileEncryptionInfo = _cipherHelper.ResolveEncryption(fileStreamIn, fileStreamOut, sma, callback);
            return (fileEncryptionInfo.Length == 0) ? inFile : inFile + "|" + fileEncryptionInfo;
        }


        //Test
        public string DecryptFile(CipherActionInfo cipherActionInfo)
        {
            string inFile = cipherActionInfo.InFile;
            string outFile = cipherActionInfo.OutFile;
            string password = cipherActionInfo.Password;
            ProgressCallback callback = cipherActionInfo.ProgressCallback;

            // create and open the file streams
            FileStream fileStreamIn = _fileProvider.FileOpenRead(inFile);
            FileStream fileStreamOut = _fileProvider.FileOpenWrite(outFile);

            // read off the IV and Salt
            byte[] IV = new byte[16];
            byte[] salt = new byte[16];
            if(fileStreamIn != null) 
            {
                fileStreamIn.Read(IV, 0, 16);
                fileStreamIn.Read(salt, 0, 16);
            }
            
            // create the crypting stream
            SymmetricAlgorithm sma = CreateRijndaelEncryptor(password, salt);
            sma.IV = IV;

            var fileEncryptionInfo = _cipherHelper.ResolveDecryption(fileStreamIn, fileStreamOut, sma, callback);
            return (fileEncryptionInfo.Length == 0) ? inFile : inFile + "|" + fileEncryptionInfo;
        }





        #region Private Methods

        private static byte[] GenerateRandomBytes(int count)
        {
            byte[] bytes = new byte[count];
            CryptoRandomNumber.GetBytes(bytes);
            return bytes;
        }

        

        private static SymmetricAlgorithm CreateRijndaelEncryptor(string password, byte[] salt)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt, HASH_NAME, 1000);

            SymmetricAlgorithm sma = Rijndael.Create();
            sma.KeySize = 256;
            sma.Key = pdb.GetBytes(32);
            sma.Padding = PaddingMode.PKCS7;
            return sma;
        }

        #endregion Private Methods

    }
}
