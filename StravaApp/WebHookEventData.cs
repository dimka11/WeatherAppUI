using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaApp
{
    internal class WebHookEventData
    {
        public string object_type { get; set; }
        public long object_id { get; set; }
        public string aspect_type { get; set; }
        public Dictionary<string, string> updates { get; set; }
        public long owner_id { get; set; }
        public int subscription_id { get; set;}
        public long event_time { get; set; }
    }

}
