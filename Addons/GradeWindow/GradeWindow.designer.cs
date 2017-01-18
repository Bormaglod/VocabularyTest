namespace VocabularyTest.Addons.GradeWindow
{
    partial class GradeWindow
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
            this.panelLanguage = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labelLanguage = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.listGrades = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelLanguage)).BeginInit();
            this.panelLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLanguage
            // 
            this.panelLanguage.Controls.Add(this.labelLanguage);
            this.panelLanguage.Controls.Add(this.kryptonLabel1);
            this.panelLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLanguage.Location = new System.Drawing.Point(0, 0);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Size = new System.Drawing.Size(284, 37);
            this.panelLanguage.TabIndex = 0;
            // 
            // labelLanguage
            // 
            this.labelLanguage.Location = new System.Drawing.Point(103, 8);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(90, 20);
            this.labelLanguage.TabIndex = 1;
            this.labelLanguage.Values.Text = "labelLanguage";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(9, 8);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Язык";
            // 
            // listGrades
            // 
            this.listGrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGrades.Location = new System.Drawing.Point(0, 37);
            this.listGrades.Name = "listGrades";
            this.listGrades.Size = new System.Drawing.Size(284, 225);
            this.listGrades.TabIndex = 1;
            // 
            // GradeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.listGrades);
            this.Controls.Add(this.panelLanguage);
            this.Name = "GradeWindow";
            this.Text = "Уровни знания";
            ((System.ComponentModel.ISupportInitialize)(this.panelLanguage)).EndInit();
            this.panelLanguage.ResumeLayout(false);
            this.panelLanguage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelLanguage;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelLanguage;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox listGrades;
    }
}

