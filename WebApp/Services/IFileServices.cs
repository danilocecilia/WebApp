namespace WebApp.Services
{
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IFileServices
    {
        [OperationContract]
        [DataContractFormat]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        void Upload(Stream stream);
    }
}