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
    using System;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Windows.Forms;
    using NHibernate;
    using NHibernate.Criterion;
    using Data;
    using Data.Entities;
    using Addons;
    using Core;
    using WeifenLuo.WinFormsUI.Docking;
    
    [Export(typeof(IAddon))]
    public partial class StartPageWindow : ToolWindow
    {
        [Import(typeof(IHost))]
        IHost host { get; set; }
        
        public StartPageWindow()
        {
            InitializeComponent();
            Autostart = true;
        }
        
        protected override void RunOnce()
        {
            gridRecentFiles.Rows.Clear();
            using (ISession session = DataHelper.OpenSession())
            {
                foreach (Theme theme in session.QueryOver<Theme>().OrderBy(x => x.AccessDate).Desc().List())
                {
                    int row = gridRecentFiles.Rows.Add();
                    gridRecentFiles.Rows[row].Cells["ColumnName"].Value = Path.GetFileName(theme.Name);
                    gridRecentFiles.Rows[row].Cells["ColumnOpened"].Value = theme.AccessDate.ToString();
                    gridRecentFiles.Rows[row].Cells["ColumnAction"].Value = Strings.Open;
                    gridRecentFiles.Rows[row].Cells["ColumnStartPractice"].Value = Strings.Practice;
                    gridRecentFiles.Rows[row].Tag = theme;
                }
            }
        }
        
        protected override void Run()
        {
            host.ToolBar.Visible = false;
            Show(host.Workbench, DockState.Document);
        }
        
        protected override void OnHide()
        {
            base.OnHide();
            host.ToolBar.Visible = true;
        }
        
        void ButtonCreateClick(object sender, EventArgs e)
        {
            if (!host.Create())
            {
                ShowWindow(host.Workbench, DockState.Document);
            }
            else
            {
                if (!IsHidden)
                {
                    Hide();
                }
            }
        }
        
        void ButtonLoadClick(object sender, EventArgs e)
        {

        }
        
        void GridRecentFilesCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Theme theme = (Theme)gridRecentFiles.Rows[e.RowIndex].Tag;
            string columnName = gridRecentFiles.Columns[e.ColumnIndex].Name;
            switch (columnName)
            {
                case "ColumnAction":
                    if (!host.Open(theme))
                    {
                        ShowWindow(host.Workbench, DockState.Document);
                    }
                    else
                    {
                        if (!IsHidden)
                        {
                            Hide();
                        }
                    }
                    
                    break;
                case "ColumnStartPractice":
                    host.StartPractice(theme);
                	break;
            }
        }

        void buttonDelete_Click(object sender, EventArgs e)
        {
            Theme theme = (Theme)gridRecentFiles.CurrentRow.Tag;
            if (host.Delete(theme))
            {
                gridRecentFiles.Rows.RemoveAt(gridRecentFiles.CurrentRow.Index);
            }
        }

        void buttonHide_Click(object sender, EventArgs e)
        {

        }
    }
}
