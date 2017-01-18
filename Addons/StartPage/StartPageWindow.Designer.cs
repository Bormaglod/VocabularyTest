//-----------------------------------------------------------------------
// <copyright file="StartPageWindow.cs" company="Тепляшин Сергей Васильевич">
//     Copyright (c) 2010-2016 Тепляшин Сергей Васильевич. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergio.teplyashin@gmail.com</email>
// <license>
//     This program is free software; you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation; either version 3 of the License, or
//     (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// </license>
// <date>25.10.2016</date>
// <time>12:19</time>
// <summary>Defines the StartPageWindow class.</summary>
//-----------------------------------------------------------------------
namespace VocabularyTest.Addons.StartPage
{
    partial class StartPageWindow
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonLoad;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCreate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridRecentFiles;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPageWindow));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.gridRecentFiles = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLoad = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonCreate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonDelete = new System.Windows.Forms.ToolStripButton();
            this.buttonHide = new System.Windows.Forms.ToolStripButton();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOpened = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAction = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.ColumnStartPractice = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecentFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonPanel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Controls.Add(this.buttonLoad);
            this.kryptonPanel1.Controls.Add(this.buttonCreate);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1004, 548);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // gridRecentFiles
            // 
            this.gridRecentFiles.AllowUserToAddRows = false;
            this.gridRecentFiles.AllowUserToDeleteRows = false;
            this.gridRecentFiles.AllowUserToOrderColumns = true;
            this.gridRecentFiles.AllowUserToResizeColumns = false;
            this.gridRecentFiles.AllowUserToResizeRows = false;
            this.gridRecentFiles.ColumnHeadersHeight = 25;
            this.gridRecentFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnOpened,
            this.ColumnAction,
            this.ColumnStartPractice});
            this.gridRecentFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRecentFiles.Location = new System.Drawing.Point(0, 25);
            this.gridRecentFiles.MultiSelect = false;
            this.gridRecentFiles.Name = "gridRecentFiles";
            this.gridRecentFiles.ReadOnly = true;
            this.gridRecentFiles.RowHeadersVisible = false;
            this.gridRecentFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRecentFiles.RowTemplate.Height = 27;
            this.gridRecentFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRecentFiles.Size = new System.Drawing.Size(980, 361);
            this.gridRecentFiles.TabIndex = 10;
            this.gridRecentFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridRecentFilesCellContentClick);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 128);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(94, 16);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kryptonLabel2.TabIndex = 9;
            this.kryptonLabel2.Values.Text = "Выберите тему";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::VocabularyTest.Addons.StartPage.Images.accessories_dictionary;
            this.pictureBox1.Location = new System.Drawing.Point(860, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 132);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonLoad.Location = new System.Drawing.Point(12, 78);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(227, 25);
            this.buttonLoad.TabIndex = 7;
            this.buttonLoad.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoad.Values.Image")));
            this.buttonLoad.Values.Text = "Загрузить новые словари";
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoadClick);
            // 
            // buttonCreate
            // 
            this.buttonCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCreate.Location = new System.Drawing.Point(12, 47);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(227, 25);
            this.buttonCreate.TabIndex = 5;
            this.buttonCreate.Values.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreate.Values.Image")));
            this.buttonCreate.Values.Text = "Создать новый словарь";
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreateClick);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(296, 29);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Тренировка словарного запаса";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel2.Controls.Add(this.gridRecentFiles);
            this.kryptonPanel2.Controls.Add(this.toolStrip1);
            this.kryptonPanel2.Location = new System.Drawing.Point(12, 150);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(980, 386);
            this.kryptonPanel2.TabIndex = 11;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonDelete,
            this.buttonHide});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(980, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonDelete
            // 
            this.buttonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(84, 22);
            this.buttonDelete.Text = "Удалить тему";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonHide
            // 
            this.buttonHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonHide.Image = ((System.Drawing.Image)(resources.GetObject("buttonHide.Image")));
            this.buttonHide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(52, 22);
            this.buttonHide.Text = "Скрыть";
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Наименование";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnOpened
            // 
            this.ColumnOpened.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnOpened.HeaderText = "Дата изменения";
            this.ColumnOpened.Name = "ColumnOpened";
            this.ColumnOpened.ReadOnly = true;
            this.ColumnOpened.Width = 124;
            // 
            // ColumnAction
            // 
            this.ColumnAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnAction.HeaderText = "";
            this.ColumnAction.Name = "ColumnAction";
            this.ColumnAction.ReadOnly = true;
            this.ColumnAction.Text = "";
            this.ColumnAction.Width = 7;
            // 
            // ColumnStartPractice
            // 
            this.ColumnStartPractice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnStartPractice.HeaderText = "";
            this.ColumnStartPractice.Name = "ColumnStartPractice";
            this.ColumnStartPractice.ReadOnly = true;
            this.ColumnStartPractice.Width = 7;
            // 
            // StartPageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 548);
            this.CloseButton = false;
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.HideOnClose = true;
            this.Controls.Add(this.kryptonPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "StartPageWindow";
            this.Text = "Главная";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecentFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOpened;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn ColumnAction;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn ColumnStartPractice;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonDelete;
        private System.Windows.Forms.ToolStripButton buttonHide;
    }
}
