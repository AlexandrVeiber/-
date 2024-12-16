namespace КурсоваяПрог.Интерфейс.склад
{
    partial class WarehouseForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewMaterials = new System.Windows.Forms.DataGridView();
            this.dataGridViewSuppliers = new System.Windows.Forms.DataGridView();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.btnEditMaterial = new System.Windows.Forms.Button();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnEditSupplier = new System.Windows.Forms.Button();
            this.btnDeleteSupplier = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewDeliveries = new System.Windows.Forms.DataGridView();
            this.btnDeleteDelivery = new System.Windows.Forms.Button();
            this.btnEditDelivery = new System.Windows.Forms.Button();
            this.btnAddDelivery = new System.Windows.Forms.Button();
            this.dataGridViewDeliveriesMaterials = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeliveries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeliveriesMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(236, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Таблица запасов стройматриалов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(303, 538);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Таблицы поставок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(294, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Таблица Поставщиков";
            // 
            // dataGridViewMaterials
            // 
            this.dataGridViewMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaterials.Location = new System.Drawing.Point(12, 101);
            this.dataGridViewMaterials.Name = "dataGridViewMaterials";
            this.dataGridViewMaterials.Size = new System.Drawing.Size(751, 184);
            this.dataGridViewMaterials.TabIndex = 3;
            // 
            // dataGridViewSuppliers
            // 
            this.dataGridViewSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSuppliers.Location = new System.Drawing.Point(12, 328);
            this.dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            this.dataGridViewSuppliers.Size = new System.Drawing.Size(751, 182);
            this.dataGridViewSuppliers.TabIndex = 4;
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(789, 101);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(137, 55);
            this.btnAddMaterial.TabIndex = 5;
            this.btnAddMaterial.Text = "Добавить материал";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.Location = new System.Drawing.Point(789, 229);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(137, 56);
            this.btnDeleteMaterial.TabIndex = 6;
            this.btnDeleteMaterial.Text = "Удалить материал";
            this.btnDeleteMaterial.UseVisualStyleBackColor = true;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.btnDeleteMaterial_Click);
            // 
            // btnEditMaterial
            // 
            this.btnEditMaterial.Location = new System.Drawing.Point(789, 162);
            this.btnEditMaterial.Name = "btnEditMaterial";
            this.btnEditMaterial.Size = new System.Drawing.Size(137, 61);
            this.btnEditMaterial.TabIndex = 6;
            this.btnEditMaterial.Text = "Редактировать материал";
            this.btnEditMaterial.UseVisualStyleBackColor = true;
            this.btnEditMaterial.Click += new System.EventHandler(this.btnEditMaterial_Click);
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Location = new System.Drawing.Point(789, 330);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(137, 55);
            this.btnAddSupplier.TabIndex = 7;
            this.btnAddSupplier.Text = "Добавить поставщика";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // btnEditSupplier
            // 
            this.btnEditSupplier.Location = new System.Drawing.Point(789, 391);
            this.btnEditSupplier.Name = "btnEditSupplier";
            this.btnEditSupplier.Size = new System.Drawing.Size(137, 53);
            this.btnEditSupplier.TabIndex = 8;
            this.btnEditSupplier.Text = "Редактировать поставщика";
            this.btnEditSupplier.UseVisualStyleBackColor = true;
            this.btnEditSupplier.Click += new System.EventHandler(this.btnEditSupplier_Click);
            // 
            // btnDeleteSupplier
            // 
            this.btnDeleteSupplier.Location = new System.Drawing.Point(789, 450);
            this.btnDeleteSupplier.Name = "btnDeleteSupplier";
            this.btnDeleteSupplier.Size = new System.Drawing.Size(137, 60);
            this.btnDeleteSupplier.TabIndex = 9;
            this.btnDeleteSupplier.Text = "Удалить поставщика";
            this.btnDeleteSupplier.UseVisualStyleBackColor = true;
            this.btnDeleteSupplier.Click += new System.EventHandler(this.btnDeleteSupplier_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(962, 391);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 93);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridViewDeliveries
            // 
            this.dataGridViewDeliveries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeliveries.Location = new System.Drawing.Point(12, 564);
            this.dataGridViewDeliveries.Name = "dataGridViewDeliveries";
            this.dataGridViewDeliveries.Size = new System.Drawing.Size(266, 163);
            this.dataGridViewDeliveries.TabIndex = 13;
            this.dataGridViewDeliveries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDeliveries_CellContentClick);
            // 
            // btnDeleteDelivery
            // 
            this.btnDeleteDelivery.Location = new System.Drawing.Point(789, 681);
            this.btnDeleteDelivery.Name = "btnDeleteDelivery";
            this.btnDeleteDelivery.Size = new System.Drawing.Size(137, 46);
            this.btnDeleteDelivery.TabIndex = 16;
            this.btnDeleteDelivery.Text = "Удалить поставку";
            this.btnDeleteDelivery.UseVisualStyleBackColor = true;
            this.btnDeleteDelivery.Click += new System.EventHandler(this.btnDeleteDelivery_Click);
            // 
            // btnEditDelivery
            // 
            this.btnEditDelivery.Location = new System.Drawing.Point(789, 622);
            this.btnEditDelivery.Name = "btnEditDelivery";
            this.btnEditDelivery.Size = new System.Drawing.Size(137, 53);
            this.btnEditDelivery.TabIndex = 15;
            this.btnEditDelivery.Text = "Редактировать поставку";
            this.btnEditDelivery.UseVisualStyleBackColor = true;
            this.btnEditDelivery.Click += new System.EventHandler(this.btnEditDelivery_Click);
            // 
            // btnAddDelivery
            // 
            this.btnAddDelivery.Location = new System.Drawing.Point(789, 564);
            this.btnAddDelivery.Name = "btnAddDelivery";
            this.btnAddDelivery.Size = new System.Drawing.Size(137, 52);
            this.btnAddDelivery.TabIndex = 14;
            this.btnAddDelivery.Text = "Добавить поставку";
            this.btnAddDelivery.UseVisualStyleBackColor = true;
            this.btnAddDelivery.Click += new System.EventHandler(this.btnAddDelivery_Click);
            // 
            // dataGridViewDeliveriesMaterials
            // 
            this.dataGridViewDeliveriesMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeliveriesMaterials.Location = new System.Drawing.Point(298, 564);
            this.dataGridViewDeliveriesMaterials.Name = "dataGridViewDeliveriesMaterials";
            this.dataGridViewDeliveriesMaterials.Size = new System.Drawing.Size(465, 163);
            this.dataGridViewDeliveriesMaterials.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(495, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "СКЛАД";
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 760);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewDeliveriesMaterials);
            this.Controls.Add(this.btnDeleteDelivery);
            this.Controls.Add(this.btnEditDelivery);
            this.Controls.Add(this.btnAddDelivery);
            this.Controls.Add(this.dataGridViewDeliveries);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeleteSupplier);
            this.Controls.Add(this.btnEditSupplier);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.btnEditMaterial);
            this.Controls.Add(this.btnDeleteMaterial);
            this.Controls.Add(this.btnAddMaterial);
            this.Controls.Add(this.dataGridViewSuppliers);
            this.Controls.Add(this.dataGridViewMaterials);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WarehouseForm";
            this.Text = "WarehouseForm";
            this.Load += new System.EventHandler(this.WarehouseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeliveries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeliveriesMaterials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewMaterials;
        private System.Windows.Forms.DataGridView dataGridViewSuppliers;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.Button btnEditMaterial;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnEditSupplier;
        private System.Windows.Forms.Button btnDeleteSupplier;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridViewDeliveries;
        private System.Windows.Forms.Button btnDeleteDelivery;
        private System.Windows.Forms.Button btnEditDelivery;
        private System.Windows.Forms.Button btnAddDelivery;
        private System.Windows.Forms.DataGridView dataGridViewDeliveriesMaterials;
        private System.Windows.Forms.Label label4;
    }
}