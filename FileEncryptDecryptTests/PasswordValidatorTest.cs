using FileEncryptDecrypt.Services.Validator;
using FileEncryptDecrypt.Utils.Interfaces;
using Xunit;

namespace FileEncryptDecryptTests
{
    public class PasswordValidatorTest
    {
        IPasswordValidator _passwordValidator;

        public PasswordValidatorTest()
        {
            _passwordValidator = new PasswordValidator();
        }
        [Theory]
        [InlineData("abc", "abc", "")]
        [InlineData("", "abc", "WARNING: Password is Empty!")]
        [InlineData("abc", "", "WARNING: Confirm Password is Empty!")]
        [InlineData("abc", "def", "WARNING: Password and Confirm Password are discrepant!")]
        public void ComparePasswords_AllTypesOfInputs_Returns_CorrectResponse(string pwd, string confirmPwd, string expectedResult)
        {
            //Act
            var actualResult = _passwordValidator.ComparePasswords(pwd, confirmPwd);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
