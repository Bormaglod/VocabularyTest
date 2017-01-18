//-----------------------------------------------------------------------
// <copyright file="ColumnsDialog.cs" company="Тепляшин Сергей Васильевич">
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
// <date>29.11.2010</date>
// <time>12:29</time>
// <summary>Defines the ColumnsDialog class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.VocabularyWindow
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using VocabularyTest.Core;
    using Data;
    using Data.Entities;
    using Data.Infrastructure;
    using Data.Repositories;
    
    public partial class ColumnsDialog : KryptonForm
    {
        Language current;
        Dictionary<Language, BitArray> columns = new Dictionary<Language, BitArray>();
        
        public ColumnsDialog()
        {
            InitializeComponent();
        }
        
        public static bool ShowDialog(IWin32Window owner, Theme theme)
        {
            ColumnsDialog dialog = new ColumnsDialog();
            return dialog.ShowDialog(owner, theme.Id);
        }
        
        public bool ShowDialog(IWin32Window owner, int themeId)
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Theme theme = session.Get<Theme>(themeId);
                    Fill(theme);
                    if (ShowDialog(owner) == DialogResult.OK)
                    {
                        try
                        {
                            Repository<Language> repo = new Repository<Language>(session);
                            foreach (Language language in theme.Languages)
                            {
                                foreach (IColumn c in language.Columns)
                                {
                                    ColumnsHelper.SetVisible(language, c.Index, columns[language][c.Index]);
                                }
                                
                                repo.Update(language);
                            }
                            
                            transaction.Commit();
                        }
                        catch (ADOException ex)
                        {
                            transaction.Rollback();
                            Trace.TraceError(ErrorHelper.Message(ex));
                            ErrorHelper.ShowDbError(this, ex);
                        }
                        
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        void Fill(Theme theme)
        {
            foreach (Language language in theme.Languages)
            {
                listLang.Items.Add(language);
                BitArray ba = new BitArray(ColumnsHelper.GetColumns().Count(), false);
                
                foreach (IColumn column in language.VisibleColumns)
                {
                    ba[column.Index] = true;
                }
                
                columns.Add(language, ba);
            }
            
            int y = 47;
            foreach (IColumn column in theme.Languages.First().Columns)
            {
                KryptonCheckBox check = new KryptonCheckBox();
                check.Text = column.Name;
                check.Location = new Point(145, y);
                check.CheckedChanged += ColumnCheckedChanged;
                check.Tag = column;
                check.Enabled = false;
                Controls.Add(check);
                y += 22;
            }
            
            if (listLang.Items.Count > 0)
            {
                listLang.SelectedIndex = 0;
            }
        }

        bool updating;
        void ColumnCheckedChanged(object sender, EventArgs e)
        {
            if (updating)
            {
                return;
            }
            
            KryptonCheckBox check = sender as KryptonCheckBox;
            columns[current][((IColumn)check.Tag).Index] = check.Checked;
        }
        
        void FillColumnsView()
        {
            foreach (KryptonCheckBox check in Controls.OfType<KryptonCheckBox>())
            {
                check.Enabled = current != null;
                if (check.Enabled)
                {
                    updating = true;
                    try
                    {
                        check.Checked = columns[current][((IColumn)check.Tag).Index];
                    }
                    finally
                    {
                        updating = false;
                    }
                }
            }
        }
        
        void ListLangSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listLang.SelectedIndex != -1)
            {
                current = (Language)listLang.SelectedItem;
                FillColumnsView();
            }
            else
            {
                current = null;
            }
        }
    }
}
