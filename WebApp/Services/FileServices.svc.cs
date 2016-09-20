namespace WebApp.Services
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.ServiceModel.Activation;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FileServices : IFileServices
    {
        private static string UploadsDirecotry = ConfigurationManager.AppSettings["UploadsDirectory"];

        public string Upload(string filename, Stream stream)
        {
            var fileKey = Path.Combine(DateTime.Now.Ticks.ToString(), filename);
            var filepath = Path.Combine(UploadsDirecotry, fileKey);
            var directory = Path.GetDirectoryName(filepath);

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (var fileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
                stream.CopyTo(fileStream);

            return fileKey;
        }

        public Stream Download(string fileKey) =>
            new FileStream(GetFilePath(fileKey), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        private static string GetFilePath(string fileKey) => 
            Path.Combine(UploadsDirecotry, fileKey);

        internal static string GetPublicResource(string fileKey) => 
            $"/Services/FileServices.svc/Download?fileKey={fileKey}";

        internal static void Delete(string fileKey) =>
            File.Delete(GetFilePath(fileKey));
    }
}