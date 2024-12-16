using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class CompletedWork
{
    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("construction_object")]
    public ConstructionObject ConstructionObject { get; set; }

    [JsonProperty("brigade")]
    public Brigade Brigade { get; set; }

    [JsonProperty("work_details")]
    public List<WorkDetail> WorkDetails { get; set; }

    public CompletedWork()
    {
        WorkDetails = new List<WorkDetail>();
    }

    // Свойство для отображения названия проекта
    [JsonIgnore]
    public string ProjectName => ConstructionObject?.Name ?? "Не указан";

    // Свойство для отображения названия бригады
    [JsonIgnore]
    public string BrigadeName => Brigade?.Name ?? "Не указана";


}