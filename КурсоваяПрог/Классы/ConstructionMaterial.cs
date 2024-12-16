using Newtonsoft.Json;

public class ConstructionMaterial : Material
{
    [JsonProperty("supplier")]
    public Supplier Supplier { get; set; } // Объект поставщика

    // Свойство для получения имени поставщика
    public string SupplierName => Supplier?.Name;

    // Конструктор по умолчанию для десериализации
    public ConstructionMaterial() { }

    public ConstructionMaterial(string name, string unit, double quantity, double price, double stock, Supplier supplier)
        : base(name, unit, quantity, price, stock)
    {
        Supplier = supplier; // Устанавливаем объект поставщика
    }
}