using Newtonsoft.Json;
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

namespace КурсоваяПрог.Интерфейс.Упр._обьектами
{
    public partial class WorkRecordForm : Form
    {
        private List<Project> projects; // Список проектов
        private DataManager dataManager; // Экземпляр DataManager
        private const string DataDirectoryPath = "Data"; // Путь к директории для сохранения данных

        public WorkRecordForm()
        {
            InitializeComponent();
            dataManager = new DataManager();
            LoadData(); // Загрузка данных при инициализации формы
            InitializeDataGridViews(); // Инициализация DataGridView

            // Загружаем выполненные работы из файла
            if (File.Exists("completedWorks.json"))
            {
                var json = File.ReadAllText("completedWorks.json");
                var completedWorks = JsonConvert.DeserializeObject<List<CompletedWork>>(json);
                dataGridViewWorkRecords.DataSource = completedWorks;

                // Устанавливаем значение DateTimePicker на дату первой работы, если работы есть
                if (completedWorks.Count > 0)
                {
                    dateTimePickerDate.Value = completedWorks[0].Date; // Устанавливаем дату на первую работу
                }
            }

            dateTimePickerDate.ValueChanged += DateTimePickerDate_ValueChanged;
            comboBoxProjects.SelectedIndexChanged += comboBoxProjects_SelectedIndexChanged;
            comboBoxBrigades.SelectedIndexChanged += comboBoxBrigades_SelectedIndexChanged;

            // Подписка на событие закрытия формы
            this.FormClosing += WorkRecordForm_FormClosing;
        }

        private void WorkRecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Получаем список выполненных работ из DataGridView
            var completedWorks = (List<CompletedWork>)dataGridViewWorkRecords.DataSource;

            // Сохраняем выполненные работы в файл
            File.WriteAllText("completedWorks.json", JsonConvert.SerializeObject(completedWorks, Formatting.Indented));
        }

