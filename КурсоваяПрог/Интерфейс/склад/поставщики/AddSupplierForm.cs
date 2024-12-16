using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КурсоваяПрог.Интерфейс.склад.поставщики
{
    public partial class AddSupplierForm : Form
    {
        public Supplier NewSupplier { get; private set; }

        public AddSupplierForm(Supplier supplier = null)
        {
            InitializeComponent();

            if (supplier != null)
            {
                textBoxName.Text = supplier.Name;
                textBoxAddress.Text = supplier.Address;
                textBoxDirectorName.Text = supplier.DirectorName;
                textBoxDirectorPhone.Text = supplier.DirectorPhone;
                textBoxBank.Text = supplier.Bank;
                textBoxAccount.Text = supplier.Account;
                textBoxINN.Text = supplier.INN;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxDirectorName.Text))
            {
                MessageBox.Show("Пожалуйста, укажите имя директора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidINN(textBoxINN.Text))
            {
                MessageBox.Show("ИНН должен содержать 10 или 12 цифр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidPhoneNumber(textBoxDirectorPhone.Text))
            {
                MessageBox.Show("Номер телефона должен содержать 10 цифр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxBank.Text))
            {
                MessageBox.Show("Пожалуйста, укажите название банка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidAccount(textBoxAccount.Text))
            {
                MessageBox.Show("Номер счета должен содержать 20 цифр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NewSupplier = new Supplier
            {
                Name = textBoxName.Text,
                Address = textBoxAddress.Text,
                DirectorName = textBoxDirectorName.Text,
                DirectorPhone = textBoxDirectorPhone.Text,
                Bank = textBoxBank.Text,
                Account = textBoxAccount.Text,
                INN = textBoxINN.Text
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsValidINN(string inn)
        {
            // Проверка на 10 или 12 цифр
            return Regex.IsMatch(inn, @"^\d{10}$") || Regex.IsMatch(inn, @"^\d{12}$");
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Проверка на 10 цифр
            return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }

        private bool IsValidAccount(string account)
        {
            // Проверка на 20 цифр
            return Regex.IsMatch(account, @"^\d{20}$");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AddSupplierForm_Load(object sender, EventArgs e)
        {

        }
    }
}
