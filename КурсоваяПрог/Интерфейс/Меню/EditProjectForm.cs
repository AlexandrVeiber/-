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


namespace КурсоваяПрог.Интерфейс
{
    public partial class EditProjectForm : Form
    {
        public Project UpdatedProject { get; private set; }
        private DataManager dataManager = new DataManager(); // Создаем экземпляр DataManager
        private const string DataDirectoryPath = "Data"; // Путь к директории для сохранения данных

        public EditProjectForm(Project project)
        {
            InitializeComponent();
            txtName.Text = project.Name;
            txtAddress.Text = project.Address;
            txtStatus.Text = project.Status;
            dateTimePickerStart.Value = project.StartDate; // Установка даты начала
            dateTimePickerEnd.Value = project.EndDate;     // Установка даты окончания
            UpdatedProject = project;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Обновление свойств проекта
            UpdatedProject.Name = txtName.Text;
            UpdatedProject.Address = txtAddress.Text;
            UpdatedProject.Status = txtStatus.Text;
            UpdatedProject.StartDate = dateTimePickerStart.Value; // Обновление даты начала
            UpdatedProject.EndDate = dateTimePickerEnd.Value;     // Обновление даты окончания

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
