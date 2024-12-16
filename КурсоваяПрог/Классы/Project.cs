using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class Project
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("start_date")]
    public DateTime StartDate { get; set; }

    [JsonProperty("end_date")]
    public DateTime EndDate { get; set; }

    [JsonProperty("brigades")]
    public List<Brigade> Brigades { get; set; }

    [JsonProperty("construction_objects")]
    public List<ConstructionObject> ConstructionObjects { get; set; } // Добавлено свойство

    public Project()
    {
        Brigades = new List<Brigade>();
        ConstructionObjects = new List<ConstructionObject>(); // Инициализация
    }
}