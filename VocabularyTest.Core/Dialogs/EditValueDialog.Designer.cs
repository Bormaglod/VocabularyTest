//-----------------------------------------------------------------------
// <copyright file="EditValueDialog.Designer.cs" company="Тепляшин Сергей Васильевич">
//     Copyright (c) 2010-2016 Тепляшин Сергей Васильевич. All rights reserved.
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
// <date>24.10.2011</date>
// <time>13:16</time>
// <summary>Defines the EditValueDialog class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Core.Dialogs
{
    partial class EditValueDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditValueDialog));
            this.buttonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.buttonOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.textValue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.labelPrompt = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
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
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Values.ExtraText = resources.GetString("buttonOk.Values.ExtraText");
            this.buttonOk.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonOk.Values.ImageTransparentColor")));
            this.buttonOk.Values.Text = resources.GetString("buttonOk.Values.Text");
            // 
            // textValue
            // 
            resources.ApplyResources(this.textValue, "textValue");
            this.textValue.Name = "textValue";
            this.textValue.TextChanged += new System.EventHandler(this.TextValueTextChanged);
            // 
            // labelPrompt
            // 
            resources.ApplyResources(this.labelPrompt, "labelPrompt");
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Values.ExtraText = resources.GetString("labelPrompt.Values.ExtraText");
            this.labelPrompt.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("labelPrompt.Values.ImageTransparentColor")));
            this.labelPrompt.Values.Text = resources.GetString("labelPrompt.Values.Text");
            // 
            // EditValueDialog
            // 
            this.AcceptButton = this.buttonOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textValue);
            this.Controls.Add(this.labelPrompt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditValueDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox textValue;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelPrompt;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonOk;
        private ComponentFactory.Krypton.Toolkit.KryptonButton buttonCancel;
    }
}
