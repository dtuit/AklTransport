using System;
using System.IO;
using System.Threading.Tasks;
using AklTransport.Models.RealTime;
using AklTransport.Response;
using ProtoBuf;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace AklTransport.Client
{
    public partial class ATRealTimeClient : ATClientBase
    {
        private bool _isUsingProtoBuf = false;

        public ATRealTimeClient(string authToken) : this(authToken, Configuration.BaseUrl, Configuration.ApiVersion)
        {

        }

        public ATRealTimeClient(string authToken, string baseUrl, string apiVerison) : base(authToken, baseUrl, apiVerison)
        {

        }

        public void UseProtocolBuffers()
        {
            Client.ClearHandlers();
            IDeserializer deserializer = new ProtoBufDeserializer();
            Client.AddHandler("application/x-protobuf", deserializer);
            Client.AddHandler("application/octet-stream", deserializer);
            Client.AddDefaultHeader("Accept", "application/x-protobuf");
            Client.AddDefaultHeader("Accept", "application/octet-stream");
            _isUsingProtoBuf = true;
        }

        public virtual async Task<FeedMessage> GetGTFSRealTimeFeed()
        {
            return await GetGTFSRealTimeFeed(null, null);
        }
        
        public virtual async Task<FeedMessage> GetGTFSRealTimeFeed(string tripId, string vechileId)
        {
            var request = CreateRealTimeRequest("public/realtime", tripId, vechileId);
            return await ExecuteRealTimeRequestAsync(request);
        }

        public virtual async Task<FeedMessage> GetGTFSRealTimeTripUpdates()
        {
            return await GetGTFSRealTimeTripUpdates(null, null);
        }

        public virtual async Task<FeedMessage> GetGTFSRealTimeTripUpdates(string tripId, string vechileId)
        {
            var request = CreateRealTimeRequest("public/realtime/tripupdates", tripId, vechileId);
            return await ExecuteRealTimeRequestAsync(request);
        }

        public virtual async Task<FeedMessage> GetGTFSRealTimeVechileLocations()
        {
            return await GetGTFSRealTimeVechileLocations(null, null);
        }

        public virtual async Task<FeedMessage> GetGTFSRealTimeVechileLocations(string tripId, string vechileId)
        {
            var request = CreateRealTimeRequest("public/realtime/vehiclelocations", tripId, vechileId);
            return await ExecuteRealTimeRequestAsync(request);
        }


        private IRestRequest CreateRealTimeRequest(string resource, string tripId, string vechileId)
        {
            var request = new RestRequest(resource);
            if (!String.IsNullOrEmpty(tripId))
                request.AddQueryParameter("tripId", tripId);
            if (!String.IsNullOrEmpty(vechileId))
                request.AddQueryParameter("vechileId", vechileId);
            return request;
        }

        private async Task<FeedMessage> ExecuteRealTimeRequestAsync(IRestRequest request)
        {
            if (_isUsingProtoBuf)
            {
                var resp = await ExecuteGetAsync<FeedMessage>(request);
                return resp;
            }
            else
            {
                var resp = await ExecuteGetAsync<RealTimeResponse>(request);
                return resp.Response;
            }
        }
    }

    internal class ProtoBufDeserializer : IDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            using (var memoryStream = new MemoryStream(response.RawBytes))
            {
                 return Serializer.Deserialize<T>(memoryStream);
            }
        }
    }
}