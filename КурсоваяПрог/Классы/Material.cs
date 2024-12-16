using Newtonsoft.Json;

public abstract class Material
{
    [JsonProperty("name")]
    public string Name { get; set; } // Название материала

    [JsonProperty("unit")]
    public string Unit { get; set; } // Единица измерения

    [JsonProperty("quantity")]
    public double Quantity { get; set; } // Количество

    [JsonProperty("price")]
    public double Price { get; set; } // Закупочная цена

    [JsonProperty("stock")]
    public double Stock { get; set; } // Остаток на складе

    // Конструктор по умолчанию для десериализации
    protected Material() { }

    protected Material(string name, string unit, double quantity, double price, double stock)
    {
        Name = name;
        Unit = unit;
        Quantity = quantity;
        Price = price;
        Stock = stock; // Остаток на складе
    }
}