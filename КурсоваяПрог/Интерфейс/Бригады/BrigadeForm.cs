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

namespace КурсоваяПрог.Интерфейс.Бригады
{
    public partial class BrigadeForm : Form
    {
        private Project project; // Хранит проект, к которому относится бригада
        private Brigade selectedBrigade; // Хранит выбранную бригаду
        private List<Builder> workers; // Хранит список работников
        private List<Project> projects; // Хранит список проектов
        private List<ConstructionMaterial> materials; // Объявление переменной для материалов
        private DataManager dataManager = new DataManager(); // Создаем экземпляр DataManager
        private const string DataDirectoryPath = "Data"; // Путь к директории для сохранения данных
        private ComboBox comboBoxBrigades; // Добавляем поле для ComboBox



        public BrigadeForm(Project project, List<Project> projects)
        {
            InitializeComponent();
            this.project = project;
            this.projects = projects;

            // Загрузка бригад из файла
            project.Brigades = LoadBrigades();

            // Загрузка работников и привязка к бригадам
            workers = LoadWorkers(project.Brigades);

            InitializeDataGridView();
            UpdateWorkerListBox();
            InitializeProjectComboBox(); // Инициализация ComboBox для проектов
            InitializeBrigadeComboBox(); // Инициализация ComboBox для бригад

            UpdateBrigadeDataGridView();
            UpdateBrigadeComboBox(); // Обновляем ComboBox бригад
        }


        private void InitializeProjectComboBox()
        {
            comboBoxProjects = new ComboBox(); // Инициализация ComboBox
            comboBoxProjects.DataSource = projects; // Устанавливаем источник данных
            comboBoxProjects.DisplayMember = "Name"; // Отображаем имя проекта
            comboBoxProjects.SelectedIndexChanged += (s, e) =>
            {
                UpdateBrigadeDataGridView(); // Обновляем таблицу бригад при изменении выбора
                UpdateBrigadeComboBox(); // Обновляем ComboBox бригад при изменении выбора проекта
            };
            Controls.Add(comboBoxProjects); // Добавляем ComboBox на форму
        }


        private void InitializeBrigadeComboBox()
        {
            comboBoxBrigades = new ComboBox(); // Инициализация ComboBox
            comboBoxBrigades.DisplayMember = "Name"; // Отображаем имя бригады
            comboBoxBrigades.SelectedIndexChanged += (s, e) => UpdateSelectedBrigade(); // Обновляем выбранную бригаду при изменении выбора
            Controls.Add(comboBoxBrigades); // Добавляем ComboBox на форму
            comboBoxBrigades.Location = new Point(65, 28); // Установите подходящее расположение
            comboBoxBrigades.Size = new Size(200, 30); // Установите подходящий размер
        }




        private void UpdateBrigadeComboBox()
        {
            if (comboBoxProjects.SelectedItem == null) return; // Проверяем, выбран ли проект

            Project selectedProject = (Project)comboBoxProjects.SelectedItem; // Получаем выбранный проект
            comboBoxBrigades.DataSource = selectedProject.Brigades; // Устанавливаем источник данных для ComboBox
            comboBoxBrigades.SelectedIndex = -1; // Сбрасываем выбор, если нужно
        }


        private void UpdateSelectedBrigade()
        {
            if (comboBoxBrigades.SelectedItem != null)
            {
                selectedBrigade = (Brigade)comboBoxBrigades.SelectedItem; // Сохраняем выбранную бригаду
                UpdateWorkerListBox(); // Обновляем список работников при выборе бригады
                UpdateWorkerDataGridView(); // Обновляем DataGridView работников
            }
        }


        private List<Builder> LoadWorkers(List<Brigade> brigades)
        {
            if (brigades == null)
            {
                throw new ArgumentNullException(nameof(brigades), "Список бригад не может быть null.");
            }

            var (_, builders, _, _, loadedMaterials, loadedRequests) = dataManager.LoadAllData(DataDirectoryPath); // Загружаем работников и материалы

            if (builders == null)
            {
                builders = new List<Builder>(); // Инициализируем, если список равен null
            }

            foreach (var builder in builders)
            {
                // Устанавливаем бригаду для работника
                var brigade = brigades.FirstOrDefault(b => b.Name.Equals(builder.Brigade?.Name, StringComparison.OrdinalIgnoreCase));
                builder.Brigade = brigade;

                // Инициализируем список Workers, если он равен null
                if (brigade != null && brigade.Workers == null)
                {
                    brigade.Workers = new List<Builder>();
                }

                // Добавляем работника в соответствующую бригаду
                brigade?.Workers.Add(builder);
            }
            return builders; // Возвращаем список работников
        }


