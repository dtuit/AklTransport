using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Authenticators;

namespace ATapi_csharp
{
    public abstract class ATClientBase
    {
        public string ApiVersion { get; private set; }
        public string BaseUrl { get; private set; }
        protected string AuthToken { get; set; }

        private const string AuthHeader = "Ocp-Apim-Subscription-Key";

        protected RestClient Client;

        public ATClientBase(string authToken, string baseUrl, string apiVerison)
        {
            ApiVersion = apiVerison;
            AuthToken = authToken;
            BaseUrl = baseUrl;

            Client = new RestClient();
            Client.UserAgent = "ATapi-csharp";
            // add the auth token.
            Client.AddDefaultHeader(AuthHeader, AuthToken);
            //Client.AddDefaultParameter(AuthHeader, AuthToken, ParameterType.HttpHeader);
            Client.BaseUrl = new Uri(string.Format("{0}{1}", BaseUrl, ApiVersion));

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

        public virtual Task<T> ExecuteAsync<T>(IRestRequest request, CancellationToken cancellationToken) where T : new()
        {
            var response = Client.ExecuteGetTaskAsync<T>(request, cancellationToken);
            var taskCompletionSource = new TaskCompletionSource<T>(response.Result.Data);
            return taskCompletionSource.Task;
        }

        public virtual Task<T> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            return this.ExecuteAsync<T>(request, CancellationToken.None);
        }
    }
}
