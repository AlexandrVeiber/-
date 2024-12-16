using Newtonsoft.Json;
using System.Collections.Generic;
using System;

public class Builder
{
    private static int nextId = 1; // Статическая переменная для генерации уникальных Id
    [JsonProperty("id")]
    public int Id { get; private set; } // Уникальный идентификатор

    [JsonProperty("full_name")]
    public string FullName { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }

    [JsonProperty("birth_date")]
    public DateTime BirthDate { get; set; }

    [JsonProperty("address")]
    public string Address { get; set; }

    [JsonProperty("experience")]
    public int Experience { get; set; }

    [JsonProperty("specialties")]
    public List<string> Specialties { get; set; }

    [JsonIgnore]
    public Brigade Brigade { get; set; } // Связь с бригадой

    public Builder()
    {
        Id = nextId++; // Присваиваем уникальный Id и увеличиваем его
        Specialties = new List<string>();
    }
}