using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace AklTransport.Client
{
    public abstract class ATClientBase
    {
        public readonly string ApiVersion;
        public readonly string BaseUrl;
        protected string AuthToken { get; set; }

        protected RestClient Client;

        public ATClientBase(string authToken, string baseUrl, string apiVerison)
        {
            ApiVersion = apiVerison;
            AuthToken = authToken;
            BaseUrl = baseUrl;

            Client = new RestClient();
            Client.UserAgent = "ATapi-csharp";
            // add the auth token.
            Client.AddDefaultHeader("Ocp-Apim-Subscription-Key", AuthToken);
            //Client.AddDefaultParameter(AuthHeader, AuthToken, ParameterType.HttpHeader);
            Client.BaseUrl = new Uri(string.Format("{0}{1}", BaseUrl, ApiVersion));

            //TODO determine appropriate timeout
            //Client.Timeout = 30500;
        }

        
        public virtual T Execute<T>(IRestRequest request) where T : new()
        {
            var response = Client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var ATException = new ApplicationException(message, response.ErrorException);
                throw ATException;
            }

            return response.Data;
        }

        public virtual async Task<T> ExecuteGetAsync<T>(IRestRequest request, CancellationToken cancellationToken) where T : new()
        {
            var response = await Client.ExecuteGetTaskAsync<T>(request, cancellationToken);
            //TODO check this works
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var ATException = new ApplicationException(message, response.ErrorException);
                throw ATException;
            }

            return response.Data;
        }

        public virtual async Task<T> ExecuteGetAsync<T>(IRestRequest request) where T : new()
        {
            return await this.ExecuteGetAsync<T>(request, CancellationToken.None);
        }

        

    }
}
