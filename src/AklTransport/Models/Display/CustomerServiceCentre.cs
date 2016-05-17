using System.ComponentModel.DataAnnotations;
using AklTransport.Models.GTFS;

namespace AklTransport.Models.Display
{
    public class CustomerServiceCentre : GTFSEntity
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string Phone { get; set; }
        public string OpenHours { get; set; }
        public bool HopServices { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}