﻿// The MIT License (MIT)

// Copyright (c) 2014 Ben Abelshausen

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
using RestSharp.Deserializers;

namespace ATapi_csharp.Entities2
{
    /// <summary>
    /// Represents headway (time between trips) for routes with variable frequency of service.
    /// </summary>
        public class Frequency : GTFSEntity
    {
        /// <summary>
        /// Gets or sets a trip.
        /// </summary>
        [Required]
        [DeserializeAs(Name = "trip_id")]
        public string TripId { get; set; }

        /// <summary>
        /// Gets or sets the time at which service begins with the specified frequency. The time is measured from "noon minus 12h" (effectively midnight, except for days on which daylight savings time changes occur) at the beginning of the service date. For times occurring after midnight, enter the time as a value greater than 24:00:00 in HH:MM:SS local time for the day on which the trip schedule begins. E.g. 25:35:00.
        /// </summary>
        [Required]
        [DeserializeAs(Name = "start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the time at which service changes to a different frequency (or ceases) at the first stop in the trip. The time is measured from "noon minus 12h" (effectively midnight, except for days on which daylight savings time changes occur) at the beginning of the service date. For times occurring after midnight, enter the time as a value greater than 24:00:00 in HH:MM:SS local time for the day on which the trip schedule begins. E.g. 25:35:00.
        /// </summary>
        [Required]
        [DeserializeAs(Name = "end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// Gets or sets the time between departures from the same stop (headway) for this trip type, during the time interval specified by start_time and end_time. The headway value must be entered in seconds.
        /// </summary>
        [Required]
        [DeserializeAs(Name = "headway_secs")]
        public string HeadwaySecs { get; set; }

        /// <summary>
        /// Gets or sets a value that determines if frequency-based trips should be exactly scheduled based on the specified headway information. Valid values for this field are:
        /// </summary>
        [DeserializeAs(Name = "exact_times")]
        public bool? ExactTimes { get; set; }

        /// <summary>
        /// Serves as a hash function.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 37;
                hash = hash * 41 + (this.EndTime ?? string.Empty).GetHashCode();
                hash = hash * 41 + this.ExactTimes.GetHashCode();
                hash = hash * 41 + (this.HeadwaySecs ?? string.Empty).GetHashCode();
                hash = hash * 41 + (this.StartTime ?? string.Empty).GetHashCode();
                hash = hash * 41 + (this.TripId ?? string.Empty).GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Returns true if the given object contains the same data.
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = (obj as Frequency);
            if (other != null)
            {
                return (this.EndTime ?? string.Empty) == (other.EndTime ?? string.Empty) &&
                    this.ExactTimes == other.ExactTimes &&
                    (this.HeadwaySecs ?? string.Empty) == (other.HeadwaySecs ?? string.Empty) &&
                    (this.StartTime ?? string.Empty) == (other.StartTime ?? string.Empty) &&
                    (this.TripId ?? string.Empty) == (other.TripId ?? string.Empty);
            }
            return false;
        }
    }
}