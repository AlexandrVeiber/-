using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using КурсоваяПрог.Интерфейс.склад.запасы_стройматериалов;
using КурсоваяПрог.Интерфейс.склад.Поставки;
using КурсоваяПрог.Интерфейс.склад.поставщики;

namespace КурсоваяПрог.Интерфейс.склад
{
    public partial class WarehouseForm : Form
    {
        private List<ConstructionMaterial> materials; // Измените на List<ConstructionMaterial>
        private List<Supplier> suppliers = new List<Supplier>(); // Инициализация пустого списка
        private List<Delivery> deliveries;
        private DataManager dataManager;
        private string dataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data"); // Укажите путь к директории для сохранения данных
        public event Action MaterialsUpdated; // Событие для обновления материалов
        private bool isSaved; // Поле для отслеживания состояния сохранения


        public WarehouseForm()
        {
            InitializeComponent();
            dataManager = new DataManager();
            suppliers = new List<Supplier>(); // Инициализация списка поставщиков
            InitializeData();
            InitializeDataGridViews();
            LoadData(); // Загрузка данных при инициализации формы


            isSaved = false; // Изначально данные не сохранены

        }

        private void InitializeData()
        {
            materials = new List<ConstructionMaterial>(); // Инициализируем как List<ConstructionMaterial>
            suppliers = new List<Supplier>();
            deliveries = new List<Delivery>();
        }

        private void InitializeDataGridViews()
        {
            // Настройка DataGridView для материалов
            dataGridViewMaterials.AutoGenerateColumns = false;
            dataGridViewMaterials.Columns.Clear();
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Название", DataPropertyName = "Name" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unit", HeaderText = "Единица измерения", DataPropertyName = "Unit" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Количество", DataPropertyName = "Quantity" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Закупочная цена", DataPropertyName = "Price" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Stock", HeaderText = "Остаток на складе", DataPropertyName = "Stock" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Supplier", HeaderText = "Поставщик", DataPropertyName = "SupplierName" }); // Изменено на SupplierName
            // Настройка DataGridView для поставщиков
            dataGridViewSuppliers.AutoGenerateColumns = false;
            dataGridViewSuppliers.Columns.Clear();
            dataGridViewSuppliers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Название", DataPropertyName = "Name" });
            dataGridViewSuppliers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", HeaderText = "Адрес", DataPropertyName = "Address" });
            dataGridViewSuppliers.Columns.Add(new DataGridViewTextBoxColumn { Name = "DirectorName", HeaderText = "ФИО руководителя", DataPropertyName = "DirectorName" });
            dataGridViewSuppliers.Columns.Add(new DataGridViewTextBoxColumn { Name = "DirectorPhone", HeaderText = "Телефон", DataPropertyName = "DirectorPhone" });
            dataGridViewSuppliers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Bank", HeaderText = "Банк", DataPropertyName = "Bank" });
            dataGridViewSuppliers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Account", HeaderText = "Расчетный счет", DataPropertyName = "Account" });
            dataGridViewSuppliers.Columns.Add(new DataGridViewTextBoxColumn { Name = "INN", HeaderText = "ИНН", DataPropertyName = "INN" });

