using System.Threading.Tasks;
using AklTransport.Response;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATGtfsClient
    {
        public virtual async Task<ParkingLocationsResponse> ListParkingLocationsAsync()
        {
            var request = new RestRequest("public/display/parkinglocations");
            return await this.ExecuteGetAsync<ParkingLocationsResponse>(request);
        }
    }
}