using System.Threading.Tasks;
using AklTransport.Response;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATGtfsClient
    {
        public virtual async Task<StopTimeResponse> GetStopTimesByStopIdAsync(string stopId)
        {
            var request = new RestRequest("gtfs/stopTimes/stopId/{stop_id}");
            request.AddParameter("stop_id", stopId);
            return await this.ExecuteGetAsync<StopTimeResponse>(request);
        }

        public virtual async Task<StopTimeResponse> GetStopTimesByTripIdAsync(string tripId)
        {
            var request = new RestRequest("gtfs/stopTimes/tripId/{trip_id}");
            request.AddParameter("trip_id", tripId);
            return await this.ExecuteGetAsync<StopTimeResponse>(request);
        }

        public virtual async Task<StopTimeResponse> GetStopTimesByTripIdAndStopSequenceAsync(string tripId, string stopSequence)
        {
            var request = new RestRequest("gtfs/stopTimes/tripId/{trip_id}/stopSequence/{stop_sequence}");
            request.AddParameter("trip_id", tripId);
            request.AddParameter("stop_sequence", stopSequence);
            return await this.ExecuteGetAsync<StopTimeResponse>(request);
        }
    }
}