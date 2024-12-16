namespace КурсоваяПрог.Интерфейс.Упр._обьектами
{
    partial class RequestForm
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
            this.dataGridViewObjects = new System.Windows.Forms.DataGridView();
            this.обьект = new System.Windows.Forms.Label();
            this.dataGridViewMaterials = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteRequest = new System.Windows.Forms.Button();
            this.dateTimePickerRequestDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMaterialName = new System.Windows.Forms.TextBox();
            this.textBoxMaterialUnit = new System.Windows.Forms.TextBox();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.comboBoxProjects = new System.Windows.Forms.ComboBox();
            this.btnSaveRequest = new System.Windows.Forms.Button();
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.btnEditMaterial = new System.Windows.Forms.Button();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewObjects
            // 
            this.dataGridViewObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObjects.Location = new System.Drawing.Point(12, 35);
            this.dataGridViewObjects.Name = "dataGridViewObjects";
            this.dataGridViewObjects.Size = new System.Drawing.Size(253, 130);
            this.dataGridViewObjects.TabIndex = 0;
            // 
            // обьект
            // 
            this.обьект.AutoSize = true;
            this.обьект.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.обьект.Location = new System.Drawing.Point(103, 16);
            this.обьект.Name = "обьект";
            this.обьект.Size = new System.Drawing.Size(60, 16);
            this.обьект.TabIndex = 1;
            this.обьект.Text = "Обьект";
            // 
            // dataGridViewMaterials
            // 
            this.dataGridViewMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaterials.Location = new System.Drawing.Point(12, 207);
            this.dataGridViewMaterials.Name = "dataGridViewMaterials";
            this.dataGridViewMaterials.Size = new System.Drawing.Size(333, 150);
            this.dataGridViewMaterials.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Перечень заявок на стройматериалы";
            // 
            // btnDeleteRequest
            // 
            this.btnDeleteRequest.Location = new System.Drawing.Point(366, 276);
            this.btnDeleteRequest.Name = "btnDeleteRequest";
            this.btnDeleteRequest.Size = new System.Drawing.Size(131, 59);
            this.btnDeleteRequest.TabIndex = 6;
            this.btnDeleteRequest.Text = "Удалить заявку";
            this.btnDeleteRequest.UseVisualStyleBackColor = true;
            this.btnDeleteRequest.Click += new System.EventHandler(this.btnDeleteRequest_Click);
            // 
            // dateTimePickerRequestDate
            // 
            this.dateTimePickerRequestDate.Location = new System.Drawing.Point(287, 102);
            this.dateTimePickerRequestDate.Name = "dateTimePickerRequestDate";
            this.dateTimePickerRequestDate.Size = new System.Drawing.Size(148, 20);
            this.dateTimePickerRequestDate.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Материал";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Единица измерения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(9, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Количество";
            // 
            // textBoxMaterialName
            // 
            this.textBoxMaterialName.Location = new System.Drawing.Point(134, 372);
            this.textBoxMaterialName.Name = "textBoxMaterialName";
            this.textBoxMaterialName.Size = new System.Drawing.Size(131, 20);
            this.textBoxMaterialName.TabIndex = 13;
            // 
            // textBoxMaterialUnit
            // 
            this.textBoxMaterialUnit.Location = new System.Drawing.Point(134, 410);
            this.textBoxMaterialUnit.Name = "textBoxMaterialUnit";
            this.textBoxMaterialUnit.Size = new System.Drawing.Size(131, 20);
            this.textBoxMaterialUnit.TabIndex = 14;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(134, 445);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(131, 20);
            this.numericUpDownQuantity.TabIndex = 15;
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(288, 364);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(121, 51);
            this.btnAddMaterial.TabIndex = 16;
            this.btnAddMaterial.Text = "Добавить материал";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Location = new System.Drawing.Point(287, 57);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProjects.TabIndex = 19;
            // 
            // btnSaveRequest
            // 
            this.btnSaveRequest.Location = new System.Drawing.Point(366, 207);
            this.btnSaveRequest.Name = "btnSaveRequest";
            this.btnSaveRequest.Size = new System.Drawing.Size(131, 63);
            this.btnSaveRequest.TabIndex = 20;
            this.btnSaveRequest.Text = "Сохранить заявку";
            this.btnSaveRequest.UseVisualStyleBackColor = true;
            this.btnSaveRequest.Click += new System.EventHandler(this.btnSaveRequest_Click);
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.Location = new System.Drawing.Point(426, 427);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(119, 53);
            this.btnDeleteMaterial.TabIndex = 21;
            this.btnDeleteMaterial.Text = "Удалить материал";
            this.btnDeleteMaterial.UseVisualStyleBackColor = true;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.btnDeleteMaterial_Click);
            // 
            // btnEditMaterial
            // 
            this.btnEditMaterial.Location = new System.Drawing.Point(288, 427);
            this.btnEditMaterial.Name = "btnEditMaterial";
            this.btnEditMaterial.Size = new System.Drawing.Size(121, 52);
            this.btnEditMaterial.TabIndex = 22;
            this.btnEditMaterial.Text = "Редактировать материал";
            this.btnEditMaterial.UseVisualStyleBackColor = true;
            this.btnEditMaterial.Click += new System.EventHandler(this.btnEditMaterial_Click_1);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(426, 364);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(119, 51);
            this.btnSaveChanges.TabIndex = 23;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(284, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Выберите обьект";
            // 
            // RequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 494);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.btnEditMaterial);
            this.Controls.Add(this.btnDeleteMaterial);
            this.Controls.Add(this.btnSaveRequest);
            this.Controls.Add(this.comboBoxProjects);
            this.Controls.Add(this.btnAddMaterial);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.textBoxMaterialUnit);
            this.Controls.Add(this.textBoxMaterialName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerRequestDate);
            this.Controls.Add(this.btnDeleteRequest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewMaterials);
            this.Controls.Add(this.обьект);
            this.Controls.Add(this.dataGridViewObjects);
            this.Name = "RequestForm";
            this.Text = "RequestForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewObjects;
        private System.Windows.Forms.Label обьект;
        private System.Windows.Forms.DataGridView dataGridViewMaterials;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteRequest;
        private System.Windows.Forms.DateTimePicker dateTimePickerRequestDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMaterialName;
        private System.Windows.Forms.TextBox textBoxMaterialUnit;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.ComboBox comboBoxProjects;
        private System.Windows.Forms.Button btnSaveRequest;
        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.Button btnEditMaterial;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Label label5;
    }
}