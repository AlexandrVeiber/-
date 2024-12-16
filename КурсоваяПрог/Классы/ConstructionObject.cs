using Newtonsoft.Json;
using System.Collections.Generic;

public class ConstructionObject
{
    [JsonProperty("id")]
    public int Id { get; set; } // Уникальный идентификатор объекта

    [JsonProperty("name")]
    public string Name { get; set; } // Название строительного объекта

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("materials")]
    public List<ConstructionMaterial> Materials { get; set; } // Список материалов, связанных с объектом

    public ConstructionObject()
    {
        Materials = new List<ConstructionMaterial>();
    }
}