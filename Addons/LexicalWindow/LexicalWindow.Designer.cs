namespace VocabularyTest.Addons.LexicalWindow
{
    partial class LexicalWindow
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonDefine = new System.Windows.Forms.ToolStripButton();
            this.buttonDelete = new System.Windows.Forms.ToolStripButton();
            this.listLexical = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDefine,
            this.buttonDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonDefine
            // 
            this.buttonDefine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDefine.Image = global::VocabularyTest.Addons.LexicalWindow.Images.accept;
            this.buttonDefine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDefine.Name = "buttonDefine";
            this.buttonDefine.Size = new System.Drawing.Size(23, 22);
            this.buttonDefine.Text = "Определить";
            this.buttonDefine.Click += new System.EventHandler(this.buttonDefine_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDelete.Image = global::VocabularyTest.Addons.LexicalWindow.Images.delete;
            this.buttonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(23, 22);
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // listLexical
            // 
            this.listLexical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLexical.Location = new System.Drawing.Point(0, 25);
            this.listLexical.Name = "listLexical";
            this.listLexical.Size = new System.Drawing.Size(284, 237);
            this.listLexical.TabIndex = 1;
            // 
            // LexicalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.listLexical);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LexicalWindow";
            this.Text = "LexicalWindow";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonDefine;
        private System.Windows.Forms.ToolStripButton buttonDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox listLexical;
    }
}