using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using КурсоваяПрог.Интерфейс;
using System.IO;
using КурсоваяПрог.Интерфейс.Бригады;
using КурсоваяПрог.Интерфейс.склад;
using КурсоваяПрог.Интерфейс.Упр._обьектами;


namespace КурсоваяПрог
{
    public partial class MainForm : Form
    {
        private List<Request> requests; // Список заявок
        private List<Project> projects = new List<Project>();
        private const string DataDirectoryPath = "Data"; // Путь к директории для сохранения данных
        private DataManager dataManager = new DataManager(); // Создаем экземпляр DataManager
        private List<ConstructionMaterial> materials = new List<ConstructionMaterial>();



        public MainForm()
        {
            InitializeComponent();
            LoadProjects(); // Загружаем проекты из файла при инициализации
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateDataSources();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveProjects(); // Сохраняем проекты перед закрытием формы
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            using (var addProjectForm = new AddProjectForm())
            {
                if (addProjectForm.ShowDialog() == DialogResult.OK)
                {
                    var newProject = addProjectForm.NewProject;
                    projects.Add(newProject);
                    UpdateDataSources();
                }
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedItem != null)
            {
                var selectedProject = listBoxObjects.SelectedItem as Project;

                using (var editProjectForm = new EditProjectForm(selectedProject))
                {
                    if (editProjectForm.ShowDialog() == DialogResult.OK)
                    {
                        // Обновляем проект в списке
                        int selectedIndex = projects.IndexOf(selectedProject);
                        projects[selectedIndex] = editProjectForm.UpdatedProject;

                        // Сохраняем изменения в файл
                        SaveProjects();

                        UpdateDataSources();
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите проект для редактирования.");
            }
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedItem != null)
            {
                var selectedProject = listBoxObjects.SelectedItem as Project;
                projects.Remove(selectedProject); // Удаляем проект из списка
                SaveProjects(); // Сохраняем изменения в файл
                UpdateDataSources(); // Обновляем отображение
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите проект для удаления.");
            }
        }


        public void LoadProjects()
        {
            if (Directory.Exists(DataDirectoryPath))
            {
                var (loadedProjects, loadedBuilders, loadedCompletedWorks, loadedDeliveries, loadedMaterials, loadedRequests) = dataManager.LoadAllData(DataDirectoryPath); // Загружаем проекты и материалы
                projects = loadedProjects; // Убедитесь, что здесь загружаются проекты
                materials = loadedMaterials; // Инициализация переменной materials
                requests = loadedRequests; // Инициализация переменной requests
                UpdateDataSources();
            }
            else
            {
                MessageBox.Show("Директория данных не найдена.");
            }
        }

        private void SaveProjects()
        {
            dataManager.SaveAllData(DataDirectoryPath, projects, new List<Builder>(), new List<CompletedWork>(), new List<Delivery>(), materials, requests); // Сохраняем проекты
        }




        private void dataGridViewProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Получение измененного значения
                var newValue = dataGridViewProjects.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Обновление объекта в списке
                var project = projects[e.RowIndex];
                switch (e.ColumnIndex)
                {
                    case 1: // Название
                        project.Name = newValue.ToString();
                        break;
                    case 2: // Адрес
                        project.Address = newValue.ToString();
                        break;
                    case 3: // Статус
                        project.Status = newValue.ToString();
                        break;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedItem != null)
            {
                var selectedProject = listBoxObjects.SelectedItem as Project;
                if (selectedProject != null)
                {
                    MessageBox.Show($"Вы выбрали: {selectedProject.Name}\nАдрес: {selectedProject.Address}\nСтатус: {selectedProject.Status}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите проект из списка.");
            }
        }
        private void UpdateDataSources()
        {
            dataGridViewProjects.DataSource = null;
            dataGridViewProjects.DataSource = projects;
            listBoxObjects.DataSource = null;
            listBoxObjects.DataSource = projects;
            listBoxObjects.DisplayMember = "Name"; // Укажите, какое свойство отображать

           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void добавитьБригадуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedItem != null)
            {
                var selectedProject = listBoxObjects.SelectedItem as Project;
                using (var brigadeForm = new BrigadeForm(selectedProject, projects)) // Передаем список проектов
                {
                    brigadeForm.ShowDialog(); // Открываем форму для добавления бригады
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите проект, в который хотите добавить бригаду.");
            }
        }

        private void добавитьПоставщикаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void складToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы "Склад"
            WarehouseForm warehouseForm = new WarehouseForm();

            // Открываем форму "Склад"
            warehouseForm.Show(); // Используйте ShowDialog(), если хотите, чтобы форма была модальной
        }

        private void сметаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Убедитесь, что у вас есть путь к директории данных
            string dataDirectory = @"C:\Users\kansvet\source\repos\КурсоваяПрог\КурсоваяПрог\bin\Debug\Data"; // Замените на ваш путь к директории

            // Создание экземпляра формы "Смета"
            EstimateForm estimateForm = new EstimateForm(dataDirectory);

            // Открываем форму "Смета"
            estimateForm.Show(); // Используйте ShowDialog(), если хотите, чтобы форма была модальной
        }

        private void заявкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы "RequestForm"
            RequestForm requestForm = new RequestForm(DataDirectoryPath); // Передаем путь к директории данных

            // Открываем форму "RequestForm"
            requestForm.Show(); // Используйте ShowDialog(), если хотите, чтобы форма была модальной
        }

        private void работыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр формы WorkRecordForm
            WorkRecordForm workRecordForm = new WorkRecordForm();

            // Открываем форму
            workRecordForm.Show(); // Используйте ShowDialog(), если хотите, чтобы форма была модальной
        }
    }
}
