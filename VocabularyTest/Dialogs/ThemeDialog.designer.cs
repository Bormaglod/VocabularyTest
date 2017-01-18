//-----------------------------------------------------------------------
// <copyright file="FormCollection.Designer.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2012 Sergey Teplyashin. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergey-teplyashin@yandex.ru</email>
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
// <date>22.11.2010</date>
// <time>10:09</time>
// <summary>Defines the FormCollection class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest
{
    partial class ThemeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeDialog));
            this.groupCommon = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.comboLicense = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.comboCategory = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.textComment = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.textHeader = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.groupLanguages = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonCheckBox2 = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonCheckBox1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.comboCulture2 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.comboCulture1 = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon.Panel)).BeginInit();
            this.groupCommon.Panel.SuspendLayout();
            this.groupCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLanguages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLanguages.Panel)).BeginInit();
            this.groupLanguages.Panel.SuspendLayout();
            this.groupLanguages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboCulture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCulture1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupCommon
            // 
            resources.ApplyResources(this.groupCommon, "groupCommon");
            this.groupCommon.Name = "groupCommon";
            // 
            // groupCommon.Panel
            // 
            resources.ApplyResources(this.groupCommon.Panel, "groupCommon.Panel");
            this.groupCommon.Panel.Controls.Add(this.comboLicense);
            this.groupCommon.Panel.Controls.Add(this.comboCategory);
            this.groupCommon.Panel.Controls.Add(this.textComment);
            this.groupCommon.Panel.Controls.Add(this.textEmail);
            this.groupCommon.Panel.Controls.Add(this.textName);
            this.groupCommon.Panel.Controls.Add(this.textHeader);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel6);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel5);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel4);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel3);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel2);
            this.groupCommon.Panel.Controls.Add(this.kryptonLabel1);
            this.groupCommon.Values.Description = resources.GetString("groupCommon.Values.Description");
            this.groupCommon.Values.Heading = resources.GetString("groupCommon.Values.Heading");
            this.groupCommon.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("groupCommon.Values.ImageTransparentColor")));
            // 
            // comboLicense
            // 
            resources.ApplyResources(this.comboLicense, "comboLicense");
            this.comboLicense.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny2});
            this.comboLicense.DropDownWidth = 275;
            this.comboLicense.Items.AddRange(new object[] {
            resources.GetString("comboLicense.Items"),
            resources.GetString("comboLicense.Items1")});
            this.comboLicense.Name = "comboLicense";
            // 
            // buttonSpecAny2
            // 
            resources.ApplyResources(this.buttonSpecAny2, "buttonSpecAny2");
            this.buttonSpecAny2.UniqueName = "EEE2BD60E111454862B5366A7EB9DE55";
            this.buttonSpecAny2.Click += new System.EventHandler(this.ButtonSpecAny2Click);
            // 
            // comboCategory
            // 
            resources.ApplyResources(this.comboCategory, "comboCategory");
            this.comboCategory.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.comboCategory.DropDownWidth = 275;
            this.comboCategory.Items.AddRange(new object[] {
            resources.GetString("comboCategory.Items"),
            resources.GetString("comboCategory.Items1"),
            resources.GetString("comboCategory.Items2"),
            resources.GetString("comboCategory.Items3"),
            resources.GetString("comboCategory.Items4"),
            resources.GetString("comboCategory.Items5")});
            this.comboCategory.Name = "comboCategory";
            // 
            // buttonSpecAny1
            // 
            resources.ApplyResources(this.buttonSpecAny1, "buttonSpecAny1");
            this.buttonSpecAny1.UniqueName = "15F6E88AA43447A79081D8F1119A98BA";
            this.buttonSpecAny1.Click += new System.EventHandler(this.ButtonSpecAny1Click);
            // 
            // textComment
            // 
            resources.ApplyResources(this.textComment, "textComment");
            this.textComment.Name = "textComment";
            // 
            // textEmail
            // 
            resources.ApplyResources(this.textEmail, "textEmail");
            this.textEmail.Name = "textEmail";
            // 
            // textName
            // 
            resources.ApplyResources(this.textName, "textName");
            this.textName.Name = "textName";
            // 
            // textHeader
            // 
            resources.ApplyResources(this.textHeader, "textHeader");
            this.textHeader.Name = "textHeader";
            // 
            // kryptonLabel6
            // 
            resources.ApplyResources(this.kryptonLabel6, "kryptonLabel6");
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Values.ExtraText = resources.GetString("kryptonLabel6.Values.ExtraText");
            this.kryptonLabel6.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel6.Values.ImageTransparentColor")));
            this.kryptonLabel6.Values.Text = resources.GetString("kryptonLabel6.Values.Text");
            // 
            // kryptonLabel5
            // 
            resources.ApplyResources(this.kryptonLabel5, "kryptonLabel5");
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Values.ExtraText = resources.GetString("kryptonLabel5.Values.ExtraText");
            this.kryptonLabel5.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel5.Values.ImageTransparentColor")));
            this.kryptonLabel5.Values.Text = resources.GetString("kryptonLabel5.Values.Text");
            // 
            // kryptonLabel4
            // 
            resources.ApplyResources(this.kryptonLabel4, "kryptonLabel4");
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Values.ExtraText = resources.GetString("kryptonLabel4.Values.ExtraText");
            this.kryptonLabel4.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel4.Values.ImageTransparentColor")));
            this.kryptonLabel4.Values.Text = resources.GetString("kryptonLabel4.Values.Text");
            // 
            // kryptonLabel3
            // 
            resources.ApplyResources(this.kryptonLabel3, "kryptonLabel3");
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Values.ExtraText = resources.GetString("kryptonLabel3.Values.ExtraText");
            this.kryptonLabel3.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel3.Values.ImageTransparentColor")));
            this.kryptonLabel3.Values.Text = resources.GetString("kryptonLabel3.Values.Text");
            // 
            // kryptonLabel2
            // 
            resources.ApplyResources(this.kryptonLabel2, "kryptonLabel2");
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Values.ExtraText = resources.GetString("kryptonLabel2.Values.ExtraText");
            this.kryptonLabel2.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel2.Values.ImageTransparentColor")));
            this.kryptonLabel2.Values.Text = resources.GetString("kryptonLabel2.Values.Text");
            // 
            // kryptonLabel1
            // 
            resources.ApplyResources(this.kryptonLabel1, "kryptonLabel1");
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Values.ExtraText = resources.GetString("kryptonLabel1.Values.ExtraText");
            this.kryptonLabel1.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel1.Values.ImageTransparentColor")));
            this.kryptonLabel1.Values.Text = resources.GetString("kryptonLabel1.Values.Text");
            // 
            // groupLanguages
            // 
            resources.ApplyResources(this.groupLanguages, "groupLanguages");
            this.groupLanguages.Name = "groupLanguages";
            // 
            // groupLanguages.Panel
            // 
            resources.ApplyResources(this.groupLanguages.Panel, "groupLanguages.Panel");
            this.groupLanguages.Panel.Controls.Add(this.kryptonCheckBox2);
            this.groupLanguages.Panel.Controls.Add(this.kryptonCheckBox1);
            this.groupLanguages.Panel.Controls.Add(this.comboCulture2);
            this.groupLanguages.Panel.Controls.Add(this.comboCulture1);
            this.groupLanguages.Panel.Controls.Add(this.kryptonLabel9);
            this.groupLanguages.Panel.Controls.Add(this.kryptonLabel8);
            this.groupLanguages.Values.Description = resources.GetString("groupLanguages.Values.Description");
            this.groupLanguages.Values.Heading = resources.GetString("groupLanguages.Values.Heading");
            this.groupLanguages.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("groupLanguages.Values.ImageTransparentColor")));
            // 
            // kryptonCheckBox2
            // 
            resources.ApplyResources(this.kryptonCheckBox2, "kryptonCheckBox2");
            this.kryptonCheckBox2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonCheckBox2.Name = "kryptonCheckBox2";
            this.kryptonCheckBox2.Values.ExtraText = resources.GetString("kryptonCheckBox2.Values.ExtraText");
            this.kryptonCheckBox2.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonCheckBox2.Values.ImageTransparentColor")));
            this.kryptonCheckBox2.Values.Text = resources.GetString("kryptonCheckBox2.Values.Text");
            // 
            // kryptonCheckBox1
            // 
            resources.ApplyResources(this.kryptonCheckBox1, "kryptonCheckBox1");
            this.kryptonCheckBox1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonCheckBox1.Name = "kryptonCheckBox1";
            this.kryptonCheckBox1.Values.ExtraText = resources.GetString("kryptonCheckBox1.Values.ExtraText");
            this.kryptonCheckBox1.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonCheckBox1.Values.ImageTransparentColor")));
            this.kryptonCheckBox1.Values.Text = resources.GetString("kryptonCheckBox1.Values.Text");
            // 
            // comboCulture2
            // 
            resources.ApplyResources(this.comboCulture2, "comboCulture2");
            this.comboCulture2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCulture2.DropDownWidth = 275;
            this.comboCulture2.Name = "comboCulture2";
            // 
            // comboCulture1
            // 
            resources.ApplyResources(this.comboCulture1, "comboCulture1");
            this.comboCulture1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCulture1.DropDownWidth = 275;
            this.comboCulture1.Name = "comboCulture1";
            // 
            // kryptonLabel9
            // 
            resources.ApplyResources(this.kryptonLabel9, "kryptonLabel9");
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Values.ExtraText = resources.GetString("kryptonLabel9.Values.ExtraText");
            this.kryptonLabel9.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel9.Values.ImageTransparentColor")));
            this.kryptonLabel9.Values.Text = resources.GetString("kryptonLabel9.Values.Text");
            // 
            // kryptonLabel8
            // 
            resources.ApplyResources(this.kryptonLabel8, "kryptonLabel8");
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Values.ExtraText = resources.GetString("kryptonLabel8.Values.ExtraText");
            this.kryptonLabel8.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("kryptonLabel8.Values.ImageTransparentColor")));
            this.kryptonLabel8.Values.Text = resources.GetString("kryptonLabel8.Values.Text");
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Values.ExtraText = resources.GetString("buttonCancel.Values.ExtraText");
            this.buttonCancel.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonCancel.Values.ImageTransparentColor")));
            this.buttonCancel.Values.Text = resources.GetString("buttonCancel.Values.Text");
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Values.ExtraText = resources.GetString("buttonOK.Values.ExtraText");
            this.buttonOK.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonOK.Values.ImageTransparentColor")));
            this.buttonOK.Values.Text = resources.GetString("buttonOK.Values.Text");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.DefaultExt = "vtf";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // ThemeDialog
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.groupLanguages);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupCommon);
            this.Name = "ThemeDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon.Panel)).EndInit();
            this.groupCommon.Panel.ResumeLayout(false);
            this.groupCommon.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupCommon)).EndInit();
            this.groupCommon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupLanguages.Panel)).EndInit();
            this.groupLanguages.Panel.ResumeLayout(false);
            this.groupLanguages.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupLanguages)).EndInit();
            this.groupLanguages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboCulture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboCulture1)).EndInit();
            this.ResumeLayout(false);

        }
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboCulture1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboCulture2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryptonCheckBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryptonCheckBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupLanguages;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupCommon;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textHeader;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textComment;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboLicense;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
    }
}