        private List<Brigade> LoadBrigades()
        {
            // Загружаем бригады для текущего проекта
            return project.Brigades ?? new List<Brigade>(); // Возвращаем пустой список, если бригад нет
        }


        private void SaveBrigadesToFile()
        {
            var allBuilders = project.Brigades.SelectMany(b => b.Workers).ToList(); // Собираем всех строителей из всех бригад
            dataManager.SaveAllData(DataDirectoryPath, new List<Project> { project }, allBuilders, new List<CompletedWork>(), new List<Delivery>(), materials, new List<Request>());
        }



        private void UpdateBrigadeDataGridView()
        {
            if (comboBoxProjects.SelectedItem == null) return; // Проверяем, выбран ли проект

            Project selectedProject = (Project)comboBoxProjects.SelectedItem; // Получаем выбранный проект
            dataGridViewBrigades.DataSource = null; // Сброс источника данных

            var brigadesToDisplay = selectedProject.Brigades.Select(b => new
            {
                BrigadeName = b.Name, // Имя бригады
                ForemanName = b.Foreman != null ? b.Foreman.FullName : "Не указано", // Имя руководителя, если есть
                WorkerCount = b.Workers.Count // Количество работников
            }).ToList();

            dataGridViewBrigades.DataSource = brigadesToDisplay; // Используем анонимный тип для отображения данных

            // Устанавливаем заголовки столбцов
            dataGridViewBrigades.Columns[0].HeaderText = "Имя бригады"; // Имя бригады
            dataGridViewBrigades.Columns[1].HeaderText = "Имя руководителя"; // Имя руководителя
            dataGridViewBrigades.Columns[2].HeaderText = "Количество работников"; // Количество работников

            // Проверка на наличие бригад
            if (brigadesToDisplay.Count == 0)
            {
                MessageBox.Show("Нет доступных бригад для отображения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddBrigade_Click(object sender, EventArgs e)
        {
            if (comboBoxProjects.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите проект.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Project selectedProject = (Project)comboBoxProjects.SelectedItem; // Получаем выбранный проект

            using (AddBrigadeForm addBrigadeForm = new AddBrigadeForm(selectedProject.Brigades))
            {
                if (addBrigadeForm.ShowDialog() == DialogResult.OK)
                {
                    Brigade newBrigade = addBrigadeForm.NewBrigade;
                    newBrigade.AssignedProject = selectedProject; // Привязываем бригаду к выбранному проекту
                    selectedProject.Brigades.Add(newBrigade); // Добавляем бригаду в проект

                    // Сохраняем изменения в файл
                    SaveBrigadesToFile(); // Сохраняем все бригады в файл
                    UpdateBrigadeDataGridView(); // Обновляем отображение бригад
                    UpdateBrigadeComboBox(); // Обновляем ComboBox бригад
                }
            }
        }

        private void btnEditBrigade_Click(object sender, EventArgs e)
        {
            if (comboBoxBrigades.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите бригаду для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Brigade selectedBrigade = (Brigade)comboBoxBrigades.SelectedItem;

            using (EditBrigadeForm editBrigadeForm = new EditBrigadeForm(selectedBrigade))
            {
                if (editBrigadeForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем данные бригады
                    selectedBrigade.Name = editBrigadeForm.UpdatedBrigade.Name;
                    selectedBrigade.Foreman = editBrigadeForm.UpdatedBrigade.Foreman;

                    // Сохраняем изменения в файл
                    SaveBrigadesToFile(); // Сохраняем изменения в файл 
                    UpdateBrigadeDataGridView(); // Обновляем отображение бригад
                    UpdateBrigadeComboBox(); // Обновляем ComboBox бригад
                }
            }
        }

        private void btnDeleteBrigade_Click(object sender, EventArgs e)
        {
            if (dataGridViewBrigades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Сначала выберите бригаду для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Brigade selectedBrigade = (Brigade)dataGridViewBrigades.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show("Вы уверены, что хотите удалить эту бригаду?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // Проверка на наличие работников в бригаде
                    if (selectedBrigade.Workers.Count > 0)
                    {
                        MessageBox.Show("Невозможно удалить бригаду, пока в ней есть работники.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    project.Brigades.Remove(selectedBrigade); // Удаляем бригаду из проекта
                    SaveBrigadesToFile(); // Сохраняем изменения в файл
                    UpdateBrigadeDataGridView(); // Обновляем отображение бригад
                    UpdateBrigadeComboBox(); // Обновляем ComboBox бригад

                    // Сбрасываем выбор в ComboBox
                    comboBoxBrigades.SelectedIndex = -1; // Сбрасываем выбор, если нужно
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении бригады: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






        ////////////////////////////////////////
        // РАБОТНИКИ

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            if (selectedBrigade == null)
            {
                MessageBox.Show("Сначала выберите бригаду.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (AddWorkerForm addWorkerForm = new AddWorkerForm(selectedBrigade))
            {
                if (addWorkerForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновляем список работников
                    UpdateWorkerListBox();
                    UpdateWorkerDataGridView();
                    SaveBrigadesToFile(); // Сохраняем изменения в файл
                }
            }
        }

        private void btnEditWorker_Click(object sender, EventArgs e)
        {
            if (listBoxWorkers.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите работника для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Builder selectedWorker = (Builder)listBoxWorkers.SelectedItem;
            EditWorkerForm editWorkerForm = new EditWorkerForm(selectedWorker);
            if (editWorkerForm.ShowDialog() == DialogResult.OK)
            {
                // Обновляем данные работника
                selectedWorker.FullName = editWorkerForm.UpdatedWorker.FullName;
                selectedWorker.Gender = editWorkerForm.UpdatedWorker.Gender;
                selectedWorker.BirthDate = editWorkerForm.UpdatedWorker.BirthDate;
                selectedWorker.Address = editWorkerForm.UpdatedWorker.Address;
                selectedWorker.Experience = editWorkerForm.UpdatedWorker.Experience;
                selectedWorker.Specialties = editWorkerForm.UpdatedWorker.Specialties;

                UpdateWorkerListBox();
                UpdateWorkerDataGridView();
                SaveBrigadesToFile(); // Сохраняем изменения в файл
            }
        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
            if (selectedBrigade == null)
            {
                MessageBox.Show("Сначала выберите бригаду.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBoxWorkers.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите работника для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Builder selectedWorker = (Builder)listBoxWorkers.SelectedItem;

            if (MessageBox.Show($"Вы уверены, что хотите удалить работника {selectedWorker.FullName}?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                selectedBrigade.Workers.Remove(selectedWorker); // Удаляем работника из бригады
                UpdateWorkerListBox();
                UpdateWorkerDataGridView();
                SaveBrigadesToFile(); // Сохраняем изменения в файл
            }
        }


        private void InitializeDataGridView()
        {
            dataGridViewWorkers.AutoGenerateColumns = false; // Отключаем автоматическую генерацию столбцов

            // Добавляем столбцы в DataGridView
            dataGridViewWorkers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ФИО", DataPropertyName = "FullName" });
            dataGridViewWorkers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Пол", DataPropertyName = "Gender" });
            dataGridViewWorkers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Дата рождения", DataPropertyName = "BirthDate" });
            dataGridViewWorkers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Адрес", DataPropertyName = "Address" });
            dataGridViewWorkers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Опыт", DataPropertyName = "Experience" });
            dataGridViewWorkers.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Специальности", DataPropertyName = "Specialties" });
        }





        private void UpdateWorkerListBox()
        {
            if (selectedBrigade == null)
            {
                listBoxWorkers.DataSource = null; // Сбросить источник данных
                return; // Выход из метода, если бригада не выбрана
            }

            listBoxWorkers.DataSource = selectedBrigade.Workers; // Обновить источник данных
            listBoxWorkers.DisplayMember = "FullName"; // Отображаем ФИО в ListBox
        }

        private void UpdateWorkerDataGridView()
        {
            if (selectedBrigade == null)
            {
                dataGridViewWorkers.DataSource = null; // Сброс источника данных
                return; // Выход из метода, если бригада не выбрана
            }

            var workersToDisplay = selectedBrigade.Workers.Select(w => new
            {
                w.Id,
                w.FullName,
                w.Gender,
                w.BirthDate,
                w.Address,
                w.Experience,
                Specialties = string.Join(", ", w.Specialties) // Преобразуем список специальностей в строку
            }).ToList();

            if (workersToDisplay.Count == 0)
            {
                MessageBox.Show("Нет работников для отображения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridViewWorkers.DataSource = workersToDisplay; // Используем анонимный тип для отображения данных
        }
    }
}
