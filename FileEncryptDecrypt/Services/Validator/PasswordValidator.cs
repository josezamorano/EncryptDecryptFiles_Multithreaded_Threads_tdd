using FileEncryptDecrypt.Services.Messages;
using FileEncryptDecrypt.Utils.Interfaces;

namespace FileEncryptDecrypt.Services.Validator
{
    public class PasswordValidator : IPasswordValidator
    {
        public string ComparePasswords(string password ,string confirmPassword)
        {
            if (password.Trim() == string.Empty)
            {
                return Notification.WARNING_PWD_EMPTY;                
            }
            if (confirmPassword.Trim() == string.Empty)
            {
                return Notification.WARNING_CONFIRM_PWD_EMPTY;              
            }
            if ( password.Trim() != confirmPassword.Trim())
            {
                return Notification.WARNING_PWDS_DISCREPANCY;
                
            }
            return string.Empty;
        }
    }
}
