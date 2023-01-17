using FileEncryptDecrypt.DomainLayer;
using FileEncryptDecrypt.DomainLayer.Models;
using FileEncryptDecrypt.Utils.Interfaces;
using FileEncryptDecryptTests.MockingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static FileEncryptor.Form1;

namespace FileEncryptDecryptTests
{
    public class CryptographyManagerTest
    {
        ICryptographyManager _cryptographyManager;
        public CryptographyManagerTest()
        {
            IFileService _fileService = new Mock_FileService();
            ICipher _cipher = new Mock_Cipher();

            _cryptographyManager = new CryptographyManager(_fileService, _cipher);
        }


        [Fact]
        public void GetAllFiles_InputValidFolder_ReturnsAllFilesList()
        {
            //Arrange
            var folder = "/test";
            var expectedCount = 2;
            //Act
            var result = _cryptographyManager.GetAllFiles(folder);
            //Assert
            Assert.Equal(expectedCount, result.TotalFiles);
        }

        [Fact]
        public void CipherProcessAllFilesThread_InputValid_ReturnsOk()
        {
            //Arrange
            void Report(string reportInfo)
            {
                Assert.NotNull(reportInfo);
            }

            void Progress(int value)
            {
            }


            CipherInvocationInfo cipherInvocationInfo = new CipherInvocationInfo();
            cipherInvocationInfo.CipherState = FileEncryptDecrypt.Services.Enumerations.CipherState.Encrypted;
            cipherInvocationInfo.Password = "abc";

            ReportCallBack reportCallback = new ReportCallBack(Report);
            cipherInvocationInfo.ReportCallBack = reportCallback;

            ProgressCallback progressCallback = new ProgressCallback(Progress);
            cipherInvocationInfo.ProgressCallback = progressCallback;
            //Act
            _cryptographyManager.CipherProcessAllFilesThread(cipherInvocationInfo);

        }


    }
}
