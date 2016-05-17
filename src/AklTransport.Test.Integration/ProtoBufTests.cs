using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using AklTransport.Client;
using AklTransport.Models.RealTime;
using AklTransport.Response;
using ProtoBuf;
using RestSharp;
using Xunit;

namespace MyFirstDnxUnitTests
{
    public class ProtoBufTests
    {
        [Fact]
        public void testProtobuf()
        {
            var client = new RestClient("https://api.at.govt.nz/v2/");
            client.AddDefaultHeader("Ocp-Apim-Subscription-Key", "86c92121a19c4d91b515fd2e520703f9");
            
            var request = new RestRequest("public/realtime");
            request.AddHeader("Accept", "application/x-protobuf");
            request.AddQueryParameter("tripid", "8300023962-20160415132758_v40.14");
             
            FeedMessage result;
            request.ResponseWriter = stream => result = Serializer.Deserialize<FeedMessage>(stream);
            //request.ResponseWriter = (responseStream) => responseStream.CopyTo(writer);

            //request.JsonSerializer = new Serializer();
            //Serializer.Deserialize<FeedMessage>();

            var response = client.DownloadData(request);
            Assert.True(1 == 1);
        }

        [Fact]
        public void testProtoBuf2()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.at.govt.nz/v2/public/realtime?tripid=15336008612-20160415132758_v40.14");
            //req.Headers.Add("Accept", "application/x-protobuf");
            req.Accept = "application/x-protobuf";
            req.Headers.Add("Ocp-Apim-Subscription-Key", "86c92121a19c4d91b515fd2e520703f9");
            FeedMessage feed = Serializer.Deserialize<FeedMessage>(req.GetResponse().GetResponseStream());
        }

        [Fact]
        public void testProtoBuf3()
        {
            //as json
            var client = new RestClient("https://api.at.govt.nz/v2/");
            client.AddDefaultHeader("Ocp-Apim-Subscription-Key", "86c92121a19c4d91b515fd2e520703f9");

            var request = new RestRequest("public/realtime");
            //request.AddHeader("Accept", "application/x-protobuf");
            request.AddQueryParameter("tripid", "1981016561-20160415132758_v40.14");

            var response = client.Execute<RealTimeResponse>(request);
            Assert.True(1 == 1);
        }

        [Fact]
        public void gestP()
        {
            var client = new ATRealTimeClient("86c92121a19c4d91b515fd2e520703f9");
            var request = new RestRequest("public/realtime");
            request.AddQueryParameter("tripid", "15336008612-20160415132758_v40.14");
            var response = client.Execute<FeedMessage>(request);
            Assert.True(1 == 1);
        }

        [Fact]
        public void test1()
        {
            var feed = new FeedMessage()
            {
            };

            var obj = new tempObj()
            {
                
            };
        }

        [Serializable]
        public class tempObj
        {
            private readonly string _prop;
            public string prop { get; }
        }

        [Fact]
        public void testProtoBuf4()
        {
            //as json
            var client = new RestClient("https://api.at.govt.nz/v2/");
            client.AddDefaultHeader("Ocp-Apim-Subscription-Key", "86c92121a19c4d91b515fd2e520703f9");

            var request = new RestRequest("public/realtime");
            //request.AddHeader("Accept", "application/x-protobuf");
            request.AddQueryParameter("tripid", "3525007891-20160415132758_v40.14");

            var response = client.Execute<RealTimeResponse>(request);
            Assert.True(1 == 1);
        }

        [Fact]
        public async void test31()
        {
            var client = new ATRealTimeClient("86c92121a19c4d91b515fd2e520703f9");
            var resp = await client.GetGTFSRealTimeFeed();
        }

        [Fact]
        public async void test33()
        {
            var client = new ATRealTimeClient("86c92121a19c4d91b515fd2e520703f9");
            var resp = await client.GetGTFSRealTimeFeed("14526020256-20160415132758_v40.14", null);
        }

        [Fact]
        public async void test34()
        {
            var client = new ATRealTimeClient("86c92121a19c4d91b515fd2e520703f9");
            var resp = await client.GetGTFSRealTimeVechileLocations();
        }

        [Fact]
        public async void test354()
        {
            var client = new ATRealTimeClient("86c92121a19c4d91b515fd2e520703f9");
            client.UseProtocolBuffers();
            var resp = await client.GetGTFSRealTimeTripUpdates();
        }
    }
}