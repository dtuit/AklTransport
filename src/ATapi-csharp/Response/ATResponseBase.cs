using System.Collections.Generic;

namespace ATapi_csharp.Response
{
    public abstract class ATResponseBase<T>
    {
        public List<T> Response { get; set; }
        public string Status { get; set; }
        public ATError Error { get; set; }
    }
}