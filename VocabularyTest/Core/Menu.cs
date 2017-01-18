//-----------------------------------------------------------------------
// <copyright file="Menu.cs" company="Тепляшин Сергей Васильевич">
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
// <date>21.11.2016</date>
// <time>8:57</time>
// <summary>Defines the Menu class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Addons;
    
    public class Menu : IMenu
    {
        readonly List<IMenuItem> items = new List<IMenuItem>();
        readonly ToolStripItemCollection itemCollection;
        
        class MenuItem : IMenuItem
        {
            readonly ToolStripItem item;
            readonly Menu items;
            
            public MenuItem(ToolStripItem item)
            {
                this.item = item;
                
                ToolStripMenuItem menuItem = item as ToolStripMenuItem;
                items = menuItem == null ? null : new Menu(menuItem.DropDownItems);
            }
            
            public string Name => item.Name.Substring(8);

            public IMenu Items => items;
            
            public ToolStripItem Item => item;
        }
        
        public Menu(ToolStripItemCollection itemCollection)
        {
            this.itemCollection = itemCollection;
            foreach (ToolStripItem item in itemCollection)
            {
                items.Add(new MenuItem(item));
            }
        }
        
        IMenuItem IMenu.this[string name] => items.FirstOrDefault(x => x.Name == name);
        
        IEnumerable<IMenuItem> IMenu.Items => items;
        
        IMenuItem IMenu.AddMenu(string name, string afterMenuName, string text)
        {
            return ((IMenu)this).AddCommand(name, afterMenuName, text, null, Keys.None, null);
        }
        
        IMenuItem IMenu.AddCommand(string name, string text, ICommand command)
        {
            return ((IMenu)this).AddCommand(name, string.Empty, text, null, Keys.None, command);
        }
        
        IMenuItem IMenu.AddCommand(string name, string text, Image image, ICommand command)
        {
            return ((IMenu)this).AddCommand(name, string.Empty, text, image, Keys.None, command);
        }
        
        IMenuItem IMenu.AddCommand(string name, string afterMenuName, string text, ICommand command)
        {
            return ((IMenu)this).AddCommand(name, afterMenuName, text, null, Keys.None, command);
        }
        
        IMenuItem IMenu.AddCommand(string name, string afterMenuName, string text, Image image, ICommand command)
        {
            return ((IMenu)this).AddCommand(name, afterMenuName, text, null, Keys.None, command);
        }

        IMenuItem IMenu.AddCommand(string name, string afterMenuName, string text, Image image, Keys keys, ICommand command)
        {
            IMenuItem menuItem = ((IMenu)this)[name];
            if (menuItem != null)
            {
                return menuItem;
            }

            menuItem = ((IMenu)this)[afterMenuName];
            int index = menuItem == null ? 0 : itemCollection.IndexOf(((MenuItem)menuItem).Item) + 1;

            ToolStripMenuItem item = new ToolStripMenuItem(text);
            item.Name = "menuItem" + name;
            item.Image = image;
            item.ShortcutKeys = keys;
            if (command != null)
            {
                item.Click += (sender, e) => command.Execute(sender);
            }

            itemCollection.Insert(index, item);

            IMenuItem newMenuItem = new MenuItem(item);
            items.Add(newMenuItem);

            return newMenuItem;
        }

        IMenuItem IMenu.AddSeparator(string name)
        {
            return ((IMenu)this).AddSeparator(name, string.Empty);
        }
        
        IMenuItem IMenu.AddSeparator(string name, string afterMenuName)
        {
            IMenuItem menuItem = ((IMenu)this)[name];
            if (menuItem != null)
            {
                return menuItem;
            }
            
            menuItem = ((IMenu)this)[afterMenuName];
            int index = menuItem == null ? itemCollection.Count : itemCollection.IndexOf(((MenuItem)menuItem).Item) + 1;
            
            ToolStripSeparator item = new ToolStripSeparator();
            item.Name = "menuItem" + name;
            itemCollection.Insert(index, item);
            
            IMenuItem newMenuItem = new MenuItem(item);
            items.Add(newMenuItem);
            
            return newMenuItem;
        }
        
        /*IMenu IMenu.Path(string path)
        {
            VocabularyMenu newMenu = new VocabularyMenu(menu);
            newMenu.currentPath = path;
            return newMenu;
        }
        
        IMenu IMenu.Menu(string name, string text)
        {
            return ((IMenu)this).Menu(name, string.Empty, text);
        }
        
        IMenu IMenu.Menu(string name, string beforeMenuName, string text)
        {
            ToolStripItemCollection items = GetMenuItems(currentPath);
            
            string menuName = string.Format("menuItem{0}", name);
            ToolStripMenuItem menuItem = (ToolStripMenuItem)items[menuName];
            
            if (menuItem == null)
            {
                menuItem = new ToolStripMenuItem(text);
                menuItem.Name = menuName;
                items.Insert(GetMenuIndex(items, beforeMenuName), menuItem);
            }
            
            VocabularyMenu newMenu = new VocabularyMenu(menu);
            if (currentPath[currentPath.Length - 1] != '/')
            {
                currentPath += "/";
            }
            
            newMenu.currentPath = currentPath + name;
            return newMenu;
        }
        
        IMenu IMenu.Command(string name, string text, Image image, ICommand command)
        {
            return ((IMenu)this).Command(name, string.Empty, text, image, command);
        }
        
        IMenu IMenu.Command(string name, string beforeMenuName, string text, Image image, ICommand command)
        {
            ToolStripItemCollection items = GetMenuItems(currentPath);
            
            ToolStripMenuItem menuItem = new ToolStripMenuItem(text);
            menuItem.Name = string.Format("menuItem{0}", name);
            menuItem.Image = image;
            menuItem.Click += (object sender, EventArgs e) => command.Execute(sender);
            //menuItem.Checked = 
            items.Insert(GetMenuIndex(items, beforeMenuName), menuItem);
            
            return this;
        }
        
        IMenu IMenu.Separator(string name)
        {
            return ((IMenu)this).Separator(name, string.Empty);
        }
        
        IMenu IMenu.Separator(string name, string beforeMenuName)
        {
            ToolStripItemCollection items = GetMenuItems(currentPath);
            ToolStripSeparator separator = new ToolStripSeparator();
            separator.Name = string.Format("menuItem{0}", name);
            items.Insert(GetMenuIndex(items, beforeMenuName), separator);
            
            return this;
        }
        
        ToolStripItemCollection GetMenuItems(string path)
        {
            string[] names = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            ToolStripItemCollection items = menu.Items;
            if (names.Length == 0)
            {
                return items;
            }
            
            for (int i = 0; i < names.Length; i++)
            {
                string itemName = string.Format("menuItem{0}", names[i]);
                ToolStripMenuItem item = (ToolStripMenuItem)items[itemName];
                if (item == null)
                {
                    throw new Exception(string.Format("Menu item '{0}' not found", names[i]));
                }
                
                items = item.DropDownItems;
            }
            
            return items;
        }
        
        int GetMenuIndex(ToolStripItemCollection items, string beforeMenuName)
        {
            int index = items.IndexOfKey(string.Format("menuItem{0}", beforeMenuName));
            if (index == -1)
            {
                index = items.Count;
            }
            
            return index;
        }*/
    }
}
