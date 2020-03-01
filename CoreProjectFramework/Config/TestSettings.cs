using AutoFramework.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoFramework.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("aut")]
        public string AUT { get; set; }

        [JsonProperty("browser")]
        public string browser { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

    }
}
