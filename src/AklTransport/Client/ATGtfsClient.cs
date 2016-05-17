namespace AklTransport.Client
{
    public partial class ATGtfsClient : ATClientBase
    {
        public ATGtfsClient(string authToken) : this(authToken, Configuration.BaseUrl, Configuration.ApiVersion)
        {

        }

        public ATGtfsClient(string authToken, string baseUrl, string apiVerison) : base(authToken, baseUrl, apiVerison)
        {
        }


    }
}
