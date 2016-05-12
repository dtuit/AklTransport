
using System;
using System.Collections.Generic;
using ATapi_csharp.Client;
using RestSharp;
using Xunit;

namespace MyFirstDnxUnitTests
{
    public class ATRestClientTests
    {
        private string authToken = "86c92121a19c4d91b515fd2e520703f9";

        [Fact]
        public void basicTest()
        {
            var client = new ATRestClient(authToken);
            var result = client.GetAgencies();

            Assert.True(1 == 1);
        }

        [Fact]
        public async void basicTest2()
        {
            var client = new ATRestClient(authToken);
            var result = await client.GetCalendarAsync();
            Assert.True(1 == 1);
        }

        [Fact]
        public async void basicTest3()
        {
            var client = new ATRestClient(authToken);
            var result = await client.GetCalendarAsync("14731023325-20160504151331_v40.22");
            Assert.True(1 == 1);

        }

        [Fact]
        public void test2()
        {
            var client = new RestClient();
            client.UserAgent = "ATapi-csharp";
            // add the auth token.
            client.AddDefaultHeader("Ocp-Apim-Subscription-Key", authToken);
            //Client.AddDefaultParameter(AuthHeader, AuthToken, ParameterType.HttpHeader);
            client.BaseUrl = new Uri("https://api.at.govt.nz/v2");

            var request = new RestRequest("gtfs/agency");

            var response = client.Execute<RootObject>(request);

            var data = response.Data;

            Assert.True(1 == 1);
        }
    }
    public class Response
    {
        public string agency_id { get; set; }
        public string agency_name { get; set; }
        public string agency_url { get; set; }
        public string agency_timezone { get; set; }
        public string agency_lang { get; set; }
        public string agency_phone { get; set; }
        public object agency_fare_url { get; set; }
    }

    public class RootObject
    {
        public string status { get; set; }
        public List<Response> response { get; set; }
        public object error { get; set; }
    }
}