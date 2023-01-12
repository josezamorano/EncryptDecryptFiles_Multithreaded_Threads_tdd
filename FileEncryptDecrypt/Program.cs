using FileEncryptDecrypt.Utils.DependencyInjection;
using Autofac;
using FileEncryptDecrypt.Services.Validator;
using FileEncryptDecrypt.Utils.Interfaces;

namespace FileEncryptor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Autofac.IContainer container = ContainerConfig.Configure();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            ICryptographyManager cryptographyManager = container.Resolve<ICryptographyManager>();
                
            IPasswordValidator passwordValidator = container.Resolve<IPasswordValidator>();

            Application.Run(new Form1(cryptographyManager , passwordValidator));
        }
    }
}