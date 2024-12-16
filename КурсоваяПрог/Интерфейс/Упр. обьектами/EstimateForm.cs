using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using КурсоваяПрог.Интерфейс.склад;
using КурсоваяПрог.Интерфейс.склад.запасы_стройматериалов;

namespace КурсоваяПрог.Интерфейс.Упр._обьектами
{
    public partial class EstimateForm : Form
    {
        private List<ConstructionObject> constructionObjects; // Список строительных объектов
        private List<Estimate> estimates; // Список смет
        private Estimate currentEstimate; // Текущая смета
        private ConstructionMaterial currentEditingMaterial; // Для хранения редактируемого 
        private DataManager dataManager; // Менеджер данных
        private string dataDirectory; // Путь к директории для сохранения данных

        public EstimateForm(string dataDirectory)
        {
            InitializeComponent();
            this.dataDirectory = dataDirectory;
            dataManager = new DataManager();
            constructionObjects = new List<ConstructionObject>();
            estimates = new List<Estimate>();
            currentEstimate = new Estimate();
            InitializeDataGridViews();
            LoadConstructionObjects();
            LoadEstimates(); // Вызываем метод загрузки смет

            // Подписка на событие изменения выбора
            listBoxConstructionObjects.SelectedIndexChanged += ListBoxConstructionObjects_SelectedIndexChanged;
            buttonSaveEditedMaterial.Click += buttonSaveEditedMaterial_Click; // Подписка на кнопку сохранения изменений
        }


        private void ListBoxConstructionObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxConstructionObjects.SelectedItem is ConstructionObject selectedObject)
            {
                // Обновляем DataGridView для отображения выбранного объекта
                dataGridViewObjects.DataSource = new List<ConstructionObject> { selectedObject };

                // Проверяем, что estimates не равен null и содержит элементы
                if (estimates != null && estimates.Count > 0)
                {
                    // Находим соответствующую смету для выбранного объекта
                    currentEstimate = estimates.FirstOrDefault(est =>
                        est.ConstructionObject != null && // Проверка на null
                        est.ConstructionObject.Name == selectedObject.Name &&
                        est.ConstructionObject.Address == selectedObject.Address);

                    if (currentEstimate != null)
                    {
                        // Обновляем таблицу материалов
                        UpdateMaterialsGrid(currentEstimate.Materials);
                        MessageBox.Show("Смета загружена для выбранного объекта.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Если смета не найдена, предлагаем создать новую
                        var result = MessageBox.Show("Смета для выбранного объекта не найдена. Хотите создать новую смету?", "Информация", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            // Создаем новую смету
                            currentEstimate = new Estimate
                            {
                                ConstructionObject = selectedObject,
                                Materials = new List<ConstructionMaterial>()
                            };
                            UpdateMaterialsGrid(currentEstimate.Materials);
                            MessageBox.Show("Новая смета создана.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            UpdateMaterialsGrid(null);
                        }
                    }
                }
                else
                {
                    // Если смет нет, уведомляем пользователя
                    MessageBox.Show("Сметы еще не добавлены. Пожалуйста, добавьте сметы для выбранных объектов.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateMaterialsGrid(null); // Очищаем таблицу материалов
                }
            }
        }



        private void DataGridViewObjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewObjects.SelectedRows.Count > 0)
            {
                var selectedObject = (ConstructionObject)dataGridViewObjects.SelectedRows[0].DataBoundItem; // Приводим к ConstructionObject

                // Находим соответствующую смету для выбранного объекта
                currentEstimate = estimates.FirstOrDefault(est => est.ConstructionObject.Name == selectedObject.Name && est.ConstructionObject.Address == selectedObject.Address);

                if (currentEstimate != null)
                {
                    // Обновляем таблицу материалов
                    UpdateMaterialsGrid(currentEstimate.Materials);
                }
                else
                {
                    // Если смета не найдена, очищаем таблицу материалов
                    UpdateMaterialsGrid(null);
                }
            }
            else
            {
                currentEstimate = null; // Очистка текущей сметы
                UpdateMaterialsGrid(null); // Обновляем таблицу материалов
            }
        }

