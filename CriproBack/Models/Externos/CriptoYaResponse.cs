using System.Text.Json.Serialization;

namespace CriproBack.Models.Externos
{
    public class CriptoYaResponse
    {
        [JsonPropertyName("ask")]
        public decimal Ask { get; set; }

        [JsonPropertyName("bid")]
        public decimal Bid { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }
    }
}
