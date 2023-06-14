using System.Text.Json.Serialization;

namespace KelvinBridge.Models
{
    public class BridgeModel
    {
        public string VariantName { get; set; }
        [JsonPropertyName("ra")]
        public double Ra { get; set; }

        [JsonPropertyName("rm")]
        public double Rm { get; set; }

        [JsonPropertyName("rn")]
        public double Rn { get; set; }

        [JsonPropertyName("rMM")]
        public double RM { get; set; }

        [JsonPropertyName("rNN")]
        public double RN { get; set; }

        [JsonPropertyName("rx")]
        public double Rx { get; set; }

        [JsonPropertyName("u")]
        public double U { get; set; }

        [JsonPropertyName("r0x")]
        public double R0x { get; set; }
    }
}
