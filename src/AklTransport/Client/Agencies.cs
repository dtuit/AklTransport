using System.Threading.Tasks;
using AklTransport.Response;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATGtfsClient
    {
        public virtual async Task<AgencyResponse> ListAgenciesAsync()
        {
            var resource = "gtfs/agency";
            var request = new RestRequest(resource);
            return await this.ExecuteGetAsync<AgencyResponse>(request);
        }

    }
}