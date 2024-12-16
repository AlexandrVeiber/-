using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using КурсоваяПрог.Интерфейс.склад.запасы_стройматериалов;

namespace КурсоваяПрог.Интерфейс.склад.Поставки
{
    public partial class AddDeliveryForm : Form
    {
        private List<ConstructionMaterial> materials;
        public Delivery NewDelivery { get; private set; }

        public AddDeliveryForm(List<Supplier> suppliers, Delivery delivery = null)
        {
            InitializeComponent();
            materials = new List<ConstructionMaterial>();
            LoadSuppliers(suppliers);
            InitializeDataGridView();

            if (delivery != null)
            {
                // Устанавливаем выбранного поставщика
                var selectedSupplier = suppliers.FirstOrDefault(s => s.Name == delivery.Supplier.Name);
                if (selectedSupplier != null)
                {
                    listBoxSuppliers.SelectedItem = selectedSupplier;
                }
                dateTimePickerDeliveryDate.Value = delivery.DeliveryDate;
                materials = delivery.ReceivedMaterials ?? new List<ConstructionMaterial>();
                UpdateMaterialsGrid();
            }
        }

        private void LoadSuppliers(List<Supplier> suppliers)
        {
            listBoxSuppliers.DataSource = suppliers;
            listBoxSuppliers.DisplayMember = "Name";
            listBoxSuppliers.ValueMember = "Id";
        }




        private void InitializeDataGridView()
        {
            dataGridViewMaterials.AutoGenerateColumns = false;
            dataGridViewMaterials.Columns.Clear();
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Название", DataPropertyName = "Name" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unit", HeaderText = "Единица измерения", DataPropertyName = "Unit" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Количество", DataPropertyName = "Quantity" });
            dataGridViewMaterials.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Закупочная цена", DataPropertyName = "Price" });
        }

        private void UpdateMaterialsGrid()
        {
            dataGridViewMaterials.DataSource = null;
            dataGridViewMaterials.DataSource = materials;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSaveDelivery_Click(object sender, EventArgs e)
        {
            if (listBoxSuppliers.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите поставщика.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем новый объект Delivery
            NewDelivery = new Delivery
            {
                Supplier = (Supplier)listBoxSuppliers.SelectedItem, // Получаем объект поставщика
                DeliveryDate = dateTimePickerDeliveryDate.Value,
                ReceivedMaterials = materials // Список полученных материалов
            };

            // Сохранение доставки
            this.DialogResult = DialogResult.OK; // Устанавливаем результат диалога
            this.Close(); // Закрываем форму
        }


        private void buttonAddMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaterialName.Text) || string.IsNullOrWhiteSpace(textBoxMaterialUnit.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля для материала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(textBoxMaterialPrice.Text, out double price))
            {
                MessageBox.Show("Введите корректное значение для цены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownMaterialQuantity.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedSupplier = (Supplier)listBoxSuppliers.SelectedItem; // Получаем объект поставщика

            var material = new ConstructionMaterial
            {
                Supplier = selectedSupplier,
                Name = textBoxMaterialName.Text,
                Unit = textBoxMaterialUnit.Text,
                Quantity = Convert.ToDouble(numericUpDownMaterialQuantity.Value),
                Price = price
            };

            materials.Add(material); // Добав или материал в список
            UpdateMaterialsGrid(); // Обновляем отображение в DataGridView

            // Очистка полей ввода после добавления материала
            ClearMaterialFields();

        }


        private void dataGridViewMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedMaterial = materials[e.RowIndex];
                textBoxMaterialName.Text = selectedMaterial.Name;
                textBoxMaterialUnit.Text = selectedMaterial.Unit;
                numericUpDownMaterialQuantity.Value = (decimal)selectedMaterial.Quantity;
                textBoxMaterialPrice.Text = selectedMaterial.Price.ToString();
            }
        }

        private void ClearMaterialFields()
        {
            textBoxMaterialName.Text = string.Empty;
            textBoxMaterialUnit.Text = string.Empty;
            textBoxMaterialPrice.Text = string.Empty;
            numericUpDownMaterialQuantity.Value = 0; // Сброс количества
        }

        private void buttonEditMaterial_Click(object sender, EventArgs e)
        {
            if (dataGridViewMaterials.SelectedRows.Count > 0)
            {
                var selectedMaterial = (ConstructionMaterial)dataGridViewMaterials.SelectedRows[0].DataBoundItem;

                // Проверка на заполнение полей
                if (string.IsNullOrWhiteSpace(textBoxMaterialName.Text) || string.IsNullOrWhiteSpace(textBoxMaterialUnit.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля для материала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(textBoxMaterialPrice.Text, out double price))
                {
                    MessageBox.Show("Введите корректное значение для цены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numericUpDownMaterialQuantity.Value <= 0)
                {
                    MessageBox.Show("Количество должно быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Обновление выбранного материала
                selectedMaterial.Name = textBoxMaterialName.Text;
                selectedMaterial.Unit = textBoxMaterialUnit.Text;
                selectedMaterial.Quantity = Convert.ToDouble(numericUpDownMaterialQuantity.Value);
                selectedMaterial.Price = price;

                UpdateMaterialsGrid(); // Обновляем отображение в DataGridView
                ClearMaterialFields(); // Очищаем поля ввода
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите материал для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }

}

