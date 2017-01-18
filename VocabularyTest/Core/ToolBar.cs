//-----------------------------------------------------------------------
// <copyright file="ToolBar.cs" company="Тепляшин Сергей Васильевич">
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
// <date>21.11.2016</date>
// <time>13:34</time>
// <summary>Defines the ToolBar class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Addons;
    
    public class ToolBar : IToolBar
    {
        readonly ToolStrip buttons;
    
        public ToolBar(ToolStrip buttons)
        {
            this.buttons = buttons;
        }

        ToolStripItem this[string name] => buttons.Items.OfType<ToolStripItem>().FirstOrDefault(x => x.Name == name);

        bool IToolBar.Visible
        {
            get { return buttons.Visible; }
            set { buttons.Visible = value; }
        }

        void IToolBar.AddCommand(string name, string text, Image image, ICommand command)
        {
            ((IToolBar)this).AddCommand(name, null, text, image, command);
        }

        void IToolBar.AddCommand(string name, string afterMenuName, string text, Image image, ICommand command)
        {
            ToolStripButton button = CreateButton<ToolStripButton>(name, afterMenuName);
            if (button == null)
            {
                return;
            }

            button.Text = text;
            button.Image = image;
            button.Click += (object sender, EventArgs e) => command.Execute(sender);

            int k1 = string.IsNullOrWhiteSpace(text) ? 0 : 1;
            int k2 = image == null ? 0 : 1;
            button.DisplayStyle = (ToolStripItemDisplayStyle)((k2 << 1) + k1);
        }

        void IToolBar.AddSeparator(string name)
        {
            ((IToolBar)this).AddSeparator(name, null);
        }

        void IToolBar.AddSeparator(string name, string afterMenuName)
        {
            CreateButton<ToolStripSeparator>(name, afterMenuName);
        }

        T CreateButton<T>(string name, string afterMenuName) where T : ToolStripItem, new()
        {
            name = string.Format("toolButton{0}", name);
            afterMenuName = string.Format("toolButton{0}", afterMenuName);

            ToolStripItem item = this[name];
            if (item != null)
            {
                return null;
            }

            item = this[afterMenuName];
            int index = item == null ? 0 : buttons.Items.IndexOfKey(afterMenuName) + 1;
            T button = new T();
            button.Name = name;

            buttons.Items.Insert(index, button);
            return button;
        }
    }
}
