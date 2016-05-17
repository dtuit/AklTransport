using System.Threading.Tasks;
using AklTransport.Response;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATGtfsClient
    {
        public virtual async Task<ShapeResponse> GetShapeByIdAsync(string shapeId)
        {
            var request = new RestRequest("gtfs/shapes/shapeId/{shape_id}");
            request.AddParameter("shape_id", shapeId);
            return await this.ExecuteGetAsync<ShapeResponse>(request);
        }

        public virtual async Task<ShapeResponse> GetShapeByTripIdAsync(string tripId)
        {
            var request = new RestRequest("gtfs/shapes/tripId/{trip_id}");
            request.AddParameter("trip_id", tripId);
            return await this.ExecuteGetAsync<ShapeResponse>(request);
        }

        public virtual async Task<GeometryResponse> GetShapeGeometryByIdAsync(string shapeId)
        {
            var request = new RestRequest("gtfs/shapes/geometry/{shape_id}");
            request.AddParameter("shape_id", shapeId);
            return await this.ExecuteGetAsync<GeometryResponse>(request);
        }
    }
}