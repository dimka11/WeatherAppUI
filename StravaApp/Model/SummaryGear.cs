using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class SummaryGear
    {
        ///<summary>
        /// The gear&#39;s unique identifier.
        ///</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        ///<summary>
        /// Resource state, indicates level of detail. Possible values: 2 -&gt; &quot;summary&quot;, 3 -&gt; &quot;detail&quot;
        ///</summary>
        [JsonPropertyName("resource_state")]
        public int ResourceState { get; set; }

        ///<summary>
        /// Whether this gear&#39;s is the owner&#39;s default one.
        ///</summary>
        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        ///<summary>
        /// The distance logged with this gear.
        ///</summary>
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

    }
}
