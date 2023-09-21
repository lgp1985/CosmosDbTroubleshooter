using Newtonsoft.Json;

namespace CosmosDbTroubleshooter;

public class PolicyQuoteRequest
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }
}
