namespace КурсоваяПрог.Интерфейс.Бригады
{
    partial class AddBrigadeForm
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
            this.txtBrigadeName = new System.Windows.Forms.TextBox();
            this.txtForemanName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название бригады";
            // 
            // txtBrigadeName
            // 
            this.txtBrigadeName.Location = new System.Drawing.Point(132, 40);
            this.txtBrigadeName.Name = "txtBrigadeName";
            this.txtBrigadeName.Size = new System.Drawing.Size(122, 20);
            this.txtBrigadeName.TabIndex = 1;
            // 
            // txtForemanName
            // 
            this.txtForemanName.Location = new System.Drawing.Point(132, 89);
            this.txtForemanName.Name = "txtForemanName";
            this.txtForemanName.Size = new System.Drawing.Size(122, 20);
            this.txtForemanName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя руководителя";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(68, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 46);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddBrigadeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 210);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtForemanName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBrigadeName);
            this.Controls.Add(this.label1);
            this.Name = "AddBrigadeForm";
            this.Text = "AddBrigadeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrigadeName;
        private System.Windows.Forms.TextBox txtForemanName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
    }
}