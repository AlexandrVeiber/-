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
    public partial class AddWorkerForm : Form
    {
        public Builder NewWorker { get; private set; }
        private Brigade selectedBrigade; // Поле для хранения выбранной бригады



        public AddWorkerForm(Brigade selectedBrigade)
        {
            InitializeComponent();
            this.selectedBrigade = selectedBrigade; // Сохраняем ссылку на выбранную бригаду
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
            if (gender != "мужской" && gender != "женский" && gender != "не указано")
            {
                MessageBox.Show("Пол должен быть 'мужской', 'женский' или 'не указано'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создание нового работника
            var newWorker = new Builder
            {
                FullName = txtFullName.Text.Trim(),
                Gender = txtGender.Text.Trim(),
                BirthDate = dtpBirthDate.Value,
                Address = txtAddress.Text.Trim(),
                Experience = (int)numExperience.Value,
                Specialties = new List<string>(txtSpecialties.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim())),
                Brigade = selectedBrigade // Устанавливаем бригаду для работника
            };

            // Добавление работника в выбранную бригаду
            selectedBrigade.Workers.Add(newWorker);

            // Закрытие формы с результатом OK
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
