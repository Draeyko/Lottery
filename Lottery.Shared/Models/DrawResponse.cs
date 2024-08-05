using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Shared.Models
{
    public class DrawResponse
    {
        [JsonProperty("draws")]
        public List<Draw> Draws { get; set; }
    }
}
