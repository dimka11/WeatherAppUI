using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class PolylineMap
    {
        ///<summary>
        /// The identifier of the map
        ///</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        ///<summary>
        /// The summary polyline of the map
        ///</summary>
        [JsonPropertyName("summary_polyline")]
        public string SummaryPolyline { get; set; }

    }
}
