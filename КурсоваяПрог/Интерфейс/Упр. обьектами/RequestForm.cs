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

namespace КурсоваяПрог.Интерфейс.Упр._обьектами
{
    public partial class RequestForm : Form
    {
        private List<Project> projects; // Список проектов
        private List<Request> requests; // Список заявок
        private DataManager dataManager; // Менеджер данных
        private string directoryPath; // Путь к директории с данными
        private Request currentRequest; // Текущая заявка


        public RequestForm(string directoryPath)
        {
            InitializeComponent();
            this.directoryPath = directoryPath;
            dataManager = new DataManager();
            LoadProjects();
            requests = dataManager.LoadRequests(directoryPath); // Загружаем существующие заявки
            InitializeDataGridViews(); // Инициализация таблиц
            comboBoxProjects.SelectedIndexChanged += ComboBoxProjects_SelectedIndexChanged; // Подписка на событие
            dateTimePickerRequestDate.ValueChanged += DateTimePickerRequestDate_ValueChanged; // Подписка на событие

        }


        private void DateTimePickerRequestDate_ValueChanged(object sender, EventArgs e)
        {
            if (dataGridViewObjects.Rows.Count > 0)
            {
                // Обновляем дату в первой строке таблицы
                dataGridViewObjects.Rows[0].Cells["RequestDate"].Value = dateTimePickerRequestDate.Value;
            }
        }

