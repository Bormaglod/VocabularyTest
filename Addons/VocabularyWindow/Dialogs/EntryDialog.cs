//-----------------------------------------------------------------------
// <copyright file="EntryDialog.cs" company="Тепляшин Сергей Васильевич">
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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using VocabularyTest.Core;
    using Data;
    using Data.Entities;

    public partial class EntryDialog : KryptonForm
    {
        readonly IHost host;

        protected EntryDialog(IHost host)
        {
            InitializeComponent();
            this.host = host;
            ActiveControl = comboLessons;
            OnInitialize();
        }

        static public Tuple<Entry, IEnumerable<Word>> Create(IWin32Window owner, IHost host)
        {
            EntryDialog dialog = new EntryDialog(host);
            if (dialog.ShowDialog(owner) == DialogResult.OK)
            {
                return dialog.OnCommitObject();
            }

            return null;
        }

        void OnInitialize()
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var lessons = session.QueryOver<Lesson>()
                        .Where(x => x.Theme == host.CurrentTheme);

                    foreach (Lesson lesson in lessons.List())
                    {
                        comboLessons.Items.Add(lesson);
                    }

                    var types = session.QueryOver<WordType>()
                        .OrderBy(x => x.Level).Asc;

                    FillWordTypes(types.List(), null);

                    Theme t = session.Get<Theme>(host.CurrentTheme.Id);
                    foreach (Language language in t.Languages)
                    {
                        int row = gridWritings.Rows.Add();
                        gridWritings.Rows[row].Cells["ColumnLanguage"].Value = language;
                    }
                }
            }
        }

        Tuple<Entry, IEnumerable<Word>> OnCommitObject()
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Entry entry = new Entry();
                        entry.Lesson = comboLessons.SelectedItem as Lesson;
                        session.SaveOrUpdate(entry);

                        List<Word> words = new List<Word>();
                        foreach (DataGridViewRow row in gridWritings.Rows)
                        {
                            string writing = row.Cells["ColumnWriting"].Value?.ToString();
                            if (string.IsNullOrWhiteSpace(writing))
                            {
                                continue;
                            }

                            Word word = new Word()
                            {
                                Entry = entry,
                                Language = row.Cells["ColumnLanguage"].Value as Language,
                                Writing = writing,
                                WordType = comboWordTypes.SelectedItem as WordType
                            };

                            session.SaveOrUpdate(word);
                            words.Add(word);
                        }

                        if (words.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            transaction.Commit();
                            return Tuple.Create<Entry, IEnumerable<Word>>(entry, words);
                        }
                    }
                    catch (ADOException ex)
                    {
                        transaction.Rollback();
                        Trace.TraceError(ErrorHelper.Message(ex));
                        ErrorHelper.ShowDbError(this, ex);
                    }
                }
            }

            return null;
        }

        void FillWordTypes(IEnumerable<WordType> types, int? parent)
        {
            IEnumerable<WordType> list = parent == null ? types.Where(x => !x.ParentId.HasValue) : types.Where(x => x.ParentId == parent);
            foreach (WordType type in list)
            {
                comboWordTypes.Items.Add(type);
                FillWordTypes(types, type.Id);
            }
        }

        void buttonClearLesson_Click(object sender, EventArgs e)
        {
            comboLessons.SelectedItem = null;
            buttonOK.Enabled = false;
        }

        void buttonClearWordType_Click(object sender, EventArgs e)
        {
            comboWordTypes.SelectedItem = null;
        }

        void comboLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = comboLessons.SelectedItem != null;
        }
    }
}
