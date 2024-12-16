using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Brigade
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("foreman")]
    public Builder Foreman { get; set; }

    [JsonProperty("workers")]
    public List<Builder> Workers { get; set; }

    [JsonProperty("assigned_project")]
    public Project AssignedProject { get; set; }

    // Новое свойство для хранения даты
    [JsonProperty("date")]
    public DateTime Date { get; set; } // Добавлено свойство для даты

    public Brigade()
    {
        Workers = new List<Builder>();
       Date = DateTime.Now; // Устанавливаем значение по умолчанию на текущее время
    }

    [JsonIgnore]
    public string ForemanName => Foreman?.FullName ?? "Не назначен";

    [JsonIgnore]
    public int WorkerCount => Workers?.Count ?? 0;
}