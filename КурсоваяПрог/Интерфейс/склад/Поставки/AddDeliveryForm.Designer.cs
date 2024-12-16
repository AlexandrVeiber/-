namespace КурсоваяПрог.Интерфейс.склад.Поставки
{
    partial class AddDeliveryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewMaterials = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMaterialName = new System.Windows.Forms.TextBox();
            this.textBoxMaterialUnit = new System.Windows.Forms.TextBox();
            this.textBoxMaterialPrice = new System.Windows.Forms.TextBox();
            this.buttonAddMaterial = new System.Windows.Forms.Button();
            this.buttonSaveDelivery = new System.Windows.Forms.Button();
            this.numericUpDownMaterialQuantity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxSuppliers = new System.Windows.Forms.ListBox();
            this.buttonEditMaterial = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaterialQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поставщик";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата поставки";
            // 
            // dateTimePickerDeliveryDate
            // 
            this.dateTimePickerDeliveryDate.Location = new System.Drawing.Point(531, 137);
            this.dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            this.dateTimePickerDeliveryDate.Size = new System.Drawing.Size(203, 20);
            this.dateTimePickerDeliveryDate.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(161, 443);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(129, 59);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataGridViewMaterials
            // 
            this.dataGridViewMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaterials.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewMaterials.Name = "dataGridViewMaterials";
            this.dataGridViewMaterials.Size = new System.Drawing.Size(422, 195);
            this.dataGridViewMaterials.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Материал";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(15, 254);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(109, 13);
            this.label.TabIndex = 12;
            this.label.Text = "Единица измерения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Закупочная цена";
            // 
            // textBoxMaterialName
            // 
            this.textBoxMaterialName.Location = new System.Drawing.Point(136, 217);
            this.textBoxMaterialName.Name = "textBoxMaterialName";
            this.textBoxMaterialName.Size = new System.Drawing.Size(298, 20);
            this.textBoxMaterialName.TabIndex = 14;
            // 
            // textBoxMaterialUnit
            // 
            this.textBoxMaterialUnit.Location = new System.Drawing.Point(136, 251);
            this.textBoxMaterialUnit.Name = "textBoxMaterialUnit";
            this.textBoxMaterialUnit.Size = new System.Drawing.Size(298, 20);
            this.textBoxMaterialUnit.TabIndex = 15;
            // 
            // textBoxMaterialPrice
            // 
            this.textBoxMaterialPrice.Location = new System.Drawing.Point(136, 285);
            this.textBoxMaterialPrice.Name = "textBoxMaterialPrice";
            this.textBoxMaterialPrice.Size = new System.Drawing.Size(298, 20);
            this.textBoxMaterialPrice.TabIndex = 16;
            // 
            // buttonAddMaterial
            // 
            this.buttonAddMaterial.Location = new System.Drawing.Point(12, 356);
            this.buttonAddMaterial.Name = "buttonAddMaterial";
            this.buttonAddMaterial.Size = new System.Drawing.Size(129, 59);
            this.buttonAddMaterial.TabIndex = 17;
            this.buttonAddMaterial.Text = "Добавить материал";
            this.buttonAddMaterial.UseVisualStyleBackColor = true;
            this.buttonAddMaterial.Click += new System.EventHandler(this.buttonAddMaterial_Click);
            // 
            // buttonSaveDelivery
            // 
            this.buttonSaveDelivery.Location = new System.Drawing.Point(161, 356);
            this.buttonSaveDelivery.Name = "buttonSaveDelivery";
            this.buttonSaveDelivery.Size = new System.Drawing.Size(129, 59);
            this.buttonSaveDelivery.TabIndex = 18;
            this.buttonSaveDelivery.Text = "Сохранить поставку";
            this.buttonSaveDelivery.UseVisualStyleBackColor = true;
            this.buttonSaveDelivery.Click += new System.EventHandler(this.buttonSaveDelivery_Click);
            // 
            // numericUpDownMaterialQuantity
            // 
            this.numericUpDownMaterialQuantity.Location = new System.Drawing.Point(136, 322);
            this.numericUpDownMaterialQuantity.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownMaterialQuantity.Name = "numericUpDownMaterialQuantity";
            this.numericUpDownMaterialQuantity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMaterialQuantity.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Кол - во материала";
            // 
            // listBoxSuppliers
            // 
            this.listBoxSuppliers.FormattingEnabled = true;
            this.listBoxSuppliers.Location = new System.Drawing.Point(489, 190);
            this.listBoxSuppliers.Name = "listBoxSuppliers";
            this.listBoxSuppliers.Size = new System.Drawing.Size(195, 108);
            this.listBoxSuppliers.TabIndex = 21;
            // 
            // buttonEditMaterial
            // 
            this.buttonEditMaterial.Location = new System.Drawing.Point(12, 443);
            this.buttonEditMaterial.Name = "buttonEditMaterial";
            this.buttonEditMaterial.Size = new System.Drawing.Size(129, 59);
            this.buttonEditMaterial.TabIndex = 22;
            this.buttonEditMaterial.Text = "Сохранить редактирование";
            this.buttonEditMaterial.UseVisualStyleBackColor = true;
            this.buttonEditMaterial.Click += new System.EventHandler(this.buttonEditMaterial_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Info;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(440, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(301, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Для локального редактрования - редактируйте в таблице";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(440, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Для изменения и добавления даты и поставщика";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Info;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(440, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(278, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Для полного редактирования поставки используйте ";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Info;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(441, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "текстовые поля для ввода";
            // 
            // AddDeliveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(746, 518);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonEditMaterial);
            this.Controls.Add(this.listBoxSuppliers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownMaterialQuantity);
            this.Controls.Add(this.buttonSaveDelivery);
            this.Controls.Add(this.buttonAddMaterial);
            this.Controls.Add(this.textBoxMaterialPrice);
            this.Controls.Add(this.textBoxMaterialUnit);
            this.Controls.Add(this.textBoxMaterialName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewMaterials);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.dateTimePickerDeliveryDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "AddDeliveryForm";
            this.Text = "AddDeliveryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaterialQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeliveryDate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewMaterials;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMaterialName;
        private System.Windows.Forms.TextBox textBoxMaterialUnit;
        private System.Windows.Forms.TextBox textBoxMaterialPrice;
        private System.Windows.Forms.Button buttonAddMaterial;
        private System.Windows.Forms.Button buttonSaveDelivery;
        private System.Windows.Forms.NumericUpDown numericUpDownMaterialQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxSuppliers;
        private System.Windows.Forms.Button buttonEditMaterial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}