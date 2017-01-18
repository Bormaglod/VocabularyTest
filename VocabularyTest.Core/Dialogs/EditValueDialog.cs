//-----------------------------------------------------------------------
// <copyright file="EditValueDialog.cs" company="Тепляшин Сергей Васильевич">
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
    using System;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    
    public partial class EditValueDialog : KryptonForm
    {
        public EditValueDialog()
        {
            InitializeComponent();
        }

        public string Value
        {
            get { return textValue.Text; }
        }
        
        public bool ShowDialog(IWin32Window owner, string caption, string prompt, string defaultValue)
        {
            Text = caption;
            labelPrompt.Text = prompt;
            textValue.Text = defaultValue;
            buttonOk.Enabled = textValue.Text.Length > 0;
            return ShowDialog(owner) == DialogResult.OK;
        }
        
        public static bool ShowDialog(IWin32Window owner, string caption, string prompt, string defaultValue, out string Value)
        {
            EditValueDialog dialog = new EditValueDialog();
            bool result = dialog.ShowDialog(owner, caption, prompt, defaultValue);
            Value = result ? dialog.Value : defaultValue;
            return result;
        }
        
        void TextValueTextChanged(object sender, EventArgs e)
        {
        	buttonOk.Enabled = textValue.Text.Length > 0;
        }
    }
}
