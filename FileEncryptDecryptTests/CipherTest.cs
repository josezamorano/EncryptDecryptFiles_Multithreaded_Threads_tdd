using FileEncryptDecrypt.DomainLayer;
using FileEncryptDecrypt.DomainLayer.Models;
using FileEncryptDecrypt.Utils.Interfaces;
using FileEncryptDecryptTests.MockingClasses;
using Xunit;
using static FileEncryptor.Form1;

namespace FileEncryptDecryptTests
{
    public class CipherTest
    {
        ICipher _cipher;
        ICipherHelper _cipherHelper;
        IFileProvider _fileProvider;
        public CipherTest()
        {
            _cipherHelper = new Mock_CipherHelper();
            _fileProvider = new Mock_FileProvider();
            _cipher = new Cipher(_cipherHelper , _fileProvider);
        }

        public void ReportProgress(int value)
        {

        }

        [Fact]
        public void EncryptFile_InputValidValues_Returns_Ok()
        {
            //Arrange
            CipherActionInfo cipherActionInfo = new CipherActionInfo();
            cipherActionInfo.InFile = "/test/file1.txt";
            cipherActionInfo.OutFile = "/test_Encrypted/file1.txt_Encrypted";
            cipherActionInfo.CipherState = FileEncryptDecrypt.Services.Enumerations.CipherState.Encrypted;
            cipherActionInfo.Password = "abc";
            ProgressCallback callback = new ProgressCallback(ReportProgress);
            cipherActionInfo.ProgressCallback = callback;

            //Act
            var result = _cipher.EncryptFile(cipherActionInfo);
            //Assert
            Assert.Equal(cipherActionInfo.InFile, result);

        }

        [Fact]
        public void DecryptFile_InputValidValues_Returns_Ok()
        {
            //Arrange
            CipherActionInfo cipherActionInfo = new CipherActionInfo();
            cipherActionInfo.InFile = "/test/file1.txt";
            cipherActionInfo.OutFile = "/test_Encrypted/file1.txt_Encrypted";
            cipherActionInfo.CipherState = FileEncryptDecrypt.Services.Enumerations.CipherState.Decrypted;
            cipherActionInfo.Password = "abc";
            ProgressCallback callback = new ProgressCallback(ReportProgress);
            cipherActionInfo.ProgressCallback = callback;

            //Act
            var result = _cipher.DecryptFile(cipherActionInfo);
            //Assert
            Assert.Equal(cipherActionInfo.InFile, result);

        }


    }
}
