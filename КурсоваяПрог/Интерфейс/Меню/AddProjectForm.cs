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
    public partial class AddProjectForm : Form
    {
        public Project NewProject { get; private set; }
        private List<Project> projects = new List<Project>();
        private DataManager dataManager = new DataManager(); // Создаем экземпляр DataManager
        private const string DataDirectoryPath = "Data"; // Путь к директории для сохранения данных
        private List<ConstructionMaterial> materials = new List<ConstructionMaterial>(); // Объявление переменной
        public AddProjectForm()
        {
            InitializeComponent();
            LoadProjectsFromFile(); // Загружаем проекты при инициализации формы
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Проверка ввода
            if (!ValidateInput())
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Прерываем выполнение, если ввод некорректен
            }

            NewProject = new Project
            {
                Id = GenerateNewId(),
                Name = txtName.Text,
                Address = txtAddress.Text,
                Status = txtStatus.Text,
                StartDate = dateTimePickerStart.Value,
                EndDate = dateTimePickerEnd.Value
            };

            // Добавляем новый проект в список
            projects.Add(NewProject);

            // Сохраняем все проекты в файл
            dataManager.SaveAllData(DataDirectoryPath, projects, new List<Builder>(), new List<CompletedWork>(), new List<Delivery>(), materials, new List<Request>()); // Передаем пустой список для requests

            // Уведомляем главную форму о добавлении нового проекта
            (Owner as MainForm)?.LoadProjects(); // Обновляем проекты в главной форме

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateInput()
        {
            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                return false; // Одно из полей пустое
            }

            // Проверка на корректность дат
            if (dateTimePickerStart.Value >= dateTimePickerEnd.Value)
            {
                return false; // Дата начала должна быть раньше даты окончания
            }

            return true; // Все проверки пройдены
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private int GenerateNewId()
        {
            // Генерация нового ID на основе существующих проектов
            if (projects == null || projects.Count == 0)
            {
                return 1; // Если нет проектов, начинаем с 1
            }
            return projects.Max(p => p.Id) + 1; // Увеличиваем максимальный ID на 1
        }

        private void LoadProjectsFromFile()
        {
            if (Directory.Exists(DataDirectoryPath))
            {
                var (loadedProjects, _, _, _, loadedMaterials, loadedRequests) = dataManager.LoadAllData(DataDirectoryPath); // Загружаем проекты и материалы
                projects = loadedProjects ?? new List<Project>(); // Сохраняем загруженные проекты или создаем новый список
                                                                  // materials = loadedMaterials; // Если у вас есть переменная materials, инициализируйте ее здесь
            }
            else
            {
                projects = new List<Project>(); // Если директория не найдена, инициализируем пустой список
            }
        }
    }
}