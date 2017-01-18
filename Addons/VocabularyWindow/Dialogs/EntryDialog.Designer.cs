//-----------------------------------------------------------------------
// <copyright file="EntryDialog.Designer.cs" company="Тепляшин Сергей Васильевич">
//     Copyright (c) 2010-2017 Тепляшин Сергей Васильевич. All rights reserved.
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
// <date>10.01.2017</date>
// <time>14:45</time>
// <summary>Defines the EntryDialog class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.VocabularyWindow
{
    partial class EntryDialog
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
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.comboWordTypes = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonClearWordType = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.comboLessons = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonClearLesson = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.gridWritings = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.ColumnLanguage = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.ColumnWriting = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.comboWordTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboLessons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWritings)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(38, 22);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Урок";
            // 
            // comboWordTypes
            // 
            this.comboWordTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboWordTypes.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonClearWordType});
            this.comboWordTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWordTypes.DropDownWidth = 232;
            this.comboWordTypes.Location = new System.Drawing.Point(91, 40);
            this.comboWordTypes.Name = "comboWordTypes";
            this.comboWordTypes.Size = new System.Drawing.Size(283, 21);
            this.comboWordTypes.TabIndex = 2;
            // 
            // buttonClearWordType
            // 
            this.buttonClearWordType.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonClearWordType.Image = global::VocabularyTest.Addons.VocabularyWindow.Images.crest;
            this.buttonClearWordType.UniqueName = "75BDC682C03B48A3AD9B17736F4A3461";
            this.buttonClearWordType.Click += new System.EventHandler(this.buttonClearWordType_Click);
            // 
            // comboLessons
            // 
            this.comboLessons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLessons.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonClearLesson});
            this.comboLessons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLessons.DropDownWidth = 544;
            this.comboLessons.Location = new System.Drawing.Point(91, 12);
            this.comboLessons.Name = "comboLessons";
            this.comboLessons.Size = new System.Drawing.Size(283, 21);
            this.comboLessons.TabIndex = 3;
            this.comboLessons.SelectedIndexChanged += new System.EventHandler(this.comboLessons_SelectedIndexChanged);
            // 
            // buttonClearLesson
            // 
            this.buttonClearLesson.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonClearLesson.Image = global::VocabularyTest.Addons.VocabularyWindow.Images.crest;
            this.buttonClearLesson.UniqueName = "1D4006B662F74B34BA916284CCC43F48";
            this.buttonClearLesson.Click += new System.EventHandler(this.buttonClearLesson_Click);
            // 
            // gridWritings
            // 
            this.gridWritings.AllowUserToAddRows = false;
            this.gridWritings.AllowUserToDeleteRows = false;
            this.gridWritings.AllowUserToResizeColumns = false;
            this.gridWritings.AllowUserToResizeRows = false;
            this.gridWritings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridWritings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWritings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLanguage,
            this.ColumnWriting});
            this.gridWritings.Location = new System.Drawing.Point(12, 68);
            this.gridWritings.MultiSelect = false;
            this.gridWritings.Name = "gridWritings";
            this.gridWritings.RowHeadersVisible = false;
            this.gridWritings.Size = new System.Drawing.Size(362, 172);
            this.gridWritings.TabIndex = 4;
            // 
            // ColumnLanguage
            // 
            this.ColumnLanguage.Frozen = true;
            this.ColumnLanguage.HeaderText = "Язык";
            this.ColumnLanguage.Name = "ColumnLanguage";
            this.ColumnLanguage.ReadOnly = true;
            this.ColumnLanguage.Width = 150;
            // 
            // ColumnWriting
            // 
            this.ColumnWriting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnWriting.HeaderText = "Текст";
            this.ColumnWriting.Name = "ColumnWriting";
            this.ColumnWriting.Width = 211;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 246);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 48);
            this.panel1.TabIndex = 5;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(143, 11);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(135, 25);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Values.Text = "Сохранить и закрыть";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(284, 11);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 25);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Values.Text = "Отмена";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 40);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(73, 22);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Часть речи";
            // 
            // EntryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 294);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridWritings);
            this.Controls.Add(this.comboLessons);
            this.Controls.Add(this.comboWordTypes);
            this.Controls.Add(this.kryptonLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntryDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить запись";
            ((System.ComponentModel.ISupportInitialize)(this.comboWordTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboLessons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWritings)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboWordTypes;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonClearWordType;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboLessons;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridWritings;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonClearLesson;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnLanguage;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn ColumnWriting;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}