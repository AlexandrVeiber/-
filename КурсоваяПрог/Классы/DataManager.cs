using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public class DataManager
{
    // Метод для инициализации файлов данных
    public void InitializeDataFiles(string directoryPath)
    {
        // Создание директории, если она не существует
        Directory.CreateDirectory(directoryPath);

        // Проверка и создание файлов, если они отсутствуют
        if (!File.Exists(Path.Combine(directoryPath, "projects.json")))
        {
            File.WriteAllText(Path.Combine(directoryPath, "projects.json"), "[]");
        }

        if (!File.Exists(Path.Combine(directoryPath, "builders.json")))
        {
            File.WriteAllText(Path.Combine(directoryPath, "builders.json"), "[]");
        }

        if (!File.Exists(Path.Combine(directoryPath, "completedWorks.json")))
        {
            File.WriteAllText(Path.Combine(directoryPath, "completedWorks.json"), "[]");
        }

        if (!File.Exists(Path.Combine(directoryPath, "deliveries.json")))
        {
            File.WriteAllText(Path.Combine(directoryPath, "deliveries.json"), "[]");
        }

        if (!File.Exists(Path.Combine(directoryPath, "materials.json")))
        {
            File.WriteAllText(Path.Combine(directoryPath, "materials.json"), "[]");
        }

        if (!File.Exists(Path.Combine(directoryPath, "requests.json")))
        {
            File.WriteAllText(Path.Combine(directoryPath, "requests.json"), "[]");
        }
    }

    // Метод для сохранения всех данных в указанной директории
    public void SaveAllData(string directoryPath, List<Project> projects, List<Builder> builders, List<CompletedWork> completedWorks, List<Delivery> deliveries, List<ConstructionMaterial> materials, List<Request> requests)
    {
        InitializeDataFiles(directoryPath); // Инициализация файлов перед сохранением

        SaveToFile(Path.Combine(directoryPath, "projects.json"), projects);
        SaveToFile(Path.Combine(directoryPath, "builders.json"), builders);
        SaveToFile(Path.Combine(directoryPath, "completedWorks.json"), completedWorks);
        SaveToFile(Path.Combine(directoryPath, "deliveries.json"), deliveries);
        SaveToFile(Path.Combine(directoryPath, "materials.json"), materials); // Сохранение материалов
        SaveToFile(Path.Combine(directoryPath, "requests.json"), requests); // Сохранение заявок

    }



    // Метод для загрузки заявок
    public List<Request> LoadRequests(string directoryPath)
    {
        return LoadFromFile<List<Request>>(Path.Combine(directoryPath, "requests.json"));
    }

    // Метод для сохранения поставок
    public void SaveDeliveries(string directoryPath, List<Delivery> deliveries)
    {
        SaveToFile(Path.Combine(directoryPath, "deliveries.json"), deliveries);
    }

    // Метод для загрузки поставок
    public List<Delivery> LoadDeliveries(string directoryPath)
    {
        return LoadFromFile<List<Delivery>>(Path.Combine(directoryPath, "deliveries.json"));
    }

    // Метод для сохранения поставщиков
    public void SaveSuppliers(string directoryPath, List<Supplier> suppliers)
    {
        SaveToFile(Path.Combine(directoryPath, "suppliers.json"), suppliers);
    }

    // Метод для загрузки поставщиков
    public List<Supplier> LoadSuppliers(string directoryPath)
    {
        return LoadFromFile<List<Supplier>>(Path.Combine(directoryPath, "suppliers.json"));
    }

    // Метод для сохранения материалов
    public void SaveMaterials(string directoryPath, List<ConstructionMaterial> materials)
    {
        SaveToFile(Path.Combine(directoryPath, "materials.json"), materials);
    }

    // Метод для загрузки материалов
    public List<ConstructionMaterial> LoadMaterials(string directoryPath)
    {
        return LoadFromFile<List<ConstructionMaterial>>(Path.Combine(directoryPath, "materials.json"));
    }
    // Метод для сохранения данных в файл
    public void SaveToFile<T>(string filePath, T data)
    {
        try
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore // Игнорирование циклических ссылок
            };

            string json = JsonConvert.SerializeObject(data, settings);
            File.WriteAllText(filePath, json); // Запись JSON в файл
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }



    // Метод для загрузки всех данных из указанной директории
    public (List<Project> projects, List<Builder> builders, List<CompletedWork> completedWorks, List<Delivery> deliveries, List<ConstructionMaterial> materials, List<Request> requests) LoadAllData(string directoryPath)
    {
        InitializeDataFiles(directoryPath); // Инициализация файлов перед загрузкой

        var projects = LoadFromFile<List<Project>>(Path.Combine(directoryPath, "projects.json"));
        var builders = LoadFromFile<List<Builder>>(Path.Combine(directoryPath, "builders.json"));
        var completedWorks = LoadFromFile<List<CompletedWork>>(Path.Combine(directoryPath, "completedWorks.json"));
        var deliveries = LoadFromFile<List<Delivery>>(Path.Combine(directoryPath, "deliveries.json"));
        var materials = LoadFromFile<List<ConstructionMaterial>>(Path.Combine(directoryPath, "materials.json")); // Загрузка материалов
        var requests = LoadFromFile<List<Request>>(Path.Combine(directoryPath, "requests.json")); // Загрузка заявок

        return (projects, builders, completedWorks, deliveries, materials, requests);
    }




    // Метод для загрузки данных из файла
    public T LoadFromFile<T>(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json); // Десериализация JSON в объект
        }
        else
        {
            // Если файл не существует, создаем пустой файл
            File.WriteAllText(filePath, "[]");
            return Activator.CreateInstance<T>(); // Возвращаем новый экземпляр типа T
        }
    }
}