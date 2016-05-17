namespace AklTransport.Client
{
    public partial class ATRestClient : ATClientBase
    {
        public ATRestClient(string authToken) : this(authToken, Configuration.BaseUrl, Configuration.ApiVersion)
        {

        }

        public ATRestClient(string authToken, string baseUrl, string apiVerison) : base(authToken, baseUrl, apiVerison)
        {
        }


    }
}
