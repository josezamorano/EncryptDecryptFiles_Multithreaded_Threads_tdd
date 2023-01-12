using Autofac;
using FileEncryptDecrypt.DataAccessLayer.IOFiles;
using FileEncryptDecrypt.DomainLayer;
using FileEncryptDecrypt.Services.Validator;
using FileEncryptDecrypt.Utils.Interfaces;

namespace FileEncryptDecrypt.Utils.DependencyInjection
{
    public static class ContainerConfig
    {
        public static Autofac.IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Cipher>().As<ICipher>();            
            builder.RegisterType<CryptographyManager>().As<ICryptographyManager>();
            builder.RegisterType<DirectoryProvider>().As<IDirectoryProvider>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<PasswordValidator>().As<IPasswordValidator>();
            


            return builder.Build();

        }
    }
}