        private void LoadData()
        {
            // Загрузка проектов
            projects = dataManager.LoadFromFile<List<Project>>(Path.Combine(DataDirectoryPath, "projects.json"));

            // Проверка, что проекты загружены
            if (projects == null || projects.Count == 0)
            {
                MessageBox.Show("Нет доступных проектов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Заполнение ComboBox для проектов
            comboBoxProjects.DataSource = projects;
            comboBoxProjects.DisplayMember = "Name";

            // Инициализация комбобокса бригад
            comboBoxBrigades.DataSource = null;
            comboBoxBrigades.Enabled = false;
        }

        private void InitializeDataGridViews()
        {
            // Инициализация первой таблицы
            dataGridViewWorkRecords.AutoGenerateColumns = false; // Отключаем автоматическую генерацию столбцов
            dataGridViewWorkRecords.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "Дата",
                DataPropertyName = "Date"
            });
            dataGridViewWorkRecords.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProjectName",
                HeaderText = "Название проекта",
                DataPropertyName = "ProjectName"
            });
            dataGridViewWorkRecords.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BrigadeName",
                HeaderText = "Название бригады",
                DataPropertyName = "BrigadeName"
            });

            // Инициализация второй таблицы
            dataGridViewWorkDetails.AutoGenerateColumns = false; // Отключаем автоматическую генерацию столбцов
            dataGridViewWorkDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "WorkType",
                HeaderText = "Вид работы",
                DataPropertyName = "WorkType"
            });
            dataGridViewWorkDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Volume",
                HeaderText = "Объем выполненной работы",
                DataPropertyName = "Volume"
            });
        }




        private void comboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProject = (Project)comboBoxProjects.SelectedItem;

            if (selectedProject != null)
            {
                // Проверяем, есть ли бригады у проекта
                if (selectedProject.Brigades != null && selectedProject.Brigades.Any())
                {
                    comboBoxBrigades.DataSource = selectedProject.Brigades;
                    comboBoxBrigades.DisplayMember = "Name";
                    comboBoxBrigades.Enabled = true; // Включаем комбобокс, если есть бригады
                }
                else
                {
                    comboBoxBrigades.DataSource = null; // Очищаем комбобокс, если бригад нет
                    comboBoxBrigades.Enabled = false; // Отключаем комбобокс
                }

                // Очищаем таблицу
                dataGridViewWorkRecords.DataSource = null;
                dataGridViewWorkDetails.DataSource = null; // Очищаем вторую таблицу
            }
        }

        private void comboBoxBrigades_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProject = (Project)comboBoxProjects.SelectedItem;
            var selectedBrigade = (Brigade)comboBoxBrigades.SelectedItem;

            // Устанавливаем значение DateTimePicker на дату выбранной бригады
            if (selectedBrigade != null)
            {
                dateTimePickerDate.Value = selectedBrigade.Date; // Устанавливаем дату
            }

            // Обновляем таблицу работ
            UpdateWorkRecords(selectedProject, selectedBrigade);
        }

        private void DateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            // Обновляем дату в первой строке таблицы работ, если она есть
            if (dataGridViewWorkRecords.Rows.Count > 0)
            {
                dataGridViewWorkRecords.Rows[0].Cells["Date"].Value = dateTimePickerDate.Value;
            }
        }

        private void UpdateWorkRecords(Project selectedProject, Brigade selectedBrigade)
        {
            // Проверяем, что выбранная бригада не равна null
            if (selectedBrigade == null)
            {
                dataGridViewWorkRecords.DataSource = null; // Очищаем таблицу, если нет данных
                dataGridViewWorkDetails.DataSource = null; // Очищаем вторую таблицу
                return;
            }

            // Загружаем все выполненные работы
            var (projects, builders, completedWorks, deliveries, materials, requests) = dataManager.LoadAllData(DataDirectoryPath);

            // Проверяем, что проект найден
            if (selectedProject == null)
            {
                MessageBox.Show($"Проект не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewWorkRecords.DataSource = null; // Очищаем таблицу работ
                dataGridViewWorkDetails.DataSource = null; // Очищаем таблицу деталей работ
                return;
            }

            // Создаем новый объект CompletedWork
            var workRecord = new CompletedWork
            {
                Date = dateTimePickerDate.Value, // Используем значение из DateTimePicker
                ConstructionObject = selectedProject.ConstructionObjects?.FirstOrDefault(), // Предполагается, что у проекта есть объекты
                Brigade = selectedBrigade
            };

            // Устанавливаем источник данных для первой таблицы
            dataGridViewWorkRecords.DataSource = new List<CompletedWork> { workRecord };

            // Загружаем все выполненные работы
            if (completedWorks == null)
            {
                MessageBox.Show("Ошибка загрузки данных о выполненных работах.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewWorkDetails.DataSource = null; // Очищаем таблицу деталей работ
                return;
            }

            // Получаем список работ, связанных с выбранной бригадой
            var workRecords = completedWorks
                .Where(work => work.Brigade.Name == selectedBrigade.Name)
                .ToList();

            // Проверяем, есть ли работы
            if (workRecords.Count == 0)
            {
                dataGridViewWorkDetails.DataSource = null; // Очищаем таблицу деталей работ
                return; // Просто выходим, если работ нет
            }

            // Устанавливаем источник данных для второй таблицы
            dataGridViewWorkDetails.DataSource = workRecords.SelectMany(work => work.WorkDetails).ToList();
        }






        private void btnAddWork_Click(object sender, EventArgs e)
        {
            if (comboBoxProjects.SelectedItem == null || comboBoxBrigades.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите проект и бригаду.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProject = (Project)comboBoxProjects.SelectedItem;
            var selectedBrigade = (Brigade)comboBoxBrigades.SelectedItem;

            // Получаем тип работы и объем
            string workType = textBoxWorkType.Text;
            double volume = (double)numericUpDownVolume.Value;

            // Проверяем, что тип работы не пустой
            if (string.IsNullOrWhiteSpace(workType))
            {
                MessageBox.Show("Пожалуйста, введите тип работы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем объект WorkDetail
            var workDetail = new WorkDetail(workType, volume);

            // Создаем объект CompletedWork
            var completedWork = new CompletedWork
            {
                Date = dateTimePickerDate.Value, // Используем значение из DateTimePicker
                ConstructionObject = selectedProject.ConstructionObjects?.FirstOrDefault(),
                Brigade = selectedBrigade,
                WorkDetails = new List<WorkDetail> { workDetail }
            };

            // Загружаем существующие выполненные работы
            var data = dataManager.LoadAllData(DataDirectoryPath);
            if (data.completedWorks == null)
            {
                data.completedWorks = new List<CompletedWork>();
            }

            // Проверяем на дубликаты
            bool isDuplicate = data.completedWorks.Any(work =>
                work.Date == completedWork.Date &&
                work.Brigade.Name == completedWork.Brigade.Name &&
                work.WorkDetails.Any(detail => detail.WorkType == workDetail.WorkType && detail.Volume == workDetail.Volume));

            if (isDuplicate)
            {
                MessageBox.Show("Эта работа уже была добавлена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Добавляем новую выполненную работу
            data.completedWorks.Add(completedWork);
            dataManager.SaveAllData(DataDirectoryPath, data.projects, null, data.completedWorks, null, null, null);

            // Обновляем дату бригады
            selectedBrigade.Date = dateTimePickerDate.Value;

            UpdateWorkRecords(selectedProject, selectedBrigade);
        }

        private void btnDeleteWork_Click(object sender, EventArgs e)
        {
            if (dataGridViewWorkDetails.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewWorkDetails.SelectedRows[0];
                var workType = (string)selectedRow.Cells["WorkType"].Value;
                var volume = (double)selectedRow.Cells["Volume"].Value;

                // Удаление выполненной работы
                var completedWorks = dataManager.LoadAllData(DataDirectoryPath).completedWorks;
                var workToRemove = completedWorks.FirstOrDefault(work => work.WorkDetails.Any(detail => detail.WorkType == workType && detail.Volume == volume));
                if (workToRemove != null)
                {
                    workToRemove.WorkDetails.Remove(workToRemove.WorkDetails.FirstOrDefault(detail => detail.WorkType == workType && detail.Volume == volume));
                    dataManager.SaveAllData(DataDirectoryPath, projects, null, completedWorks, null, null, null);
                    UpdateWorkRecords((Project)comboBoxProjects.SelectedItem, (Brigade)comboBoxBrigades.SelectedItem); // Обновляем таблицы
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Загружаем существующие выполненные работы
            var data = dataManager.LoadAllData(DataDirectoryPath);
            var completedWorks = data.completedWorks ?? new List<CompletedWork>(); // Инициализируем, если null

            // Проверяем, выбрана ли работа для редактирования
            if (dataGridViewWorkDetails.SelectedRows.Count > 0)
            {
                // Редактирование существующей работы
                var selectedRow = dataGridViewWorkDetails.SelectedRows[0];
                var workType = (string)selectedRow.Cells["WorkType"].Value;
                var volume = (double)selectedRow.Cells["Volume"].Value;

                // Найдите работу для редактирования
                var workToEdit = completedWorks.FirstOrDefault(work => work.WorkDetails.Any(detail => detail.WorkType == workType && detail.Volume == volume));

                if (workToEdit != null)
                {
                    // Обновляем значения работы
                    var workDetail = workToEdit.WorkDetails.FirstOrDefault(detail => detail.WorkType == workType && detail.Volume == volume);
                    if (workDetail != null)
                    {
                        workDetail.WorkType = textBoxWorkType.Text; // Обновляем тип работы
                        workDetail.Volume = (double)numericUpDownVolume.Value; // Обновляем объем работы
                    }

                    // Обновляем дату работы
                    workToEdit.Date = dateTimePickerDate.Value; // Обновляем дату

                    // Сохраняем изменения
                    dataManager.SaveAllData(DataDirectoryPath, data.projects, null, completedWorks, null, null, null);
                    MessageBox.Show("Работа успешно обновлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите работу для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Обновляем таблицу
            UpdateWorkRecords((Project)comboBoxProjects.SelectedItem, (Brigade)comboBoxBrigades.SelectedItem);
        }

        private void btnEditWork_Click(object sender, EventArgs e)
        {
            if (dataGridViewWorkDetails.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewWorkDetails.SelectedRows[0];
                var workType = (string)selectedRow.Cells["WorkType"].Value;
                var volume = (double)selectedRow.Cells["Volume"].Value;

                // Заполняем поля ввода текущими значениями работы
                textBoxWorkType.Text = workType;
                numericUpDownVolume.Value = (decimal)volume;
            }
        }
    }  
}
