using Newtonsoft.Json;

public class WorkDetail
{
    [JsonProperty("work_type")]
    public string WorkType { get; set; } // Тип работы

    [JsonProperty("volume")]
    public double Volume { get; set; }    // Объем работы

    public WorkDetail(string workType, double volume)
    {
        WorkType = workType;
        Volume = volume;
    }
}