using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КурсоваяПрог.Интерфейс.склад.запасы_стройматериалов
{
    public partial class AddMaterialForm : Form
    {
        public ConstructionMaterial NewMaterial { get; private set; }
        private int constructionObjectId; // Хранение идентификатора строительного объекта

        public AddMaterialForm(List<Supplier> suppliers, ConstructionMaterial material = null)
        {
            InitializeComponent();
            comboBoxSupplier.DataSource = suppliers;
            comboBoxSupplier.DisplayMember = "Name"; // Отображаем имя поставщика

            if (material != null)
            {
                textBoxName.Text = material.Name;
                textBoxUnit.Text = material.Unit;
                numericUpDownQuantity.Value = (decimal)material.Quantity;
                numericUpDownPrice.Value = (decimal)material.Price;
                numericUpDownStock.Value = (decimal)material.Stock;
                comboBoxSupplier.SelectedItem = suppliers.FirstOrDefault(s => s.Id == material.Supplier.Id); // Сравниваем по Id
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Проверка на пустые значения
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxUnit.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedSupplier = (Supplier)comboBoxSupplier.SelectedItem;

            if (selectedSupplier == null)
            {
                MessageBox.Show("Пожалуйста, выберите поставщика.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на допустимые значения для количества, цены и остатка
            if (numericUpDownQuantity.Value <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownPrice.Value < 0)
            {
                MessageBox.Show("Цена не может быть отрицательной.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDownStock.Value < 0)
            {
                MessageBox.Show("Остаток на складе не может быть отрицательным.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NewMaterial = new ConstructionMaterial(
                textBoxName.Text,
                textBoxUnit.Text,
                (double)numericUpDownQuantity.Value,
                (double)numericUpDownPrice.Value,
                (double)numericUpDownStock.Value,
                selectedSupplier // Передаем объект поставщика
            );

            DialogResult = DialogResult.OK;
            Close();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
