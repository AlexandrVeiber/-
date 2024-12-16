namespace КурсоваяПрог.Интерфейс.Упр._обьектами
{
    partial class EstimateForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewMaterials = new System.Windows.Forms.DataGridView();
            this.buttonAddMaterial = new System.Windows.Forms.Button();
            this.buttonEditMaterial = new System.Windows.Forms.Button();
            this.buttonDeleteMaterial = new System.Windows.Forms.Button();
            this.buttonSaveEstimate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMaterialName = new System.Windows.Forms.TextBox();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.listBoxConstructionObjects = new System.Windows.Forms.ListBox();
            this.buttonSaveEditedMaterial = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewObjects
            // 
            this.dataGridViewObjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObjects.Location = new System.Drawing.Point(12, 34);
            this.dataGridViewObjects.Name = "dataGridViewObjects";
            this.dataGridViewObjects.Size = new System.Drawing.Size(272, 104);
            this.dataGridViewObjects.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(104, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Объекты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(95, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Материалы";
            // 
            // dataGridViewMaterials
            // 
            this.dataGridViewMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaterials.Location = new System.Drawing.Point(12, 175);
            this.dataGridViewMaterials.Name = "dataGridViewMaterials";
            this.dataGridViewMaterials.Size = new System.Drawing.Size(348, 150);
            this.dataGridViewMaterials.TabIndex = 3;
            // 
            // buttonAddMaterial
            // 
            this.buttonAddMaterial.Location = new System.Drawing.Point(285, 338);
            this.buttonAddMaterial.Name = "buttonAddMaterial";
            this.buttonAddMaterial.Size = new System.Drawing.Size(114, 49);
            this.buttonAddMaterial.TabIndex = 4;
            this.buttonAddMaterial.Text = "Добавить материал";
            this.buttonAddMaterial.UseVisualStyleBackColor = true;
            this.buttonAddMaterial.Click += new System.EventHandler(this.buttonAddMaterial_Click);
            // 
            // buttonEditMaterial
            // 
            this.buttonEditMaterial.Location = new System.Drawing.Point(285, 393);
            this.buttonEditMaterial.Name = "buttonEditMaterial";
            this.buttonEditMaterial.Size = new System.Drawing.Size(114, 45);
            this.buttonEditMaterial.TabIndex = 5;
            this.buttonEditMaterial.Text = "Редактировать материал";
            this.buttonEditMaterial.UseVisualStyleBackColor = true;
            this.buttonEditMaterial.Click += new System.EventHandler(this.buttonEditMaterial_Click);
            // 
            // buttonDeleteMaterial
            // 
            this.buttonDeleteMaterial.Location = new System.Drawing.Point(405, 393);
            this.buttonDeleteMaterial.Name = "buttonDeleteMaterial";
            this.buttonDeleteMaterial.Size = new System.Drawing.Size(106, 45);
            this.buttonDeleteMaterial.TabIndex = 6;
            this.buttonDeleteMaterial.Text = "Удалить материал";
            this.buttonDeleteMaterial.UseVisualStyleBackColor = true;
            this.buttonDeleteMaterial.Click += new System.EventHandler(this.buttonDeleteMaterial_Click);
            // 
            // buttonSaveEstimate
            // 
            this.buttonSaveEstimate.Location = new System.Drawing.Point(381, 183);
            this.buttonSaveEstimate.Name = "buttonSaveEstimate";
            this.buttonSaveEstimate.Size = new System.Drawing.Size(120, 63);
            this.buttonSaveEstimate.TabIndex = 7;
            this.buttonSaveEstimate.Text = "Сохранить смету";
            this.buttonSaveEstimate.UseVisualStyleBackColor = true;
            this.buttonSaveEstimate.Click += new System.EventHandler(this.buttonSaveEstimate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(381, 252);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(122, 58);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Материал";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Единица измерения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Количество";
            // 
            // textBoxMaterialName
            // 
            this.textBoxMaterialName.Location = new System.Drawing.Point(139, 347);
            this.textBoxMaterialName.Name = "textBoxMaterialName";
            this.textBoxMaterialName.Size = new System.Drawing.Size(124, 20);
            this.textBoxMaterialName.TabIndex = 12;
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(139, 381);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(124, 20);
            this.textBoxUnit.TabIndex = 13;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(139, 416);
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(124, 20);
            this.numericUpDownQuantity.TabIndex = 14;
            // 
            // listBoxConstructionObjects
            // 
            this.listBoxConstructionObjects.FormattingEnabled = true;
            this.listBoxConstructionObjects.Location = new System.Drawing.Point(306, 53);
            this.listBoxConstructionObjects.Name = "listBoxConstructionObjects";
            this.listBoxConstructionObjects.Size = new System.Drawing.Size(195, 69);
            this.listBoxConstructionObjects.TabIndex = 15;
            // 
            // buttonSaveEditedMaterial
            // 
            this.buttonSaveEditedMaterial.Location = new System.Drawing.Point(405, 338);
            this.buttonSaveEditedMaterial.Name = "buttonSaveEditedMaterial";
            this.buttonSaveEditedMaterial.Size = new System.Drawing.Size(106, 49);
            this.buttonSaveEditedMaterial.TabIndex = 16;
            this.buttonSaveEditedMaterial.Text = "Сохранить изменения";
            this.buttonSaveEditedMaterial.UseVisualStyleBackColor = true;
            this.buttonSaveEditedMaterial.Click += new System.EventHandler(this.buttonSaveEditedMaterial_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(334, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Выберите объект";
            // 
            // EstimateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonSaveEditedMaterial);
            this.Controls.Add(this.listBoxConstructionObjects);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.textBoxUnit);
            this.Controls.Add(this.textBoxMaterialName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveEstimate);
            this.Controls.Add(this.buttonDeleteMaterial);
            this.Controls.Add(this.buttonEditMaterial);
            this.Controls.Add(this.buttonAddMaterial);
            this.Controls.Add(this.dataGridViewMaterials);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewObjects);
            this.Name = "EstimateForm";
            this.Text = "EstimateForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewObjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewMaterials;
        private System.Windows.Forms.Button buttonAddMaterial;
        private System.Windows.Forms.Button buttonEditMaterial;
        private System.Windows.Forms.Button buttonDeleteMaterial;
        private System.Windows.Forms.Button buttonSaveEstimate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMaterialName;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.ListBox listBoxConstructionObjects;
        private System.Windows.Forms.Button buttonSaveEditedMaterial;
        private System.Windows.Forms.Label label6;
    }
}