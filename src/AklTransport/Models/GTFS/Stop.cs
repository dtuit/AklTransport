﻿// The MIT License (MIT)

// Copyright (c) 2016 Ben Abelshausen

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.ComponentModel.DataAnnotations;
using AklTransport.Models.GTFS.Enumerations;
using RestSharp.Deserializers;

namespace AklTransport.Models.GTFS
{
    /// <summary>
    /// Represents an individual location where vehicles pick up or drop off passengers.
    /// </summary>
        public class Stop : GTFSEntity
    {
        /// <summary>
        /// Gets or sets an ID that uniquely identifies a stop or station. Multiple routes may use the same stop. The stop_id is dataset unique.
        /// </summary>
        [Required]
        [DeserializeAs(Name = "stop_id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets short text or a number that uniquely identifies the stop for passengers. Stop codes are often used in phone-based transit information systems or printed on stop signage to make it easier for riders to get a stop schedule or real-time arrival information for a particular stop.
        /// </summary>
        [DeserializeAs(Name = "stop_code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name of a stop or station. Please use a name that people will understand in the local and tourist vernacular.
        /// </summary>
        [DeserializeAs(Name = "stop_name")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of a stop. Please provide useful, quality information. Do not simply duplicate the name of the stop.
        /// </summary>
        [DeserializeAs(Name = "stop_desc")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the latitude of a stop or station. The field value must be a valid WGS 84 latitude.
        /// </summary>
        [Required]
        [DeserializeAs(Name = "stop_lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of a stop or station. The field value must be a valid WGS 84 longitude value from -180 to 180.
        /// </summary>
        [Required]
        [DeserializeAs(Name = "stop_lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the fare zone for a stop. Zone IDs are required if you want to provide fare information using fare rules. If this stop ID represents a station, the zone ID is ignored.
        /// </summary>
        [DeserializeAs(Name = "zone_id")]
        public string Zone { get; set; }

        /// <summary>
        /// Gets or set the URL of a web page about a particular stop. This should be different from the agency_url and the route_url fields. The value must be a fully qualified URL that includes http:// or https://, and any special characters in the URL must be correctly escaped.
        /// </summary>
        [DeserializeAs(Name = "stop_url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the location field that identifies whether this stop represents a stop or station. If no location type is specified, or the location type is blank, stops are treated as regular stops. Stations may have different properties from stops when they are represented on a map or used in trip planning.
        /// </summary>
        [DeserializeAs(Name = "location_type")]
        public LocationType? LocationType { get; set; }

        /// <summary>
        /// Gets or sets the station associated with the stop. To use this field, a stop must also exist where this stop ID is assigned LocationType=Station.
        /// </summary>
        [DeserializeAs(Name = "parent_station")]
        public string ParentStation { get; set; }

        /// <summary>
        /// Gets or sets the timezone in which this stop or station is located. Please refer to Wikipedia List of Timezones for a list of valid values. If omitted, the stop should be assumed to be located in the timezone specified by agency_timezone in agency.txt.
        /// </summary>
        [DeserializeAs(Name = "stop_timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// Gets or sets whether wheelchair boardings are possible from the specified stop or station. The field can have the following values:
        /// </summary>
        [DeserializeAs(Name = "wheelchair_boarding")]
        public string WheelchairBoarding { get; set; }


        /// <summary>
        /// Custom Property from the AT api, probably in WKB format
        /// </summary>
        [DeserializeAs(Name = "the_geom")]
        public string TheGeometry { get; set; }

        /// <summary>
        /// Returns a description of this trip.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0}] {1} - {2}", this.Id, this.Name, this.Description);
        }

        /// <summary>
        /// Serves as a hash function.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 41;
                hash = hash * 43 + this.Code.GetHashCodeEmptyWhenNull();
                hash = hash * 43 + this.Description.GetHashCodeEmptyWhenNull();
                hash = hash * 43 + this.Id.GetHashCodeEmptyWhenNull();
                hash = hash * 43 + this.Latitude.GetHashCode();
                hash = hash * 43 + this.LocationType.GetHashCode();
                hash = hash * 43 + this.Longitude.GetHashCode();
                hash = hash * 43 + this.Name.GetHashCodeEmptyWhenNull();
                hash = hash * 43 + this.ParentStation.GetHashCodeEmptyWhenNull();
                hash = hash * 43 + this.Timezone.GetHashCodeEmptyWhenNull();
                hash = hash * 43 + this.Url.GetHashCodeEmptyWhenNull();
                hash = hash * 43 + this.WheelchairBoarding.GetHashCodeEmptyWhenNull();
                hash = hash * 43 + this.Zone.GetHashCodeEmptyWhenNull();
                return hash;
            }
        }

        /// <summary>
        /// Returns true if the given object contains the same data.
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = (obj as Stop);
            if (other != null)
            {
                return (this.Code ?? string.Empty) == (other.Code ?? string.Empty) &&
                    (this.Description ?? string.Empty) == (other.Description ?? string.Empty) &&
                    (this.Id ?? string.Empty) == (other.Id ?? string.Empty) &&
                    this.Latitude == other.Latitude &&
                    this.LocationType == other.LocationType &&
                    this.Longitude == other.Longitude &&
                    (this.Name ?? string.Empty) == (other.Name ?? string.Empty) &&
                    (this.ParentStation ?? string.Empty) == (other.ParentStation ?? string.Empty) &&
                    (this.Timezone ?? string.Empty) == (other.Timezone ?? string.Empty) &&
                    (this.Url ?? string.Empty) == (other.Url ?? string.Empty) &&
                    (this.WheelchairBoarding ?? string.Empty) == (other.WheelchairBoarding ?? string.Empty) &&
                    (this.Zone ?? string.Empty) == (other.Zone ?? string.Empty);
            }
            return false;
        }
    }
}