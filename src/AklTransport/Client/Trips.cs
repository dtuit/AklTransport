using System.Threading.Tasks;
using AklTransport.Response;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATGtfsClient
    {
        public virtual async Task<TripResponse> ListTripsAsync()
        {
            var request = new RestRequest("gtfs/trips");
            return await this.ExecuteGetAsync<TripResponse>(request);
        }

        public virtual async Task<TripResponse> GetTripsByRouteIdAsync(string routeId)
        {
            var request = new RestRequest("gtfs/trips/routeid/{route_id}");
            request.AddParameter("route_id", routeId);
            return await this.ExecuteGetAsync<TripResponse>(request);
        }

        public virtual async Task<TripResponse> GetTripsByTripIdAsync(string tripId)
        {
            var request = new RestRequest("gtfs/trips/tripId/{trip_id}");
            request.AddParameter("trip_id", tripId);
            return await this.ExecuteGetAsync<TripResponse>(request);
        }
    }
}