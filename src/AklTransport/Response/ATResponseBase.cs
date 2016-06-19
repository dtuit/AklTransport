using System.Collections.Generic;
using System.Net;
using RestSharp.Deserializers;

namespace AklTransport.Response











{
    public abstract class ATResponseBase<T>
    {
        public List<T> Response { get; set; }
        public HttpStatusCode Status { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public ATError Error { get; set; }
        public virtual bool HasError()
        {
            return Error != null;
        }

        public virtual bool IsEmptyResponse()
        {
            return Response == null || Response.Count == 0;
        }


    }
}