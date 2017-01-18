//-----------------------------------------------------------------------
// <copyright file="FormCollection.cs" company="Sergey Teplyashin">
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
    #region Using directives
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Globalization;
    using Core;
    using Data;
    using Data.Entities;
    using NHibernate;
    
    #endregion
    
    public partial class ThemeDialog : KryptonForm
    {
        public ThemeDialog()
        {
            InitializeComponent();

            IList<Culture> cultures = Cultures.CreateListCultures();
            Cultures.FillCountriesCollection(comboCulture1.Items, cultures);
            Cultures.FillCountriesCollection(comboCulture2.Items, cultures);
            
            textName.Text = Environment.UserName;
        }

        Culture Culture1 => comboCulture1?.SelectedItem as Culture;
        
        Culture Culture2 => comboCulture2?.SelectedItem as Culture;

        static public Theme Create(IWin32Window owner) => ShowDialog(owner, new ThemeDialog(), new Theme());

        static public bool Edit(IWin32Window owner, Theme theme)
        {
            ThemeDialog dialog = new ThemeDialog();
            dialog.FillControlValues(theme);
            return ShowDialog(owner, dialog, theme) != null;
        }

        static Theme ShowDialog(IWin32Window owner, ThemeDialog dialog, Theme theme)
        {
            if (dialog.ShowDialog(owner) == DialogResult.OK)
            {
                dialog.FillThemeProperties(theme);
                using (ISession session = DataHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        try
                        {
                            dialog.CreateLanguageProperties(session, theme, dialog.Culture1);
                            dialog.CreateLanguageProperties(session, theme, dialog.Culture2);
                            session.SaveOrUpdate(theme);
                            transaction.Commit();
                            return theme;
                        }
                        catch (ADOException e)
                        {
                            transaction.Rollback();
                            Trace.TraceError(ErrorHelper.Message(e));
                            ErrorHelper.ShowDbError(dialog, e);
                        }
                    }
                }
            }

            return null;
        }

        void FillControlValues(Theme theme)
        {
            textHeader.Text = theme.Name;
            textName.Text = theme.Author;
            textEmail.Text = theme.EMail;
            textComment.Text = theme.Note;
            UpdateComboBox(comboCategory, theme.Category);
            UpdateComboBox(comboLicense, theme.License);
            groupLanguages.Visible = false;
            groupCommon.Size = new Size(groupCommon.Size.Width, groupCommon.Size.Height + 123);
            MinimumSize = new Size(MinimumSize.Width, MinimumSize.Height - 123);
            Size = new Size(Size.Width, Size.Height - 123);
        }

        void CreateLanguageProperties(ISession session, Theme theme, Culture culture)
        {
            if (culture == null)
            {
                return;
            }

            Language language = session.QueryOver<Language>().Where(pr => pr.CultureIdentifier == culture.Id).SingleOrDefault() ?? new Language(culture);
            theme.AddLanguage(language);
        }
        
        void UpdateComboBox(KryptonComboBox box, string findText)
        {
            // FIXME: При установке текста в комбо он выделяется, а не должен (причем в стандартном ComboBox такого нет)
            if (string.IsNullOrEmpty(findText))
            {
                box.Text = string.Empty;
            }
            else
            {
                int c = box.FindString(findText);
                if (c != -1)
                {
                    box.SelectedIndex = c;
                    box.SelectionStart = findText.Length;
                    box.SelectionLength = box.Text.Length - box.SelectionStart;
                }
                else
                {
                    box.Text = findText;
                }
            }
        }
        
        void FillThemeProperties(Theme theme)
        {
            theme.Name = textHeader.Text.NullIfEmpty();
            theme.Author = textName.Text.NullIfEmpty();
            theme.EMail = textEmail.Text.NullIfEmpty();
            theme.Note = textComment.Text.NullIfEmpty();
            theme.Category = comboCategory.Text.NullIfEmpty();
            theme.License = comboLicense.Text.NullIfEmpty();
            theme.AccessDate = DateTime.Now;
        }
        
        void ButtonSpecAny1Click(object sender, EventArgs e)
        {
            comboCategory.Text = string.Empty;
        }
        
        void ButtonSpecAny2Click(object sender, EventArgs e)
        {
            comboLicense.Text = string.Empty;
        }
    }
}
