//-----------------------------------------------------------------------
// <copyright file="WordTypeDialog.Designer.cs" company="Тепляшин Сергей Васильевич">
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
// <date>23.11.2010</date>
// <time>8:58</time>
// <summary>Defines the WordTypeDialog class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.WordTypeWindow
{
    partial class WordTypeDialog
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordTypeDialog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.textWordTypeName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.comboSpecial = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.gridShortNames = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ColumnLangauge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnButtonChange = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.comboSpecial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShortNames)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            resources.ApplyResources(this.kryptonLabel1, "kryptonLabel1");
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
            // 
            // kryptonLabel2
            // 
            resources.ApplyResources(this.kryptonLabel2, "kryptonLabel2");
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Values.Text = resources.GetString("kryptonLabel2.Values.Text");
            // 
            // textWordTypeName
            // 
            resources.ApplyResources(this.textWordTypeName, "textWordTypeName");
            this.textWordTypeName.Name = "textWordTypeName";
            this.textWordTypeName.TextChanged += new System.EventHandler(this.TextWordTypeNameTextChanged);
            // 
            // comboSpecial
            // 
            resources.ApplyResources(this.comboSpecial, "comboSpecial");
            this.comboSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSpecial.DropDownWidth = 225;
            this.comboSpecial.Items.AddRange(new object[] {
            resources.GetString("comboSpecial.Items"),
            resources.GetString("comboSpecial.Items1"),
            resources.GetString("comboSpecial.Items2"),
            resources.GetString("comboSpecial.Items3"),
            resources.GetString("comboSpecial.Items4"),
            resources.GetString("comboSpecial.Items5"),
            resources.GetString("comboSpecial.Items6"),
            resources.GetString("comboSpecial.Items7")});
            this.comboSpecial.Name = "comboSpecial";
            // 
            // kryptonLabel3
            // 
            resources.ApplyResources(this.kryptonLabel3, "kryptonLabel3");
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Values.Text = resources.GetString("kryptonLabel3.Values.Text");
            // 
            // gridShortNames
            // 
            this.gridShortNames.AllowUserToAddRows = false;
            this.gridShortNames.AllowUserToDeleteRows = false;
            this.gridShortNames.AllowUserToResizeRows = false;
            resources.ApplyResources(this.gridShortNames, "gridShortNames");
            this.gridShortNames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridShortNames.ColumnHeadersVisible = false;
            this.gridShortNames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLangauge,
            this.ColumnShortName,
            this.ColumnButtonChange});
            this.gridShortNames.MultiSelect = false;
            this.gridShortNames.Name = "gridShortNames";
            this.gridShortNames.ReadOnly = true;
            this.gridShortNames.RowHeadersVisible = false;
            this.gridShortNames.RowTemplate.Height = 27;
            this.gridShortNames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridShortNames.StateCommon.Background.Color1 = System.Drawing.Color.Transparent;
            this.gridShortNames.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.gridShortNames.StateCommon.DataCell.Back.Color1 = System.Drawing.Color.Transparent;
            this.gridShortNames.StateCommon.DataCell.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.gridShortNames.StateCommon.HeaderColumn.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.gridShortNames.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridShortNamesCellContentClick);
            // 
            // ColumnLangauge
            // 
            this.ColumnLangauge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.ColumnLangauge, "ColumnLangauge");
            this.ColumnLangauge.Name = "ColumnLangauge";
            this.ColumnLangauge.ReadOnly = true;
            // 
            // ColumnShortName
            // 
            this.ColumnShortName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColumnShortName.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.ColumnShortName, "ColumnShortName");
            this.ColumnShortName.Name = "ColumnShortName";
            this.ColumnShortName.ReadOnly = true;
            // 
            // ColumnButtonChange
            // 
            this.ColumnButtonChange.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.ColumnButtonChange, "ColumnButtonChange");
            this.ColumnButtonChange.Name = "ColumnButtonChange";
            this.ColumnButtonChange.ReadOnly = true;
            // 
            // WordTypeDialog
            // 
            this.AcceptButton = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = null;
            this.Controls.Add(this.gridShortNames);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.comboSpecial);
            this.Controls.Add(this.textWordTypeName);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Name = "WordTypeDialog";
            this.Controls.SetChildIndex(this.kryptonLabel1, 0);
            this.Controls.SetChildIndex(this.kryptonLabel2, 0);
            this.Controls.SetChildIndex(this.textWordTypeName, 0);
            this.Controls.SetChildIndex(this.comboSpecial, 0);
            this.Controls.SetChildIndex(this.kryptonLabel3, 0);
            this.Controls.SetChildIndex(this.gridShortNames, 0);
            ((System.ComponentModel.ISupportInitialize)(this.comboSpecial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridShortNames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn ColumnButtonChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLangauge;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridShortNames;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboSpecial;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textWordTypeName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
