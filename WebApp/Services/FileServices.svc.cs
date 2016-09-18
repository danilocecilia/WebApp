namespace WebApp.Services
{
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
                 InstanceContextMode = InstanceContextMode.PerCall,
                 IgnoreExtensionDataObject = true,
                 IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FileServices : IFileServices
    {
        public void Upload(Stream stream)
        {
            var filepath = Path.Combine(@"C:\Users\lucas\Desktop\", /*filename*/"champs.JPG");
            using (var fileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
                fileStream.Flush();
            }
        }
    }
}