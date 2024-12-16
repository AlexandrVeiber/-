using Newtonsoft.Json;
using System.Collections.Generic;

public class Estimate
{
    [JsonProperty("construction_object")]
    public ConstructionObject ConstructionObject { get; set; } // Объект строительства

    [JsonProperty("materials")]
    public List<ConstructionMaterial> Materials { get; set; } // Список материалов

    public Estimate()
    {
        Materials = new List<ConstructionMaterial>();
    }
}