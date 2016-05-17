using System.Threading.Tasks;
using AklTransport.Response;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATGtfsClient
    {
        public virtual async Task<CalendarDateResponse> CalendarExceptionListAsync()
        {
            var request = new RestRequest("gtfs/calendarDate");
            return await this.ExecuteGetAsync<CalendarDateResponse>(request);
        }
        public virtual async Task<CalendarDateResponse> GetCalendarExceptionByServiceId(string serviceId)
        {
            var request = new RestRequest("gtfs/calendarDate/serviceId/{service_id}");
            request.AddParameter("service_id", serviceId);
            return await this.ExecuteGetAsync<CalendarDateResponse>(request);
        }

    }
}