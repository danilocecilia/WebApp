namespace WebApp.Services
{
    using System;
    using System.IO;
    using System.ServiceModel.Activation;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FileServices : IFileServices
    {
        public string Upload(string filename, Stream stream)
        {
            var fileKey = Path.Combine(DateTime.Now.Ticks.ToString(), filename);
            var filepath = Path.Combine(Environment.CurrentDirectory, "Uploads", fileKey);
            var directory = Path.GetDirectoryName(filepath);

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (var fileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
                stream.CopyTo(fileStream);

            return fileKey;
        }

        public Stream Download(string fileKey)
        {
            var filepath = Path.Combine(Environment.CurrentDirectory, "Uploads", fileKey);

            return new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        internal static string GetPublicResource(string fileKey)
        {
            return $"/Services/FileServices.svc/Download?fileKey={fileKey}";
        }
    }
}