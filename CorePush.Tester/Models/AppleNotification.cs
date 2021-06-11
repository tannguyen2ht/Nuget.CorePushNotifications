using System;
using CorePush.Tester.Models;
using Newtonsoft.Json;

namespace CorePush.Tester.Models
{
    public class AppleNotification
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        
        [JsonProperty("aps")]
        public ApsPayload Aps { get; set; }
              
        public AppleNotification(Guid id, string message, string title = "")
        {
            Id = id;

            Aps = new ApsPayload
            {
                AlertBody = new Alert
                {
                    Title = title,
                    Body = message
                }
            };
        }
    }
}