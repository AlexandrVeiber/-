using Newtonsoft.Json;
using System.Collections.Generic;
using System;

public class Delivery
{
    [JsonProperty("supplier")]
    public Supplier Supplier { get; set; } // Объект поставщика

    [JsonProperty("delivery_date")]
    public DateTime DeliveryDate { get; set; } // Дата доставки

    [JsonProperty("received_materials")]
    public List<ConstructionMaterial> ReceivedMaterials { get; set; } // Список полученных материалов

    // Свойство для получения имени поставщика
    public string SupplierName => Supplier?.Name;

    // Конструктор по умолчанию
    public Delivery()
    {
        ReceivedMaterials = new List<ConstructionMaterial>(); // Инициализация списка
    }
}