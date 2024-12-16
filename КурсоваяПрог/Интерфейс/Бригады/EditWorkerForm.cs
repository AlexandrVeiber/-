using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КурсоваяПрог.Интерфейс.Бригады
{
    public partial class EditWorkerForm : Form
    {
        public Builder UpdatedWorker { get; private set; } // Добавляем свойство для обновленного работника

        public EditWorkerForm(Builder worker)
        {
            InitializeComponent();
            UpdatedWorker = worker; // Сохраняем ссылку на редактируемого работника

            // Заполнение полей данными работника
            txtFullName.Text = worker.FullName;
            txtGender.Text = worker.Gender;
            dtpBirthDate.Value = worker.BirthDate;
            txtAddress.Text = worker.Address;
            numExperience.Value = worker.Experience;
            txtSpecialties.Text = string.Join(", ", worker.Specialties);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка на заполненность обязательных полей
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtGender.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка на длину имени работника
            if (txtFullName.Text.Length < 1 || txtFullName.Text.Length > 50)
            {
                MessageBox.Show("Имя работника должно содержать от 1 до 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на корректность пола
            string gender = txtGender.Text.Trim().ToLower();
            // Проверка на корректность пола
            if (gender != "мужской" && gender != "женский" && gender != "не указано")
            {
                MessageBox.Show("Пол должен быть 'мужской', 'женский' или 'не указано'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Обновление данных работника
            UpdatedWorker.FullName = txtFullName.Text.Trim();
            UpdatedWorker.Gender = txtGender.Text.Trim();
            UpdatedWorker.BirthDate = dtpBirthDate.Value;
            UpdatedWorker.Address = txtAddress.Text.Trim();
            UpdatedWorker.Experience = (int)numExperience.Value;
            UpdatedWorker.Specialties = new List<string>(txtSpecialties.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()));

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
