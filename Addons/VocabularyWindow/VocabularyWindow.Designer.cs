//-----------------------------------------------------------------------
// <copyright file="VocabularyWindow.cs" company="Тепляшин Сергей Васильевич">
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
// <date>10.11.2016</date>
// <time>10:12</time>
// <summary>Defines the VocabularyWindow class.</summary>
//-----------------------------------------------------------------------
namespace VocabularyTest.Addons.VocabularyWindow
{
    partial class VocabularyWindow
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelFind;
        private ComponentLib.Controls.TextEdit textFind;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridEntries;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.BindingSource bindingEntry;
        private System.ComponentModel.BackgroundWorker backgroundSpellChecker;
        private System.Windows.Forms.ContextMenuStrip contextMenuEntries;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuMove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuSynonyms;
        private System.Windows.Forms.ToolStripMenuItem menuDefineSynonyms;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuAntonyms;
        private System.Windows.Forms.ToolStripMenuItem menuDefineAntonyms;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator separatorTop;
        
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
            this.components = new System.ComponentModel.Container();
            this.panelFind = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.textFind = new ComponentLib.Controls.TextEdit();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.gridEntries = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuEntries = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.separatorTop = new System.Windows.Forms.ToolStripSeparator();
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSynonyms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDefineSynonyms = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAntonyms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDefineAntonyms = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingEntry = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundSpellChecker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.panelFind)).BeginInit();
            this.panelFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntries)).BeginInit();
            this.contextMenuEntries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFind
            // 
            this.panelFind.Controls.Add(this.textFind);
            this.panelFind.Controls.Add(this.kryptonLabel1);
            this.panelFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFind.Location = new System.Drawing.Point(0, 0);
            this.panelFind.Name = "panelFind";
            this.panelFind.Size = new System.Drawing.Size(805, 30);
            this.panelFind.TabIndex = 3;
            // 
            // textFind
            // 
            this.textFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFind.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny2});
            this.textFind.EmptyText = "Строка поиска";
            this.textFind.Location = new System.Drawing.Point(51, 5);
            this.textFind.Name = "textFind";
            this.textFind.Size = new System.Drawing.Size(751, 20);
            this.textFind.StateCommon.Content.Color1 = System.Drawing.SystemColors.ControlDark;
            this.textFind.TabIndex = 0;
            this.textFind.Text = "Строка поиска";
            this.textFind.ValueText = null;
            this.textFind.TextChanged += new System.EventHandler(this.textFind_TextChanged);
            // 
            // buttonSpecAny2
            // 
            this.buttonSpecAny2.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonSpecAny2.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.buttonSpecAny2.UniqueName = "087F14188A5C4FAFC8AB230E62545E16";
            this.buttonSpecAny2.Click += new System.EventHandler(this.buttonSpecAny2_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 6);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(46, 22);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Поиск";
            // 
            // gridEntries
            // 
            this.gridEntries.AutoGenerateColumns = false;
            this.gridEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.gridEntries.ContextMenuStrip = this.contextMenuEntries;
            this.gridEntries.DataSource = this.bindingEntry;
            this.gridEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEntries.HideOuterBorders = true;
            this.gridEntries.Location = new System.Drawing.Point(0, 30);
            this.gridEntries.Name = "gridEntries";
            this.gridEntries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridEntries.Size = new System.Drawing.Size(805, 339);
            this.gridEntries.TabIndex = 4;
            this.gridEntries.VirtualMode = true;
            this.gridEntries.CancelRowEdit += new System.Windows.Forms.QuestionEventHandler(this.GridEntriesCancelRowEdit);
            this.gridEntries.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridEntriesCellMouseDown);
            this.gridEntries.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridEntriesCellMouseMove);
            this.gridEntries.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridEntriesCellMouseUp);
            this.gridEntries.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridEntries_CellPainting);
            this.gridEntries.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.GridEntriesCellValueNeeded);
            this.gridEntries.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.GridEntriesCellValuePushed);
            this.gridEntries.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridEntriesRowValidated);
            this.gridEntries.SelectionChanged += new System.EventHandler(this.GridEntriesSelectionChanged);
            this.gridEntries.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.GridEntriesQueryContinueDrag);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // contextMenuEntries
            // 
            this.contextMenuEntries.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.contextMenuEntries.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.separatorTop,
            this.menuAdd,
            this.menuDelete,
            this.menuMove,
            this.toolStripSeparator1,
            this.menuSynonyms,
            this.menuAntonyms,
            this.toolStripSeparator4,
            this.menuColumns});
            this.contextMenuEntries.Name = "contextMenuEntries";
            this.contextMenuEntries.Size = new System.Drawing.Size(210, 154);
            this.contextMenuEntries.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuEntriesOpening);
            // 
            // separatorTop
            // 
            this.separatorTop.Name = "separatorTop";
            this.separatorTop.Size = new System.Drawing.Size(206, 6);
            // 
            // menuAdd
            // 
            this.menuAdd.Image = global::VocabularyTest.Addons.VocabularyWindow.Images.textfield_add;
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.menuAdd.Size = new System.Drawing.Size(209, 22);
            this.menuAdd.Text = "Добавить строку...";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Image = global::VocabularyTest.Addons.VocabularyWindow.Images.textfield_delete;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.menuDelete.Size = new System.Drawing.Size(209, 22);
            this.menuDelete.Text = "Удалить строку";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuMove
            // 
            this.menuMove.Name = "menuMove";
            this.menuMove.Size = new System.Drawing.Size(209, 22);
            this.menuMove.Text = "Переместить";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // menuSynonyms
            // 
            this.menuSynonyms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDefineSynonyms,
            this.toolStripSeparator3});
            this.menuSynonyms.Name = "menuSynonyms";
            this.menuSynonyms.Size = new System.Drawing.Size(209, 22);
            this.menuSynonyms.Text = "Синонимы";
            // 
            // menuDefineSynonyms
            // 
            this.menuDefineSynonyms.Name = "menuDefineSynonyms";
            this.menuDefineSynonyms.Size = new System.Drawing.Size(140, 22);
            this.menuDefineSynonyms.Text = "Определить";
            this.menuDefineSynonyms.Click += new System.EventHandler(this.menuDefineSynonyms_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(137, 6);
            // 
            // menuAntonyms
            // 
            this.menuAntonyms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDefineAntonyms,
            this.toolStripSeparator2});
            this.menuAntonyms.Name = "menuAntonyms";
            this.menuAntonyms.Size = new System.Drawing.Size(209, 22);
            this.menuAntonyms.Text = "Антонимы";
            // 
            // menuDefineAntonyms
            // 
            this.menuDefineAntonyms.Name = "menuDefineAntonyms";
            this.menuDefineAntonyms.Size = new System.Drawing.Size(140, 22);
            this.menuDefineAntonyms.Text = "Определить";
            this.menuDefineAntonyms.Click += new System.EventHandler(this.menuDefineAntonyms_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(206, 6);
            // 
            // menuColumns
            // 
            this.menuColumns.Image = global::VocabularyTest.Addons.VocabularyWindow.Images.columns_view;
            this.menuColumns.Name = "menuColumns";
            this.menuColumns.Size = new System.Drawing.Size(209, 22);
            this.menuColumns.Text = "Столбцы словаря...";
            this.menuColumns.Click += new System.EventHandler(this.menuColumns_Click);
            // 
            // backgroundSpellChecker
            // 
            this.backgroundSpellChecker.WorkerSupportsCancellation = true;
            this.backgroundSpellChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSpellChecker_DoWork);
            this.backgroundSpellChecker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundSpellChecker_RunWorkerCompleted);
            // 
            // VocabularyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 369);
            this.Controls.Add(this.gridEntries);
            this.Controls.Add(this.panelFind);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "VocabularyWindow";
            this.Text = "Словарь";
            ((System.ComponentModel.ISupportInitialize)(this.panelFind)).EndInit();
            this.panelFind.ResumeLayout(false);
            this.panelFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntries)).EndInit();
            this.contextMenuEntries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingEntry)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ToolStripMenuItem menuColumns;
    }
}
