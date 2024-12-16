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
    public partial class EditBrigadeForm : Form
    {
        public Brigade UpdatedBrigade { get; private set; } // Добавлено свойство для возвращения обновленной бригады
        private Brigade brigadeToEdit; // Хранит редактируемую бригаду
        public EditBrigadeForm(Brigade brigade)
        {
            InitializeComponent();

            // Проверка на null
            if (brigade == null)
            {
                throw new ArgumentNullException(nameof(brigade), "Бригада не может быть null");
            }

            brigadeToEdit = brigade;

            // Заполнение полей данными бригады
            txtBrigadeName.Text = brigade.Name;

            // Проверка на null для Foreman
            if (brigade.Foreman != null)
            {
                txtForemanName.Text = brigade.Foreman.FullName;
            }
            else
            {
                txtForemanName.Text = string.Empty; // Или можно оставить поле пустым
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(txtBrigadeName.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя бригады.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на длину имени бригады
            if (txtBrigadeName.Text.Length < 3 || txtBrigadeName.Text.Length > 50)
            {
                MessageBox.Show("Имя бригады должно содержать от 3 до 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Обновление данных бригады
            brigadeToEdit.Name = txtBrigadeName.Text;

            // Проверка на null перед обновлением имени руководителя
            if (brigadeToEdit.Foreman != null)
            {
                if (string.IsNullOrWhiteSpace(txtForemanName.Text))
                {
                    MessageBox.Show("Пожалуйста, введите имя руководителя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Выход из метода, если имя руководителя не указано
                }

                // Проверка на длину имени руководителя
                if (txtForemanName.Text.Length < 3 || txtForemanName.Text.Length > 50)
                {
                    MessageBox.Show("Имя руководителя должно содержать от 3 до 50 символов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                brigadeToEdit.Foreman.FullName = txtForemanName.Text;
            }
            else
            {
                // Если Foreman равен null, создаем нового Foreman, если имя руководителя не пустое
                if (!string.IsNullOrWhiteSpace(txtForemanName.Text))
                {
                    brigadeToEdit.Foreman = new Builder { FullName = txtForemanName.Text }; // Предполагается, что Builder имеет свойство FullName
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите имя руководителя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Выход из метода, если имя руководителя не указано
                }
            }

            // Устанавливаем обновленную бригаду
            UpdatedBrigade = brigadeToEdit;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}