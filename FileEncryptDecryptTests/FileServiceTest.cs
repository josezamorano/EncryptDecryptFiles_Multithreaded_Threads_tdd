using FileEncryptDecrypt.DataAccessLayer.IOFiles;
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

        [Fact]
        public void RemoveSuffixFromFile()
        {
            //Arrange

            //Act
            var result = _fileService.RemoveCipherSuffix("test");
            //Assert
        }
    }
}