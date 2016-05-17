using System.ComponentModel.DataAnnotations;
using AklTransport.Models.GTFS;

namespace AklTransport.Models.Display
{
    public class ParkingLocation : GTFSEntity
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobilitySpaces { get; set; }
        public string Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}