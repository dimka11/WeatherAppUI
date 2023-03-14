using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class DetailedSegmentEffort
    {
        ///<summary>
        /// The unique identifier of this effort
        ///</summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        ///<summary>
        /// The unique identifier of the activity related to this effort
        ///</summary>
        [JsonPropertyName("activity_id")]
        public long ActivityId { get; set; }

        ///<summary>
        /// The effort&#39;s elapsed time
        ///</summary>
        [JsonPropertyName("elapsed_time")]
        public int ElapsedTime { get; set; }

        ///<summary>
        /// The time at which the effort was started.
        ///</summary>
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        ///<summary>
        /// The time at which the effort was started in the local timezone.
        ///</summary>
        [JsonPropertyName("start_date_local")]
        public DateTime StartDateLocal { get; set; }

        ///<summary>
        /// The effort&#39;s distance in meters
        ///</summary>
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        ///<summary>
        /// Whether this effort is the current best on the leaderboard
        ///</summary>
        [JsonPropertyName("is_kom")]
        public bool IsKom { get; set; }

        ///<summary>
        /// The name of the segment on which this effort was performed
        ///</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-MetaActivity">MetaActivity</a>.
        ///</summary>
        [JsonPropertyName("activity")]
        public MetaActivity Activity { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-MetaAthlete">MetaAthlete</a>.
        ///</summary>
        [JsonPropertyName("athlete")]
        public MetaAthlete Athlete { get; set; }

        ///<summary>
        /// The effort&#39;s moving time
        ///</summary>
        [JsonPropertyName("moving_time")]
        public int MovingTime { get; set; }

        ///<summary>
        /// The start index of this effort in its activity&#39;s stream
        ///</summary>
        [JsonPropertyName("start_index")]
        public int StartIndex { get; set; }

        ///<summary>
        /// The end index of this effort in its activity&#39;s stream
        ///</summary>
        [JsonPropertyName("end_index")]
        public int EndIndex { get; set; }

        ///<summary>
        /// The effort&#39;s average cadence
        ///</summary>
        [JsonPropertyName("average_cadence")]
        public float AverageCadence { get; set; }

        ///<summary>
        /// The average wattage of this effort
        ///</summary>
        [JsonPropertyName("average_watts")]
        public float AverageWatts { get; set; }

        ///<summary>
        /// For riding efforts, whether the wattage was reported by a dedicated recording device
        ///</summary>
        [JsonPropertyName("device_watts")]
        public bool DeviceWatts { get; set; }

        ///<summary>
        /// The heart heart rate of the athlete during this effort
        ///</summary>
        [JsonPropertyName("average_heartrate")]
        public float AverageHeartrate { get; set; }

        ///<summary>
        /// The maximum heart rate of the athlete during this effort
        ///</summary>
        [JsonPropertyName("max_heartrate")]
        public float MaxHeartrate { get; set; }

        ///<summary>
        /// An instance of <a href="#api-models-SummarySegment">SummarySegment</a>.
        ///</summary>
        [JsonPropertyName("segment")]
        public SummarySegment Segment { get; set; }

        ///<summary>
        /// The rank of the effort on the global leaderboard if it belongs in the top 10 at the time of upload
        ///</summary>
        [JsonPropertyName("kom_rank")]
        public int KomRank { get; set; }

        ///<summary>
        /// Whether this effort should be hidden when viewed within an activity
        ///</summary>
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

    }
}