            // Настройка DataGridView для поставок
            // Настройка DataGridView для поставок
            dataGridViewDeliveries.AutoGenerateColumns = false;
            dataGridViewDeliveries.Columns.Clear();
            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn { Name = "Supplier", HeaderText = "Поставщик", DataPropertyName = "SupplierName" });
            dataGridViewDeliveries.Columns.Add(new DataGridViewTextBoxColumn { Name = "DeliveryDate", HeaderText = "Дата поставки", DataPropertyName = "DeliveryDate" });

            // Настройка DataGridView для полученных стройматериалов
            dataGridViewDeliveriesMaterials.AutoGenerateColumns = false;
            dataGridViewDeliveriesMaterials.Columns.Clear();
            dataGridViewDeliveriesMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Название", DataPropertyName = "Name" });
            dataGridViewDeliveriesMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unit", HeaderText = "Единица измерения", DataPropertyName = "Unit" });
            dataGridViewDeliveriesMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Количество", DataPropertyName = "Quantity" });
            dataGridViewDeliveriesMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Закупочная цена", DataPropertyName = "Price" });

            // Подключение обработчика события
            dataGridViewDeliveries.SelectionChanged += dataGridViewDeliveries_SelectionChanged;
        }
    


        private void UpdateMaterialDataGridView()
        {
            dataGridViewMaterials.DataSource = null;
            dataGridViewMaterials.DataSource = materials;
        }

       
        private void UpdateSupplierDataGridView()
        {
            dataGridViewSuppliers.DataSource = null;
            dataGridViewSuppliers.DataSource = suppliers;
        }


        private void UpdateDeliveryDataGridView()
        {
            dataGridViewDeliveries.DataSource = null;
            dataGridViewDeliveries.DataSource = deliveries;
        }


        private void LoadData()
        {
            try
            {
                suppliers = dataManager.LoadSuppliers(dataDirectory);
                deliveries = dataManager.LoadDeliveries(dataDirectory);
                materials = dataManager.LoadFromFile<List<ConstructionMaterial>>(Path.Combine(dataDirectory, "materials.json"));

                // Проверка на null
                if (suppliers == null)
                {
                    suppliers = new List<Supplier>(); // Инициализация пустого списка, если загрузка не удалась
                }
                if (deliveries == null)
                {
                    deliveries = new List<Delivery>(); // Инициализация пустого списка, если загрузка не удалась
                }
                if (materials == null)
                {
                    materials = new List<ConstructionMaterial>(); // Инициализация пустого списка, если загрузка не удалась
                }

                // Проверка данных
                foreach (var delivery in deliveries)
                {
                    if (delivery.Supplier == null)
                    {
                        MessageBox.Show("Поставщик не инициализирован в одной из поставок.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                UpdateSupplierDataGridView();
                UpdateDeliveryDataGridView();
                UpdateMaterialDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопки для работы с запасами стройматериалов
        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            using (var form = new AddMaterialForm(suppliers)) // Убираем constructionObjectId
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    materials.Add(form.NewMaterial);
                    UpdateMaterialDataGridView();
                    MaterialsUpdated?.Invoke(); // Вызываем событие обновления
                    dataManager.SaveToFile(Path.Combine(dataDirectory, "materials.json"), materials); // Сохраняем данные материалов
                }
            }
        }

        private void btnEditMaterial_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaterials.SelectedRows.Count > 0)
            {
                var selectedMaterial = (ConstructionMaterial)dataGridViewMaterials.SelectedRows[0].DataBoundItem;

                using (var form = new AddMaterialForm(suppliers, selectedMaterial)) // Убираем constructionObjectId
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var index = materials.IndexOf(selectedMaterial);
                        materials[index] = form.NewMaterial;
                        UpdateMaterialDataGridView();
                        dataManager.SaveToFile(Path.Combine(dataDirectory, "materials.json"), materials); // Сохраняем данные материалов
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите материал для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaterials.SelectedRows.Count > 0)
            {
                var selectedMaterial = (ConstructionMaterial)dataGridViewMaterials.SelectedRows[0].DataBoundItem;
                materials.Remove(selectedMaterial);
                UpdateMaterialDataGridView();
                dataManager.SaveToFile(Path.Combine(dataDirectory, "materials.json"), materials); // Сохраняем данные материалов
            }
        }

        // Кнопки для работы с поставками


        private void btnAddDelivery_Click(object sender, EventArgs e)
        {
            using (var form = new AddDeliveryForm(suppliers))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    deliveries.Add(form.NewDelivery);
                    UpdateDeliveryDataGridView();
                    dataManager.SaveDeliveries(dataDirectory, deliveries); // Сохраняем данные поставок
                }
            }
        }

        private void btnEditDelivery_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeliveries.SelectedRows.Count > 0)
            {
                var selectedDelivery = (Delivery)dataGridViewDeliveries.SelectedRows[0].DataBoundItem;
                using (var form = new AddDeliveryForm(suppliers, selectedDelivery))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var index = deliveries.IndexOf(selectedDelivery);
                        deliveries[index] = form.NewDelivery;
                        UpdateDeliveryDataGridView();
                        dataManager.SaveDeliveries(dataDirectory, deliveries); // Сохраняем данные поставок
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите поставку для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteDelivery_Click(object sender, EventArgs e)
        {
            if (dataGridViewDeliveries.SelectedRows.Count > 0)
            {
                var selectedDelivery = (Delivery)dataGridViewDeliveries.SelectedRows[0].DataBoundItem;
                deliveries.Remove(selectedDelivery);
                UpdateDeliveryDataGridView();
                dataManager.SaveDeliveries(dataDirectory, deliveries); // Сохраняем данные поставок
            }
        }


        private void dataGridViewDeliveries_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDeliveries.SelectedRows.Count > 0)
            {
                var selectedDelivery = (Delivery)dataGridViewDeliveries.SelectedRows[0].DataBoundItem;
                if (selectedDelivery != null)
                {
                    UpdateMaterialsForSelectedDelivery(selectedDelivery);
                }
            }
            else
            {
                dataGridViewDeliveriesMaterials.DataSource = null; // Очистить, если нет выбранной строки
            }
        }

        private void UpdateMaterialsForSelectedDelivery(Delivery selectedDelivery)
        {
            if (selectedDelivery != null && selectedDelivery.ReceivedMaterials != null)
            {
                dataGridViewDeliveriesMaterials.DataSource = null; // Очистить существующие данные
                dataGridViewDeliveriesMaterials.DataSource = selectedDelivery.ReceivedMaterials; // Установить новый источник данных
            }
            else
            {
                dataGridViewDeliveriesMaterials.DataSource = null; // Очистить, если нет материалов
            }
        }


        // Кнопки для работы с поставщиками
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (var form = new AddSupplierForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Проверяем, что NewSupplier не равен null
                    if (form.NewSupplier != null)
                    {
                        suppliers.Add(form.NewSupplier); // Добавляем нового поставщика в список
                        UpdateSupplierDataGridView(); // Обновляем отображение в DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: новый поставщик не был создан.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count > 0)
            {
                var selectedSupplier = (Supplier)dataGridViewSuppliers.SelectedRows[0].DataBoundItem;
                using (var form = new AddSupplierForm(selectedSupplier))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var index = suppliers.IndexOf(selectedSupplier);
                        suppliers[index] = form.NewSupplier;
                        UpdateSupplierDataGridView();
                    }
                }
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            if (dataGridViewSuppliers.SelectedRows.Count > 0)
            {
                var selectedSupplier = (Supplier)dataGridViewSuppliers.SelectedRows[0].DataBoundItem;
                suppliers.Remove(selectedSupplier);
                UpdateSupplierDataGridView();
            }
        }
        // Кнопки для сохранения и загрузки данных
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataManager.SaveSuppliers(dataDirectory, suppliers);
                dataManager.SaveDeliveries(dataDirectory, deliveries); // Сохраняем данные поставок
                dataManager.SaveToFile(Path.Combine(dataDirectory, "materials.json"), materials); // Сохраняем данные материалов
                MessageBox.Show("Данные успешно сохранены.", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSaved = true; // Устанавливаем, что данные сохранены
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Если данные не сохранены, выполняем автоматическое сохранение
            if (!isSaved)
            {
                var result = MessageBox.Show("Данные не сохранены. Вы хотите сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    btnSave.PerformClick(); // Вызываем метод сохранения
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Отменяем закрытие формы
                }
            }
        }

        private void dataGridViewDeliveries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {

        }
    }
}