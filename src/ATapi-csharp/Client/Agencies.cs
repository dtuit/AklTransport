using ATapi_csharp.Response;
using RestSharp;

namespace ATapi_csharp.Client
{
    public partial class ATRestClient
    {
        public virtual AgencyResponse GetAgencies()
        {
            var resource = "gtfs/agency";
            var request = new RestRequest(resource);
            var response = this.Execute<AgencyResponse>(request);
            return response;
        }

    }
}