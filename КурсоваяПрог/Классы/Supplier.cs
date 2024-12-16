using Newtonsoft.Json;

public class Supplier
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("director_name")]
    public string DirectorName { get; set; }

    [JsonProperty("director_phone")]
    public string DirectorPhone { get; set; }

    [JsonProperty("bank")]
    public string Bank { get; set; }

    [JsonProperty("account")]
    public string Account { get; set; }

    [JsonProperty("inn")]
    public string INN { get; set; }
}