        private void InitializeDataGridViews()
        {
            // Настройка DataGridView для объектов
            dataGridViewObjects.AutoGenerateColumns = false;
            dataGridViewObjects.Columns.Clear();
            dataGridViewObjects.Columns.Add(new DataGridViewTextBoxColumn { Name = "ObjectName", HeaderText = "Название объекта", DataPropertyName = "Name" });
            dataGridViewObjects.Columns.Add(new DataGridViewTextBoxColumn { Name = "ObjectAddress", HeaderText = "Адрес объекта", DataPropertyName = "Address" });

            // Настройка DataGridView для материалов
            dataGridViewMaterials.AutoGenerateColumns = false;
            dataGridViewMaterials.Columns.Clear();
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaterialName", HeaderText = "Название материала", DataPropertyName = "Name" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unit", HeaderText = "Единица измерения", DataPropertyName = "Unit" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Требуемое количество", DataPropertyName = "Quantity" });
        }
        private void LoadConstructionObjects()
        {
            var filePath = Path.Combine(dataDirectory, "projects.json");
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                constructionObjects = JsonConvert.DeserializeObject<List<ConstructionObject>>(jsonData);
                if (constructionObjects != null && constructionObjects.Count > 0)
                {
                    // Заполняем ListBox
                    listBoxConstructionObjects.DataSource = constructionObjects;
                    listBoxConstructionObjects.DisplayMember = "Name"; // Отображаем название объекта
                    listBoxConstructionObjects.ValueMember = "Id"; // Или другой уникальный идентификатор

                    // Также заполняем DataGridView
                    dataGridViewObjects.DataSource = constructionObjects; // Установка источника данных для DataGridView
                }
                else
                {
                    MessageBox.Show("Не удалось загрузить строительные объекты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл с проектами не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateMaterialsGrid(IEnumerable<object> materials)
        {
            if (materials != null)
            {
                dataGridViewMaterials.DataSource = materials.ToList(); // Установка нового источника данных
            }
            else
            {
                dataGridViewMaterials.DataSource = null; // Очистка источника данных
            }
        }

        private void LoadEstimates()
        {
            var filePath = Path.Combine(dataDirectory, "estimates.json");
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                estimates = JsonConvert.DeserializeObject<List<Estimate>>(jsonData);
                if (estimates != null && estimates.Count > 0)
                {
                    // Устанавливаем текущую смету, если она существует
                    if (listBoxConstructionObjects.SelectedItem is ConstructionObject selectedObject)
                    {
                        currentEstimate = estimates.FirstOrDefault(est =>
                            est.ConstructionObject != null && // Проверка на null
                            est.ConstructionObject.Name == selectedObject.Name &&
                            est.ConstructionObject.Address == selectedObject.Address);
                    }

                    // Обновляем таблицу материалов для текущей сметы
                    UpdateMaterialsGrid(currentEstimate?.Materials);
                }
                else
                {
                    MessageBox.Show("Не удалось загрузить сметы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл с сметами не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonAddMaterial_Click(object sender, EventArgs e)
        {
            // Проверяем, что currentEstimate не равен null
            if (currentEstimate == null)
            {
                MessageBox.Show("Сначала выберите строительный объект и создайте смету.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Убедитесь, что список материалов инициализирован
            if (currentEstimate.Materials == null)
            {
                currentEstimate.Materials = new List<ConstructionMaterial>();
            }

            // Получаем данные из текстовых полей
            string materialName = textBoxMaterialName.Text.Trim();
            string unit = textBoxUnit.Text.Trim();
            int quantity = (int)numericUpDownQuantity.Value; // Получаем значение из NumericUpDown

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(materialName) || string.IsNullOrEmpty(unit))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на дубликаты
            if (currentEstimate.Materials.Any(m => m.Name.Equals(materialName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Материал с таким названием уже добавлен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем новый материал
            var newMaterial = new ConstructionMaterial
            {
                Name = materialName,
                Unit = unit,
                Quantity = quantity
            };

            // Добавляем новый материал к текущей смете
            currentEstimate.Materials.Add(newMaterial);

            // Обновляем список материалов для отображения
            UpdateMaterialsGrid(currentEstimate.Materials); // Обновляем таблицу материалов
            ClearMaterialInputFields(); // Очищаем текстовые поля

            MessageBox.Show("Материал успешно добавлен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEditMaterial_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaterials.SelectedRows.Count > 0)
            {
                var selectedMaterial = (ConstructionMaterial)dataGridViewMaterials.SelectedRows[0].DataBoundItem;

                // Заполняем поля ввода текущими значениями материала
                textBoxMaterialName.Text = selectedMaterial.Name;
                textBoxUnit.Text = selectedMaterial.Unit;
                numericUpDownQuantity.Value = (decimal)selectedMaterial.Quantity; // Приведение к decimal

                // Сохраняем ссылку на редактируемый материал
                currentEditingMaterial = selectedMaterial; // Добавьте это поле в класс
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите материал для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaterials.SelectedRows.Count > 0)
            {
                var selectedMaterial = (ConstructionMaterial)dataGridViewMaterials.SelectedRows[0].DataBoundItem;
                currentEstimate.Materials.Remove(selectedMaterial); // Удаляем материал из объекта
                UpdateMaterialsGrid(currentEstimate.Materials); // Обновляем таблицу материалов
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите материал для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonSaveEstimate_Click(object sender, EventArgs e)
        {
            if (listBoxConstructionObjects.SelectedItem is ConstructionObject selectedObject)
            {
                // Сохранение сметы в файл
                SaveEstimate(currentEstimate);
                MessageBox.Show("Смета успешно сохранена.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строительный объект.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveEstimate(Estimate estimate)
        {
            var estimates = dataManager.LoadFromFile<List<Estimate>>(Path.Combine(dataDirectory, "estimates.json")) ?? new List<Estimate>();

            // Проверяем, существует ли смета для текущего объекта
            var existingEstimate = estimates.FirstOrDefault(est =>
                est.ConstructionObject != null && // Проверка на null
                est.ConstructionObject.Name == estimate.ConstructionObject.Name &&
                est.ConstructionObject.Address == estimate.ConstructionObject.Address);

            if (existingEstimate != null)
            {
                // Если смета существует, обновляем ее
                existingEstimate.Materials = estimate.Materials;
            }
            else
            {
                // Если смета не существует, добавляем новую
                estimates.Add(estimate);
            }

            var jsonData = JsonConvert.SerializeObject(estimates, Formatting.Indented);
            File.WriteAllText(Path.Combine(dataDirectory, "estimates.json"), jsonData);
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }


        private void ClearMaterialInputFields()
        {
            textBoxMaterialName.Clear();
            textBoxUnit.Clear();
            numericUpDownQuantity.Value = 0; // Сбрасываем значение NumericUpDown
        }

        private void buttonSaveEditedMaterial_Click(object sender, EventArgs e)
        {
            if (currentEditingMaterial != null)
            {
                // Получаем данные из текстовых полей
                string materialName = textBoxMaterialName.Text.Trim();
                string unit = textBoxUnit.Text.Trim();
                int quantity = (int)numericUpDownQuantity.Value; // Получаем значение из NumericUpDown

                // Проверка на пустые поля
                if (string.IsNullOrEmpty(materialName) || string.IsNullOrEmpty(unit))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Обновляем свойства редактируемого материала
                currentEditingMaterial.Name = materialName;
                currentEditingMaterial.Unit = unit;
                currentEditingMaterial.Quantity = quantity;

                // Обновляем данные в DataGridView
                dataGridViewMaterials.Refresh();

                // Сбрасываем текущий редактируемый материал
                currentEditingMaterial = null;

                MessageBox.Show("Материал успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Нет редактируемого материала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
