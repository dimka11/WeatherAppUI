﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StravaApp.Model
{
    public class MetaActivity
    {
        ///<summary>
        /// The unique identifier of the activity
        ///</summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

    }
}
