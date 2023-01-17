using FileEncryptDecrypt.DataAccessLayer.IOFiles;
using FileEncryptDecrypt.Services.Enumerations;
using FileEncryptDecrypt.Utils.Interfaces;
using FileEncryptDecryptTests.MockingClasses;
using Xunit;

namespace FileEncryptDecryptTests
{
    public class FileServiceTest
    {
        IFileService _fileService;
        IDirectoryProvider _directoryProvider;
        public FileServiceTest()
        {

            _directoryProvider = new Mock_DirectoryProvider();
            _fileService = new FileService(_directoryProvider); 
        }

        [Fact]
        public void GetAllFilesInDirectory()
        {
            //Arrange
            string directory = "test";
            //Act
            var result = _fileService.GetAllFilesInDirectory( directory);
            //Assert
            Assert.Equal(2, result.Count);

        }

        [Theory]
        //Arrange
        [InlineData("/test/", "/test/")]
        [InlineData("/test_Encrypted/", "/test_Encrypted/")]
        [InlineData("/test_Decrypted/", "/test_Decrypted/")]
        [InlineData("/test_Encrypted", "/test")]
        [InlineData("/test_Decrypted", "/test")]
        public void RemoveSuffixFromFile(string originalPath, string expectedResult)
        {
            //Arrange

            //Act
            var result = _fileService.RemoveCipherSuffix(originalPath);
            //Assert
            Assert.Contains(expectedResult, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void RemoveCipherSuffix_InsertInvalidInputs_ThrowsException(string originalPath)
        {
            //Assert
            Assert.Throws<ArgumentException>("fullPathFileName", () => {
                //Act
                var result = _fileService.RemoveCipherSuffix(originalPath);
            });
        }

        [Theory]
        [InlineData("test", "test/file1.txt", CipherState.Encrypted , "test_Encrypted/file1.txt_Encrypted")]
        public void CreateCipherFileName_InputValidDataReturnsOk(string originalDirectory, string fullPathOriginalFile, CipherState cipherState, string expectedResult)
        {
            //Act
            var actualResult = _fileService.CreateCipherFileName(originalDirectory , fullPathOriginalFile, cipherState);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("/test",CipherState.Encrypted , "/test_Encrypted")]
        public void CreateCipherFolderName_(string originalDirectory, CipherState cipherState, string expectedResult)
        {
            //Act
            var result = _fileService.CreateCipherFolderName(originalDirectory, cipherState);
            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}