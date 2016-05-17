using System.Threading.Tasks;
using AklTransport.Response;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATRestClient
    {
        public async Task<CalendarResponse> ListCalendarAsync()
        {
            var request = new RestRequest("gtfs/calendar");
            return await this.ExecuteGetAsync<CalendarResponse>(request);
        }

        public async Task<CalendarResponse> GetCalendarByServiceIdAsync(string serviceId)
        {
            var request = new RestRequest("gtfs/calendar/serviceId/{service_id}");
            request.AddUrlSegment("service_id", serviceId);
            return await this.ExecuteGetAsync<CalendarResponse>(request);
        }
    }
}