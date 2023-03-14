using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class UpdatableActivity
    {
        ///<summary>
        /// Whether this activity is a commute
        ///</summary>
        [JsonPropertyName("commute")]
        public bool Commute { get; set; }

        ///<summary>
        /// Whether this activity was recorded on a training machine
        ///</summary>
        [JsonPropertyName("trainer")]
        public bool Trainer { get; set; }

        ///<summary>
        /// Whether this activity is muted
        ///</summary>
        [JsonPropertyName("hide_from_home")]
        public bool HideFromHome { get; set; }

        ///<summary>
        /// The description of the activity
        ///</summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        ///<summary>
        /// The name of the activity
        ///</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        ///<summary>
        /// Identifier for the gear associated with the activity. ‘none’ clears gear from activity
        ///</summary>
        [JsonPropertyName("gear_id")]
        public string GearId { get; set; }

    }
}
