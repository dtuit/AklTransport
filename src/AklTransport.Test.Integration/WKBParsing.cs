using System;
using System.Linq;
using AklTransport.Client;
using Geo.Geometries;
using Geo.IO.GeoJson;
using Geo.IO.Wkb;
using Newtonsoft.Json;
using Xunit;
using Polygon = GeoJSON.Net.Geometry.Polygon;

namespace MyFirstDnxUnitTests
{
    public class WKBParsing
    {
        private string authToken = "86c92121a19c4d91b515fd2e520703f9";

        [Fact]
        public void testWKB()
        {
            var reader = new WkbReader();
            
            //var geom = reader.Read(GetBytes(Config.geom1));
            var geom = reader.Read(StringToByteArray(Config.geom1));
        }
        
        [Fact]
        public void testGEOJson()
        {
            var reader = new GeoJsonReader();

            //var geom = reader.Read(GetBytes(Config.geom1));
            var geom = reader.Read("{ \"type\": \"Point\", \"coordinates\": [100.0, 0.0] }");
        }

        [Fact]
        public void testGEOJson2()
        {
            var result = JsonConvert.DeserializeObject<Polygon>(Config.geom2);

        }

        [Fact]
        public async void test1()
        {
            var client = new ATGtfsClient(authToken);
            var result = await client.ListScheduledWorksAsync();
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

    }
}