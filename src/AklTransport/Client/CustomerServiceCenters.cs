using System.Threading.Tasks;
using AklTransport.Response;
using AklTransport.Models;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATGtfsClient
    {
        public virtual async Task<CustomerServiceCentreResponse> ListCustomerServiceCentresAsync()
        {
            var request = new RestRequest("public/display/customerservicecentres");
            return await this.ExecuteGetAsync<CustomerServiceCentreResponse>(request);
        }
    }
}