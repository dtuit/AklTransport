namespace ATapi_csharp.Client
{
    public partial class ATRestClient : ATClientBase
    {
        public ATRestClient(string authToken) : this(authToken, "https://api.at.govt.nz/", "v2")
        {

        }

        public ATRestClient(string authToken, string baseUrl, string apiVerison) : base(authToken, baseUrl, apiVerison)
        {
        }


    }
}