        private void ComboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProjects.SelectedItem != null)
            {
                var selectedProjectName = comboBoxProjects.SelectedItem.ToString();
                var selectedProject = projects.FirstOrDefault(p => p.Name == selectedProjectName);

                if (selectedProject != null)
                {
                    // Очищаем таблицы перед добавлением нового проекта
                    dataGridViewObjects.Rows.Clear();
                    dataGridViewMaterials.Rows.Clear(); // Очищаем таблицу материалов

                    // Добавляем выбранный проект в таблицу
                    dataGridViewObjects.Rows.Add(selectedProject.Name, DateTime.Now); // Здесь можно использовать реальную дату заявки, если она известна

                    // Ищем заявки, связанные с выбранным проектом
                    var relatedRequests = requests.Where(r => r.ConstructionObjectTitle == selectedProject.Name).ToList();

                    if (relatedRequests.Count > 0)
                    {
                        // Инициализируем currentRequest первой найденной заявкой
                        currentRequest = relatedRequests.First();

                        // Загружаем материалы в таблицу
                        foreach (var material in currentRequest.OrderedMaterials)
                        {
                            dataGridViewMaterials.Rows.Add(material.Name, material.Unit, material.Quantity);
                        }
                    }
                    else
                    {
                        // Если нет связанных заявок, создаем новую
                        currentRequest = new Request
                        {
                            ConstructionObjectTitle = selectedProject.Name,
                            RequestDate = DateTime.Now,
                            OrderedMaterials = new List<ConstructionMaterial>()
                        };
                    }
                }
            }
        }

        private void LoadMaterialsForSelectedProject(string projectName)
        {
            // Очищаем таблицу материалов
            dataGridViewMaterials.Rows.Clear();

            // Ищем заявки, связанные с выбранным проектом
            var relatedRequests = requests.Where(r => r.ConstructionObjectTitle == projectName).ToList();

            foreach (var request in relatedRequests)
            {
                foreach (var material in request.OrderedMaterials)
                {
                    // Добавляем материалы в таблицу
                    dataGridViewMaterials.Rows.Add(material.Name, material.Unit, material.Quantity);
                }
            }
        }


        private void LoadProjects()
        {
            var filePath = Path.Combine(directoryPath, "projects.json");
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                projects = JsonConvert.DeserializeObject<List<Project>>(jsonData);
                if (projects != null && projects.Count > 0)
                {
                    comboBoxProjects.Items.Clear();
                    foreach (var project in projects)
                    {
                        comboBoxProjects.Items.Add(project.Name); // Добавляем имя проекта в ComboBox
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось загрузить проекты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл с проектами не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitializeDataGridViews()
        {
            // Настройка dataGridViewObjects
            dataGridViewObjects.Columns.Clear(); // Очистка существующих колонок
            dataGridViewObjects.Columns.Add("ConstructionObjectTitle", "Название объекта");
            dataGridViewObjects.Columns.Add("RequestDate", "Дата заявки");

            // Настройка dataGridViewMaterials
            dataGridViewMaterials.Columns.Clear(); // Очистка существующих колонок
            dataGridViewMaterials.Columns.Add("MaterialName", "Название материала");
            dataGridViewMaterials.Columns.Add("MaterialUnit", "Единица измерения");
            dataGridViewMaterials.Columns.Add("MaterialQuantity", "Количество");
        }


       

        private void btnDeleteRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewObjects.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridViewObjects.SelectedRows[0];
                var projectName = selectedRow.Cells["ConstructionObjectTitle"].Value.ToString();

                // Находим заявку, которую нужно удалить
                var requestToRemove = requests.FirstOrDefault(r => r.ConstructionObjectTitle == projectName);
                if (requestToRemove != null)
                {
                    requests.Remove(requestToRemove); // Удаляем заявку из списка
                    dataGridViewObjects.Rows.Remove(selectedRow); // Удаляем строку из таблицы

                    // Очищаем таблицу материалов
                    dataGridViewMaterials.Rows.Clear();
                    currentRequest = null; // Сбрасываем текущую заявку
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите одну заявку для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaterialName.Text) ||
        string.IsNullOrWhiteSpace(textBoxMaterialUnit.Text) ||
        numericUpDownQuantity.Value <= 0)
            {
                MessageBox.Show("Пожалуйста, заполните все поля для материала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var material = new ConstructionMaterial
            {
                Name = textBoxMaterialName.Text,
                Unit = textBoxMaterialUnit.Text,
                Quantity = (double)numericUpDownQuantity.Value
            };

            // Добавляем материал в текущую заявку
            currentRequest.OrderedMaterials.Add(material);

            // Добавляем материал в таблицу
            dataGridViewMaterials.Rows.Add(material.Name, material.Unit, material.Quantity);

            // Очищаем поля ввода
            textBoxMaterialName.Clear();
            textBoxMaterialUnit.Clear();
            numericUpDownQuantity.Value = 0;
        }




        private void ClearForm()
        {
            // Очистка формы после добавления заявки
            dateTimePickerRequestDate.Value = DateTime.Now; // Сброс даты
            dataGridViewObjects.Rows.Clear(); // Очистка таблицы объектов
            dataGridViewMaterials.Rows.Clear(); // Очистка таблицы материалов
            textBoxMaterialName.Clear();
            textBoxMaterialUnit.Clear();
            numericUpDownQuantity.Value = 0;
        }


        private void RequestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Сохраняем все заявки при закрытии формы
            SaveAllRequests();
        }

        private void dateTimePickerRequestDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewMaterials_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewMaterials.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridViewMaterials.SelectedRows[0];

                // Проверяем, есть ли значения в ячейках
                if (selectedRow.Cells["MaterialName"].Value != null &&
                    selectedRow.Cells["MaterialUnit"].Value != null &&
                    selectedRow.Cells["MaterialQuantity"].Value != null)
                {
                    textBoxMaterialName.Text = selectedRow.Cells["MaterialName"].Value.ToString();
                    textBoxMaterialUnit.Text = selectedRow.Cells["MaterialUnit"].Value.ToString();
                    numericUpDownQuantity.Value = Convert.ToDecimal(selectedRow.Cells["MaterialQuantity"].Value);
                }
            }
            else
            {
                // Очищаем текстовые поля, если ничего не выбрано
                textBoxMaterialName.Clear();
                textBoxMaterialUnit.Clear();
                numericUpDownQuantity.Value = 0;
            }
        }

        private void btnSaveRequest_Click(object sender, EventArgs e)
        {
            if (comboBoxProjects.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите проект.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedProjectName = comboBoxProjects.SelectedItem.ToString();
            var selectedProject = projects.FirstOrDefault(p => p.Name == selectedProjectName);

            if (selectedProject != null)
            {
                // Ищем существующую заявку или создаем новую
                currentRequest = requests.FirstOrDefault(r => r.ConstructionObjectTitle == selectedProject.Name) ?? new Request
                {
                    ConstructionObjectTitle = selectedProject.Name,
                    RequestDate = dateTimePickerRequestDate.Value,
                    OrderedMaterials = new List<ConstructionMaterial>()
                };

                // Очищаем предыдущие материалы
                currentRequest.OrderedMaterials.Clear();

                // Добавляем материалы из таблицы
                foreach (DataGridViewRow row in dataGridViewMaterials.Rows)
                {
                    if (row.IsNewRow) continue; // Пропускаем пустую строку
                    var material = new ConstructionMaterial
                    {
                        Name = row.Cells["MaterialName"].Value?.ToString(),
                        Unit = row.Cells["MaterialUnit"].Value?.ToString(),
                        Quantity = Convert.ToDouble(row.Cells["MaterialQuantity"].Value)
                    };
                    currentRequest.OrderedMaterials.Add(material);
                }

                // Если это новая заявка, добавляем ее в список
                if (!requests.Contains(currentRequest))
                {
                    requests.Add(currentRequest);
                }

                // Сохраняем заявку в файл
                SaveRequestToFile(currentRequest);
                ClearForm(); // Очищаем форму после сохранения
            }
        }

        private void SaveRequestToFile(Request request)
        {
            var filePath = Path.Combine(directoryPath, "requests.json");
            List<Request> existingRequests = dataManager.LoadRequests(directoryPath); // Загружаем существующие заявки

            if (existingRequests == null)
            {
                existingRequests = new List<Request>(); // Инициализируем, если загрузка не удалась
            }

            // Проверяем, существует ли уже такая заявка
            var existingRequest = existingRequests.FirstOrDefault(r => r.ConstructionObjectTitle == request.ConstructionObjectTitle);
            if (existingRequest != null)
            {
                // Обновляем существующую заявку
                existingRequest.RequestDate = request.RequestDate;
                existingRequest.OrderedMaterials = request.OrderedMaterials;
            }
            else
            {
                existingRequests.Add(request); // Добавляем новую заявку
            }

            dataManager.SaveAllData(directoryPath, projects, null, null, null, null, existingRequests); // Сохраняем все данные
        }

        private void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaterials.SelectedRows.Count > 0)
            {
                // Список для хранения материалов, которые нужно удалить
                List<ConstructionMaterial> materialsToRemove = new List<ConstructionMaterial>();

                foreach (DataGridViewRow row in dataGridViewMaterials.SelectedRows)
                {
                    // Получаем имя материала из выбранной строки
                    var materialName = row.Cells["MaterialName"].Value.ToString();

                    // Находим материал в текущей заявке
                    var materialToRemove = currentRequest.OrderedMaterials.FirstOrDefault(m => m.Name == materialName);
                    if (materialToRemove != null)
                    {
                        materialsToRemove.Add(materialToRemove); // Добавляем материал в список на удаление
                    }
                }

                // Удаляем материалы из текущей заявки
                foreach (var material in materialsToRemove)
                {
                    currentRequest.OrderedMaterials.Remove(material);
                }

                // Удаляем выбранные строки из таблицы
                foreach (DataGridViewRow row in dataGridViewMaterials.SelectedRows)
                {
                    dataGridViewMaterials.Rows.Remove(row);
                }

                MessageBox.Show("Материалы успешно удалены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите материал для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      

        private void SaveAllRequests()
        {
            dataManager.SaveAllData(directoryPath, projects, null, null, null, null, requests);
        }

        private void btnEditMaterial_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewMaterials.SelectedRows.Count == 1)
            {
                // Проверяем, инициализирован ли currentRequest
                if (currentRequest == null)
                {
                    MessageBox.Show("Текущая заявка не инициализирована.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var selectedRow = dataGridViewMaterials.SelectedRows[0];

                // Проверяем, есть ли значения в ячейках
                if (selectedRow.Cells["MaterialName"].Value == null ||
                    selectedRow.Cells["MaterialUnit"].Value == null ||
                    selectedRow.Cells["MaterialQuantity"].Value == null)
                {
                    MessageBox.Show("Ошибка: выбранный материал содержит недопустимые значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Загружаем данные в текстовые поля для редактирования
                textBoxMaterialName.Text = selectedRow.Cells["MaterialName"].Value.ToString();
                textBoxMaterialUnit.Text = selectedRow.Cells["MaterialUnit"].Value.ToString();
                numericUpDownQuantity.Value = Convert.ToDecimal(selectedRow.Cells["MaterialQuantity"].Value);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите один материал для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaterials.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridViewMaterials.SelectedRows[0];

                // Проверяем, инициализирован ли currentRequest
                if (currentRequest == null)
                {
                    MessageBox.Show("Текущая заявка не инициализирована.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем, есть ли значения в текстовых полях
                if (string.IsNullOrWhiteSpace(textBoxMaterialName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxMaterialUnit.Text) ||
                    numericUpDownQuantity.Value <= 0)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля для материала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Обновляем значения в текущем материале
                var materialToUpdate = currentRequest.OrderedMaterials.FirstOrDefault(m => m.Name == selectedRow.Cells["MaterialName"].Value.ToString());
                if (materialToUpdate != null)
                {
                    materialToUpdate.Name = textBoxMaterialName.Text;
                    materialToUpdate.Unit = textBoxMaterialUnit.Text;
                    materialToUpdate.Quantity = (double)numericUpDownQuantity.Value;

                    // Обновляем значения в таблице
                    selectedRow.Cells["MaterialName"].Value = materialToUpdate.Name;
                    selectedRow.Cells["MaterialUnit"].Value = materialToUpdate.Unit;
                    selectedRow.Cells["MaterialQuantity"].Value = materialToUpdate.Quantity;

                    MessageBox.Show("Материал успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите один материал для сохранения изменений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
