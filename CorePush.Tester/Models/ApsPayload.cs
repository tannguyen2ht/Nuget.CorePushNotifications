using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePush.Tester.Models
{
    public class ApsPayload
    {
        [JsonProperty("alert")]
        public Alert AlertBody { get; set; }

        [JsonProperty("apns-push-type")]
        public string PushType { get; set; } = "alert";
    }
}
