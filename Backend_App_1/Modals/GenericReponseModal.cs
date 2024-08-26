using System.Net;

namespace Backend_App_1.Modals
{
    public class GenericReponseModal
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public dynamic Payload { get; set; }

    }
}
