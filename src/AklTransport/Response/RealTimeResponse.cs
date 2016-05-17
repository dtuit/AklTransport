using System;
using System.Net;
using FeedMessage = AklTransport.Models.RealTime.FeedMessage;

namespace AklTransport.Response
{
    public class RealTimeResponse
    {
        public HttpStatusCode Status { get; set; }
        public Models.RealTime.FeedMessage Response { get; set; }
        public ATError Error { get; set; }

    }
}