namespace КурсоваяПрог.Интерфейс.Упр._обьектами
{
    partial class WorkRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxBrigades = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxWorkType = new System.Windows.Forms.TextBox();
            this.numericUpDownVolume = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewWorkDetails = new System.Windows.Forms.DataGridView();
            this.btnAddWork = new System.Windows.Forms.Button();
            this.btnEditWork = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteWork = new System.Windows.Forms.Button();
            this.dataGridViewWorkRecords = new System.Windows.Forms.DataGridView();
            this.comboBoxProjects = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Location = new System.Drawing.Point(12, 228);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(171, 20);
            this.dateTimePickerDate.TabIndex = 0;
            // 
            // comboBoxBrigades
            // 
            this.comboBoxBrigades.FormattingEnabled = true;
            this.comboBoxBrigades.Location = new System.Drawing.Point(12, 352);
            this.comboBoxBrigades.Name = "comboBoxBrigades";
            this.comboBoxBrigades.Size = new System.Drawing.Size(237, 21);
            this.comboBoxBrigades.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбор бригады";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вид работы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Объем работы";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Дата выполнения работы";
            // 
            // textBoxWorkType
            // 
            this.textBoxWorkType.Location = new System.Drawing.Point(498, 210);
            this.textBoxWorkType.Name = "textBoxWorkType";
            this.textBoxWorkType.Size = new System.Drawing.Size(100, 20);
            this.textBoxWorkType.TabIndex = 6;
            // 
            // numericUpDownVolume
            // 
            this.numericUpDownVolume.Location = new System.Drawing.Point(498, 251);
            this.numericUpDownVolume.Name = "numericUpDownVolume";
            this.numericUpDownVolume.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownVolume.TabIndex = 7;
            // 
            // dataGridViewWorkDetails
            // 
            this.dataGridViewWorkDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkDetails.Location = new System.Drawing.Point(389, 37);
            this.dataGridViewWorkDetails.Name = "dataGridViewWorkDetails";
            this.dataGridViewWorkDetails.Size = new System.Drawing.Size(266, 150);
            this.dataGridViewWorkDetails.TabIndex = 8;
            // 
            // btnAddWork
            // 
            this.btnAddWork.Location = new System.Drawing.Point(391, 283);
            this.btnAddWork.Name = "btnAddWork";
            this.btnAddWork.Size = new System.Drawing.Size(133, 63);
            this.btnAddWork.TabIndex = 9;
            this.btnAddWork.Text = "Добавить работу";
            this.btnAddWork.UseVisualStyleBackColor = true;
            this.btnAddWork.Click += new System.EventHandler(this.btnAddWork_Click);
            // 
            // btnEditWork
            // 
            this.btnEditWork.Location = new System.Drawing.Point(530, 283);
            this.btnEditWork.Name = "btnEditWork";
            this.btnEditWork.Size = new System.Drawing.Size(125, 63);
            this.btnEditWork.TabIndex = 10;
            this.btnEditWork.Text = "Редактировать работу";
            this.btnEditWork.UseVisualStyleBackColor = true;
            this.btnEditWork.Click += new System.EventHandler(this.btnEditWork_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(530, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 62);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteWork
            // 
            this.btnDeleteWork.Location = new System.Drawing.Point(391, 352);
            this.btnDeleteWork.Name = "btnDeleteWork";
            this.btnDeleteWork.Size = new System.Drawing.Size(133, 62);
            this.btnDeleteWork.TabIndex = 11;
            this.btnDeleteWork.Text = "Удалить работу";
            this.btnDeleteWork.UseVisualStyleBackColor = true;
            this.btnDeleteWork.Click += new System.EventHandler(this.btnDeleteWork_Click);
            // 
            // dataGridViewWorkRecords
            // 
            this.dataGridViewWorkRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkRecords.Location = new System.Drawing.Point(12, 37);
            this.dataGridViewWorkRecords.Name = "dataGridViewWorkRecords";
            this.dataGridViewWorkRecords.Size = new System.Drawing.Size(348, 150);
            this.dataGridViewWorkRecords.TabIndex = 12;
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Location = new System.Drawing.Point(12, 285);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(237, 21);
            this.comboBoxProjects.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Выбор обьекта";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(146, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Объект";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(495, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Работы";
            // 
            // WorkRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxProjects);
            this.Controls.Add(this.dataGridViewWorkRecords);
            this.Controls.Add(this.btnDeleteWork);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEditWork);
            this.Controls.Add(this.btnAddWork);
            this.Controls.Add(this.dataGridViewWorkDetails);
            this.Controls.Add(this.numericUpDownVolume);
            this.Controls.Add(this.textBoxWorkType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxBrigades);
            this.Controls.Add(this.dateTimePickerDate);
            this.Name = "WorkRecordForm";
            this.Text = "WorkRecordForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.ComboBox comboBoxBrigades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxWorkType;
        private System.Windows.Forms.NumericUpDown numericUpDownVolume;
        private System.Windows.Forms.DataGridView dataGridViewWorkDetails;
        private System.Windows.Forms.Button btnAddWork;
        private System.Windows.Forms.Button btnEditWork;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleteWork;
        private System.Windows.Forms.DataGridView dataGridViewWorkRecords;
        private System.Windows.Forms.ComboBox comboBoxProjects;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}