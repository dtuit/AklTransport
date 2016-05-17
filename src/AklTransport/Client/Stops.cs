using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AklTransport.Models.Display;
using AklTransport.Response;
using RestSharp;
using RestSharp.Extensions;

namespace AklTransport.Client
{
    public partial class ATGtfsClient
    {

        public virtual async Task<StopResponse> ListStopsAsync()
        {
            var request = new RestRequest("gtfs/stops");
            return await this.ExecuteGetAsync<StopResponse>(request);
        }

        public virtual async Task<StopResponse> GetStopByIdAsync(string stopId)
        {
            var request = new RestRequest("gtfs/stops/stopId/{stop_id}");
            request.AddParameter("stop_id", stopId);
            return await this.ExecuteGetAsync<StopResponse>(request);
        }

        public virtual async Task<StopResponse> GetStopByTripIdAsync(string tripId)
        {
            var request = new RestRequest("gtfs/stops/tripId/{trip_id}");
            request.AddParameter("trip_id", tripId);
            return await this.ExecuteGetAsync<StopResponse>(request);
        }

        public virtual async Task<StopResponse> GetStopByCodeAsync(string stopCode)
        {
            var request = new RestRequest("gtfs/stops/stopCode/{stop_code}");
            request.AddParameter("stop_code", stopCode);
            return await this.ExecuteGetAsync<StopResponse>(request);
        }
        public virtual async Task<StopResponse> SearchStopsAsync(string searchText)
        {
            var request = new RestRequest("gtfs/stops/search/{search_text}");
            request.AddParameter("search_text", searchText);
            return await this.ExecuteGetAsync<StopResponse>(request);
        }

        public virtual async Task<StopResponse> SearchStopsByPositionAsync(Coordinate coordinate, double position)
        {
            var request = new RestRequest("gtfs/stops/geosearch");
            request.AddQueryParameter("lat", coordinate.Latitude.ToString());
            request.AddQueryParameter("lng", coordinate.Longitude.ToString());
            request.AddQueryParameter("position", position.ToString());
            return await this.ExecuteGetAsync<StopResponse>(request);
        }
    }
}