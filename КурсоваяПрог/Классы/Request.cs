using Newtonsoft.Json;
using System.Collections.Generic;
using System;

public class Request
{
    [JsonProperty("construction_object_title")]
    public string ConstructionObjectTitle { get; set; }

    [JsonProperty("request_date")]
    public DateTime RequestDate { get; set; }

    [JsonProperty("ordered_materials")]
    public List<ConstructionMaterial> OrderedMaterials { get; set; } // Изменено на ConstructionMaterial

    public Request()
    {
        OrderedMaterials = new List<ConstructionMaterial>();
    }
}