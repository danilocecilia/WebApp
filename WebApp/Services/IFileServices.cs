namespace WebApp.Services
{
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IFileServices
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/UploadFile?fileName={fileName}")]
        string Upload(string filename, Stream stream);

        [OperationContract]
        [WebInvoke(Method = "GET")]
        Stream Download(string fileKey);
    }
}