using RestSharp.Deserializers;

namespace AklTransport.Models.GTFS
{
    public class Geometry
    {
        [DeserializeAs(Name = "shape_id")]
        public string ShapeId { get; set; }

        [DeserializeAs(Name = "the_geom")]
        public string TheGeometry { get; set; }
    }
}