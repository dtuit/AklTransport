using System;
using System.Collections.Generic;

namespace AklTransport.Models.Display
{
    public class ScheduledWorks
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string ContractorCompany { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public String Geometry { get; set; }
        //public GeometryHolder Geometry { get; set; }

    }
    //TODO research Use WKB Format Geometry and potentialy Deseralize.
    public class GeometryHolder
    {
        public string Type { get; set; }
        //Must use string instead of double, because sometimes they are strings
        public List<List<string>> Coordinates { get; set; }
        public bool Encoded { get; set; }

        public List<Coordinate> GetCoordinatesAsCoordinates()
        {
            var retval = new List<Coordinate>();
            foreach (var i in Coordinates)
            {
                if (i.Count == 2)
                {
                    retval.Add(new Coordinate()
                    {
                        Latitude = Convert.ToDouble(i[0]),
                        Longitude = Convert.ToDouble(i[1])
                    });
                }
                else
                {
                    //TODO determine if exception or what exception to throw.
                    //throw new Exception();
                }

            }
            return retval;
        }
    }

    public class Coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}