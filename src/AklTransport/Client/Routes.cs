using System.Threading.Tasks;
using AklTransport.Models.Display;
using AklTransport.Response;
using AklTransport.Models;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATGtfsClient
    {
        private const string RoutesResource = "gtfs/routes";


        public virtual async Task<RouteResponse> ListRoutes()
        {
            var request = new RestRequest(RoutesResource);
            return await this.ExecuteGetAsync<RouteResponse>(request);
        }

        public virtual async Task<RouteResponse> GetRouteAsync(string routeId)
        {
            var request = new RestRequest(RoutesResource + "/routeId/{route_id}");
            request.AddParameter("route_id", routeId);
            return await this.ExecuteGetAsync<RouteResponse>(request);
        }

        public virtual async Task<RouteResponse> GetRoutesByStopIdAsync(string stopId)
        {
            var request = new RestRequest(RoutesResource + "/stopid/{stop_id}");
            request.AddParameter("stop_id", stopId);
            return await this.ExecuteGetAsync<RouteResponse>(request);
        }

        public virtual async Task<RouteResponse> GetRoutesByLongNameAsync(string routeLongName)
        {
            var request = new RestRequest(RoutesResource + "/routeLongName/{route_long_name}");
            request.AddParameter("route_long_name", routeLongName);
            return await this.ExecuteGetAsync<RouteResponse>(request);
        }

        public virtual async Task<RouteResponse> GetRoutesByShortName(string routeShortName)
        {
            var request = new RestRequest(RoutesResource + "/routeShortName/{route_short_name}");
            request.AddParameter("route_short_name", routeShortName);
            return await this.ExecuteGetAsync<RouteResponse>(request);
        }

        public virtual async Task<RouteResponse> SearchRoutes(string searchText)
        {
            var request = new RestRequest(RoutesResource + "/search/{search_text}");
            request.AddParameter("search_text", searchText);
            return await this.ExecuteGetAsync<RouteResponse>(request);
        }

        public virtual async Task<RouteResponse> SearchRoutesByPosition(Coordinate location, double distance)
        {
            var request = new RestRequest(RoutesResource + "/geosearch");
            request.AddQueryParameter("lat", location.Longitude.ToString());
            request.AddQueryParameter("lng", location.Longitude.ToString());
            request.AddQueryParameter("distance", distance.ToString());
            return await this.ExecuteGetAsync<RouteResponse>(request);
        }

    }
}