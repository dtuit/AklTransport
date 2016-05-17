using System.Threading.Tasks;
using AklTransport.Response;
using RestSharp;

namespace AklTransport.Client
{
    public partial class ATRestClient
    {
        public virtual async Task<ScheduledWorksResponse> ListScheduledWorksAsync()
        {
            var request = new RestRequest("public/display/scheduledworks");
            return await this.ExecuteGetAsync<ScheduledWorksResponse>(request);
        }
    }
}