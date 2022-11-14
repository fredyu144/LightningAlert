using Newtonsoft.Json;

namespace DTN_lightning_alert.Data
{
    public class Asset
    {
        [JsonProperty("AssetName")]
        public string Name { get; set; }
        public string QuadKey { get; set; }
        [JsonProperty("AssetOwner")]
        public string Owner { get; set; }
    }
}
