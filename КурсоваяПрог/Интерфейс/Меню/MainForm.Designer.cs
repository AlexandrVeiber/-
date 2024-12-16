namespace КурсоваяПрог
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.бригадыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьБригадуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сметаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заявкиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.работыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.складToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewProjects = new System.Windows.Forms.DataGridView();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnEditProject = new System.Windows.Forms.Button();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.listBoxObjects = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.бригадыToolStripMenuItem,
            this.объектыToolStripMenuItem,
            this.складToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // бригадыToolStripMenuItem
            // 
            this.бригадыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьБригадуToolStripMenuItem});
            this.бригадыToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.бригадыToolStripMenuItem.Name = "бригадыToolStripMenuItem";
            this.бригадыToolStripMenuItem.Size = new System.Drawing.Size(87, 25);
            this.бригадыToolStripMenuItem.Text = "Бригады";
            // 
            // добавитьБригадуToolStripMenuItem
            // 
            this.добавитьБригадуToolStripMenuItem.Name = "добавитьБригадуToolStripMenuItem";
            this.добавитьБригадуToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.добавитьБригадуToolStripMenuItem.Text = "Добавить бригаду";
            this.добавитьБригадуToolStripMenuItem.Click += new System.EventHandler(this.добавитьБригадуToolStripMenuItem_Click);
            // 
            // объектыToolStripMenuItem
            // 
            this.объектыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сметаToolStripMenuItem,
            this.заявкиToolStripMenuItem1,
            this.работыToolStripMenuItem1});
            this.объектыToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.объектыToolStripMenuItem.Name = "объектыToolStripMenuItem";
            this.объектыToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.объектыToolStripMenuItem.Text = "Объекты";
            // 
            // сметаToolStripMenuItem
            // 
            this.сметаToolStripMenuItem.Name = "сметаToolStripMenuItem";
            this.сметаToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.сметаToolStripMenuItem.Text = "Смета";
            this.сметаToolStripMenuItem.Click += new System.EventHandler(this.сметаToolStripMenuItem_Click);
            // 
            // заявкиToolStripMenuItem1
            // 
            this.заявкиToolStripMenuItem1.Name = "заявкиToolStripMenuItem1";
            this.заявкиToolStripMenuItem1.Size = new System.Drawing.Size(180, 26);
            this.заявкиToolStripMenuItem1.Text = "Заявки";
            this.заявкиToolStripMenuItem1.Click += new System.EventHandler(this.заявкиToolStripMenuItem1_Click);
            // 
            // работыToolStripMenuItem1
            // 
            this.работыToolStripMenuItem1.Name = "работыToolStripMenuItem1";
            this.работыToolStripMenuItem1.Size = new System.Drawing.Size(180, 26);
            this.работыToolStripMenuItem1.Text = "Работы";
            this.работыToolStripMenuItem1.Click += new System.EventHandler(this.работыToolStripMenuItem1_Click);
            // 
            // складToolStripMenuItem
            // 
            this.складToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.складToolStripMenuItem.Name = "складToolStripMenuItem";
            this.складToolStripMenuItem.Size = new System.Drawing.Size(66, 25);
            this.складToolStripMenuItem.Text = "Склад";
            this.складToolStripMenuItem.Click += new System.EventHandler(this.складToolStripMenuItem_Click);
            // 
            // dataGridViewProjects
            // 
            this.dataGridViewProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjects.Location = new System.Drawing.Point(243, 66);
            this.dataGridViewProjects.Name = "dataGridViewProjects";
            this.dataGridViewProjects.Size = new System.Drawing.Size(633, 352);
            this.dataGridViewProjects.TabIndex = 1;
            this.dataGridViewProjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProjects_CellContentClick);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddProject.Location = new System.Drawing.Point(53, 66);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(172, 74);
            this.btnAddProject.TabIndex = 2;
            this.btnAddProject.Text = "Добавить проект";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnEditProject
            // 
            this.btnEditProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditProject.Location = new System.Drawing.Point(53, 146);
            this.btnEditProject.Name = "btnEditProject";
            this.btnEditProject.Size = new System.Drawing.Size(172, 73);
            this.btnEditProject.TabIndex = 3;
            this.btnEditProject.Text = "Редактировать проект";
            this.btnEditProject.UseVisualStyleBackColor = true;
            this.btnEditProject.Click += new System.EventHandler(this.btnEditProject_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteProject.Location = new System.Drawing.Point(53, 225);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(172, 81);
            this.btnDeleteProject.TabIndex = 4;
            this.btnDeleteProject.Text = "Удалить проект";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(93, 428);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "выбрать";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // listBoxObjects
            // 
            this.listBoxObjects.FormattingEnabled = true;
            this.listBoxObjects.Location = new System.Drawing.Point(68, 323);
            this.listBoxObjects.Name = "listBoxObjects";
            this.listBoxObjects.Size = new System.Drawing.Size(126, 95);
            this.listBoxObjects.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(457, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Список проектов";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.listBoxObjects);
            this.Controls.Add(this.btnDeleteProject);
            this.Controls.Add(this.btnEditProject);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.dataGridViewProjects);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem бригадыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объектыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьБригадуToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewProjects;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnEditProject;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.ToolStripMenuItem сметаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заявкиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem работыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem складToolStripMenuItem;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ListBox listBoxObjects;
        private System.Windows.Forms.Label label1;
    }
}

