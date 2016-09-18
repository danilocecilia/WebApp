namespace WebApp.Services
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using Models;

    [ServiceContract]
    public interface IPizzaServices
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void Save(Pizza pizza);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Pizza Get(int id);

        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        IEnumerable<Pizza> GetAll();

        [OperationContract]
        [WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        void Delete(int id);
    }
}