using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class SummaryPRSegmentEffort
    {
        ///<summary>
        /// The unique identifier of the activity related to the PR effort.
        ///</summary>
        [JsonPropertyName("pr_activity_id")]
        public long PrActivityId { get; set; }

        ///<summary>
        /// The elapsed time ot the PR effort.
        ///</summary>
        [JsonPropertyName("pr_elapsed_time")]
        public int PrElapsedTime { get; set; }

        ///<summary>
        /// Number of efforts by the authenticated athlete on this segment.
        ///</summary>
        [JsonPropertyName("effort_count")]
        public int EffortCount { get; set; }

    }
}
