using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class PhotosSummary
    {
        ///<summary>
        /// The number of photos
        ///</summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

    }
}
