

using Newtonsoft.Json;

namespace Lottery.Shared.Models
{
    public class Draw
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("drawDate")]
        public string DrawDate { get; set; }

        [JsonProperty("number1")]
        public string Number1 { get; set; }

        [JsonProperty("number2")]
        public string Number2 { get; set; }

        [JsonProperty("number3")]
        public string Number3 { get; set; }

        [JsonProperty("number4")]
        public string Number4 { get; set; }

        [JsonProperty("number5")]
        public string Number5 { get; set; }

        [JsonProperty("number6")]
        public string Number6 { get; set; }

        [JsonProperty("bonus-ball")]
        public string BonusBall { get; set; }

        [JsonProperty("topPrize")]
        public long TopPrize { get; set; }
    }
}
