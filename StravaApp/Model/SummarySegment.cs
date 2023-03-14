using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class SummarySegment
    {
        ///<summary>
        /// The unique identifier of this segment
        ///</summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        ///<summary>
        /// The name of this segment
        ///</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        ///<summary>
        /// May take one of the following values: <code>Ride</code>, <code>Run</code>
        ///</summary>
        [JsonPropertyName("activity_type")]
        public string ActivityType { get; set; }

        ///<summary>
        /// The segment&#39;s distance, in meters
        ///</summary>
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        ///<summary>
        /// The segment&#39;s average grade, in percents
        ///</summary>
        [JsonPropertyName("average_grade")]
        public float AverageGrade { get; set; }

        ///<summary>
        /// The segments&#39;s maximum grade, in percents
        ///</summary>
        [JsonPropertyName("maximum_grade")]
        public float MaximumGrade { get; set; }

        ///<summary>
        /// The segments&#39;s highest elevation, in meters
        ///</summary>
        [JsonPropertyName("elevation_high")]
        public float ElevationHigh { get; set; }

        ///<summary>
        /// The segments&#39;s lowest elevation, in meters
        ///</summary>
        [JsonPropertyName("elevation_low")]
        public float ElevationLow { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-LatLng">LatLng</a>.
        ///</summary>
        [JsonPropertyName("start_latlng")]
        public double[] StartLatlng { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-LatLng">LatLng</a>.
        ///</summary>
        [JsonPropertyName("end_latlng")]
        public double[] EndLatlng { get; set; }

        ///<summary>
        /// The category of the climb [0, 5]. Higher is harder ie. 5 is Hors catégorie, 0 is uncategorized in climb_category.
        ///</summary>
        [JsonPropertyName("climb_category")]
        public int ClimbCategory { get; set; }

        ///<summary>
        /// The segments&#39;s city.
        ///</summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        ///<summary>
        /// The segments&#39;s state or geographical region.
        ///</summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        ///<summary>
        /// The segment&#39;s country.
        ///</summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        ///<summary>
        /// Whether this segment is private.
        ///</summary>
        [JsonPropertyName("private")]
        public bool Private { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-SummaryPRSegmentEffort">SummaryPRSegmentEffort</a>.
        ///</summary>
        [JsonPropertyName("athlete_segment_stats")]
        public SummaryPRSegmentEffort AthleteSegmentStats { get; set; }

    }
}
