using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATapi_csharp
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
