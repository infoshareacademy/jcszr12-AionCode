using Newtonsoft.Json;

public class Przepisy
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public int Id { get; set; }

    [JsonProperty("kategoria", NullValueHandling = NullValueHandling.Ignore)]
    public string Kategoria { get; set; }

    [JsonProperty("nazwaPotrawy", NullValueHandling = NullValueHandling.Ignore)]
    public string NazwaPotrawy { get; set; }

    [JsonProperty("skladniki", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Skladniki { get; set; }

    [JsonProperty("przepis", NullValueHandling = NullValueHandling.Ignore)]
    public string Przepis { get; set; }
}