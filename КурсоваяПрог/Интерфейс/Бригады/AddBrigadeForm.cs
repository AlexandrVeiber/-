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
    public partial class AddBrigadeForm : Form
    {
        public Brigade NewBrigade { get; private set; }
        private List<Brigade> existingBrigades;

        public AddBrigadeForm(List<Brigade> brigades)
        {
            InitializeComponent();
            existingBrigades = brigades;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(txtBrigadeName.Text) || string.IsNullOrWhiteSpace(txtForemanName.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на длину имени бригады
            if (txtBrigadeName.Text.Length < 1 || txtBrigadeName.Text.Length > 50)
            {
                MessageBox.Show("Имя бригады должно содержать от 1 до 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на длину имени руководителя
            if (txtForemanName.Text.Length < 3 || txtForemanName.Text.Length > 50)
            {
                MessageBox.Show("Имя руководителя должно содержать от 3 до 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на существование бригады с таким именем
            if (existingBrigades.Any(b => b.Name.Equals(txtBrigadeName.Text, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Бригада с таким именем уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создание новой бригады
            NewBrigade = new Brigade
            {
                Name = txtBrigadeName.Text,
                Foreman = new Builder
                {
                    FullName = txtForemanName.Text,
                    Gender = "Не указано", // Здесь можно добавить поле для выбора пола
                    BirthDate = DateTime.Now, // Здесь можно добавить поле для ввода даты рождения
                    Address = "Не указан", // Здесь можно добавить поле для ввода адреса
                    Experience = 0, // Здесь можно добавить поле для ввода опыта
                    Specialties = new List<string>() // Здесь можно добавить поле для ввода специальностей
                }
            };

            DialogResult = DialogResult.OK; // Устанавливаем результат диалога
            Close(); // Закрываем форму
        }
    }
}
