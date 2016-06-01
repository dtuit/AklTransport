using System;
using AklTransport.Client;
using AklTransport.Response;
using Moq;
using RestSharp;
using Xunit;

namespace AklTransport.Test.Integration
{
    public class ATGtfsClientTests
    {
        private ATGtfsClient Client;
        private Mock<ATGtfsClient> MockClient;

        public ATGtfsClientTests()
        {

            MockClient = new Mock<ATGtfsClient>(Credentials.AuthToken);
            Client = new ATGtfsClient(Credentials.AuthToken);
        }

        [Fact]
        public void ShouldGetAgencyListAsyncronsly()
        {
            IRestRequest savedRequest = null;
            MockClient.Setup(x => x.ExecuteGetAsync<AgencyResponse>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .ReturnsAsync(new AgencyResponse());

            var client = MockClient.Object;

            client.ListAgenciesAsync().Wait();

            MockClient.Verify(x => x.ExecuteGetAsync<AgencyResponse>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.NotNull(savedRequest);
        }

    }



}