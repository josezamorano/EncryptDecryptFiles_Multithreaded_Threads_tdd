namespace FileEncryptDecrypt.Utils.Interfaces
{
    public interface IPasswordValidator
    {
        string ComparePasswords(string password, string confirmPassword);
    }
}
