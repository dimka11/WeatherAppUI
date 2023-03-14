using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class Split
    {
        ///<summary>
        /// The average speed of this split, in meters per second
        ///</summary>
        [JsonPropertyName("average_speed")]
        public float AverageSpeed { get; set; }

        ///<summary>
        /// The distance of this split, in meters
        ///</summary>
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        ///<summary>
        /// The elapsed time of this split, in seconds
        ///</summary>
        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        ///<summary>
        /// The elevation difference of this split, in meters
        ///</summary>
        [JsonPropertyName("elevation_difference")]
        public float ElevationDifference { get; set; }

        ///<summary>
        /// The pacing zone of this split
        ///</summary>
        [JsonPropertyName("pace_zone")]
        public int PaceZone { get; set; }

        ///<summary>
        /// N/A
        ///</summary>
        [JsonPropertyName("split")]
        public int SplitNr { get; set; }

    }
}
