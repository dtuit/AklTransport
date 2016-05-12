using System.Threading.Tasks;
using ATapi_csharp.Response;
using RestSharp;

namespace ATapi_csharp.Client
{
    public partial class ATRestClient
    {
        private const string CalendarResource = "gtfs/calendar";

        public async Task<CalendarResponse> GetCalendarAsync()
        {
            var request = new RestRequest(CalendarResource);
            return await this.ExecuteGetAsync<CalendarResponse>(request);
        }

        public async Task<CalendarResponse> GetCalendarAsync(string serviceId)
        {
            var request = new RestRequest(CalendarResource + "/serviceId/{service_id}");
            request.AddUrlSegment("service_id", serviceId);
            return await this.ExecuteGetAsync<CalendarResponse>(request);
        }
    }
}