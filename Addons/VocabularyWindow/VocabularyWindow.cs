//-----------------------------------------------------------------------
// <copyright file="VocabularyWindow.cs" company="Тепляшин Сергей Васильевич">
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
// <date>10.11.2016</date>
// <time>10:12</time>
// <summary>Defines the VocabularyWindow class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.VocabularyWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHunspell;
    using NHibernate;
    using Npgsql;
    using Core;
    using VocabularyTest.Core;
    using Data;
    using Data.Base;
    using Data.Entities;
    using Data.Infrastructure;
    using Data.Repositories;
    using WeifenLuo.WinFormsUI.Docking;

    [Export(typeof(IAddon))]
    [Export(typeof(IVocabularyWindow))]
    public partial class VocabularyWindow : ToolWindow, IVocabularyWindow
    {
        public enum SpellCheck
        {
            /// <summary>
            /// Проверка грамматики не проводилась.
            /// </summary>
            None,
            
            /// <summary>
            /// Слово написано правильно.
            /// </summary>
            Correct,
            
            /// <summary>
            /// Слово написано не правильно.
            /// </summary>
            Invalid,
            
            /// <summary>
            /// Грамматическую проверку проводить не надо.
            /// </summary>
            Skip
        }
        
        [Import(typeof(IHost))]
        IHost host { get; set; }
        
        readonly Dictionary<Word, SpellCheck> wordChecker = new Dictionary<Word, SpellCheck>();
        
        Words words;
        BindingList<Entry> entries;
        bool updated;
        Filter filter = new Filter();
        IList<WordType> types = new List<WordType>();

        event EventHandler<WordsSelectedEventArgs> wordsSelected;
        event EventHandler<EntitiesModifiedEventArgs<Lesson>> lessonContentModified;
        event EventHandler<EntitiesModifiedEventArgs<WordType>> wordTypeContentModified;
        event EventHandler<EntitiesModifiedEventArgs<Grade>> gradeContentModified;

        public VocabularyWindow()
        {
            InitializeComponent();
            backgroundSpellChecker.WorkerSupportsCancellation = true;
            CloseButton = false;
        }
        
        #region IVocabularyWindow interface implemented
        
        object locked = new object();
        
        event EventHandler<WordsSelectedEventArgs> IVocabularyWindow.WordsSelected
        {
            add
            {
                lock(locked)
                {
                    wordsSelected += value;
                }
            }
            
            remove
            {
                lock(locked)
                {
                    wordsSelected -= value;
                }
            }
        }

        event EventHandler<EntitiesModifiedEventArgs<Lesson>> IVocabularyWindow.LessonContentModified
        {
            add
            {
                lock (locked)
                {
                    lessonContentModified += value;
                }
            }

            remove
            {
                lock (locked)
                {
                    lessonContentModified -= value;
                }
            }
        }

        event EventHandler<EntitiesModifiedEventArgs<WordType>> IVocabularyWindow.WordTypeContentModified
        {
            add
            {
                lock (locked)
                {
                    wordTypeContentModified += value;
                }
            }

            remove
            {
                lock (locked)
                {
                    wordTypeContentModified -= value;
                }
            }
        }

        event EventHandler<EntitiesModifiedEventArgs<Grade>> IVocabularyWindow.GradeContentModified
        {
            add
            {
                lock (locked)
                {
                    gradeContentModified += value;
                }
            }

            remove
            {
                lock (locked)
                {
                    gradeContentModified -= value;
                }
            }
        }

        void IVocabularyWindow.DefineLexicalData(dictionary_type lexicalType)
        {
            Word[] selected = SelectedWords().OrderBy(x => x.Id).ToArray();
            if (selected.Length > 1)
            {
                using (ISession session = DataHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        Dictionary d = null;
                        try
                        {
                            for (int i = 0; i < selected.Length; i++)
                            {
                                for (int j = i + 1; j < selected.Length; j++)
                                {
                                    d = new Dictionary();
                                    d.Left = selected[i];
                                    d.Right = selected[j];
                                    d.DictionaryType = lexicalType;
                                    session.SaveOrUpdate(d);
                                }
                            }

                            transaction.Commit();
                        }
                        catch (ADOException e)
                        {
                            transaction.Rollback();
                            Trace.TraceError(ErrorHelper.Message(e));
                            PostgresException ne = e.InnerException as PostgresException;
                            if (ne != null && ne.SqlState == "23505")
                            {
                                string format = string.Empty;
                                switch (lexicalType)
                                {
                                    case dictionary_type.synonym:
                                        format = Strings.SynonymsAlreadyExist;
                                        break;
                                    case dictionary_type.antonym:
                                        format = Strings.AntnymsAlreadyExist;
                                        break;
                                    default:
                                        break;
                                }

                                KryptonMessageBox.Show(this, string.Format(format, d.Left, d.Right), Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                ErrorHelper.ShowDbError(this, e);
                            }
                        }

                    }
                }
            }
        }

        void IVocabularyWindow.Update()
        {
            CreateWordTypeColumns();
            UpdateEntries();
        }

        void IVocabularyWindow.RefreshColumns()
        {
            CreateColumns();
            UpdateEntries();
        }

        void IVocabularyWindow.SetFilter<T>(T filterValue)
        {
            if (backgroundSpellChecker.IsBusy)
            {
                backgroundSpellChecker.CancelAsync();
            }

            while (backgroundSpellChecker.IsBusy)
            {
                Application.DoEvents();
            }

            filter.Set(filterValue);
            UpdateEntries();
        }

        #endregion

        public void SpellCheckEntries()
        {
            if (host.Dictionaries != null && host.Dictionaries.Loaded && !backgroundSpellChecker.IsBusy)
            {
                backgroundSpellChecker.RunWorkerAsync();
            }
        }

        protected override void DoAddDependence()
        {
            base.DoAddDependence();
            AddDependenceItem("GlobalAddon");
        }
        
        protected override void RunOnce()
        {
            gridEntries.StateCommon.DataCell.Content.Font = host.Settings.Fonts.Grid.Font();

            host.MainMenu["View"].Items
                .AddCommand(
                    "ColumnsDialog", 
                    Strings.Columns, 
                    Images.columns_view, 
                    new ColumnsDialogCommand(this, host.CurrentTheme));
            host.MainMenu["View"].Items
                .AddSeparator(
                    "ColumnsSeparator",
                    "ColumnsDialog");

            host.MainMenu.AddMenu("Edit", "File", "Правка");
            host.MainMenu["Edit"].Items
                .AddCommand(
                    "Languages",
                    Strings.Languages,
                    Images.set_language,
                    new LanguagesDialogCommand(host, this, host.CurrentTheme)
                );
            host.MainMenu["Edit"].Items
                .AddSeparator("LanguageSeparator", "Language");
            host.MainMenu["Edit"].Items
                .AddCommand(
                    "AddEntry",
                    "LanguageSeparator",
                    Strings.AddEntry,
                    Images.textfield_add,
                    Keys.Insert,
                    new CommonCommand(AddEntry)
                );
            host.MainMenu["Edit"].Items
                .AddCommand(
                    "DeleteEntries",
                    "AddEntry",
                    Strings.DeleteEntries,
                    Images.textfield_delete,
                    Keys.Control | Keys.Delete,
                    new CommonCommand(DeleteSelectedEntries)
                );
            
            host.ToolBar
                .AddCommand(
                    "Languages",
                    Strings.Languages,
                    Images.set_language,
                    new LanguagesDialogCommand(host, this, host.CurrentTheme)
                );
            host.ToolBar.AddSeparator("LanguageSeparator", "Languages");
            host.ToolBar.AddCommand("AddEntry", "LanguageSeparator", Strings.AddEntry, Images.textfield_add, new CommonCommand(AddEntry));

            host.MainMenu["View"].Items.AddSeparator("SearchSeparator");
            host.MainMenu["View"].Items.AddCommand("ShowSearch", "SearchSeparator", Strings.ShowSearch, null);
        }
        
        protected override void Run()
        {
            CreateColumns();
            UpdateEntries();
            CreateLessonList();
            ShowWindow(host.Workbench, DockState.Document);
        }

        void AddEntry()
        {
            Tuple<Entry, IEnumerable<Word>> adding = EntryDialog.Create(this, host);
            if (adding != null)
            {
                if (filter.In(adding.Item1, adding.Item2))
                {
                    entries.Add(adding.Item1);
                    foreach (Word word in adding.Item2)
                    {
                        words.Add(word);
                        SetSpellCheck(word, SpellCheck.None);
                        CheckSpellWord(word);
                    }
                }

                DoLessonContentModified(new Lesson[] { adding.Item1.Lesson });
                DoWordTypeContentModified(new WordType[] { adding.Item2.First().WordType });
            }
        }

        void DeleteSelectedEntries()
        {
            if (gridEntries.CurrentRow == null || gridEntries.CurrentRow.IsNewRow)
            {
                return;
            }

            Stack<int> deleted = new Stack<int>();
            foreach (DataGridViewCell cell in gridEntries.SelectedCells)
            {
                if (!deleted.Contains(cell.RowIndex))
                {
                    deleted.Push(cell.RowIndex);
                }
            }

            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    List<Lesson> lessons = new List<Lesson>();
                    List<WordType> types = new List<WordType>();
                    try
                    {
                        while (deleted.Count > 0)
                        {
                            int row = deleted.Pop();

                            lessons.Add(entries[row].Lesson);

                            IEnumerable<Word> deletedWords = words[entries[row]].ToList();
                            types.AddRange(deletedWords.Select<Word, WordType>(x => x.WordType));

                            session.Delete(entries[row]);
                            entries.RemoveAt(row);
                            words.Remove(deletedWords);
                        }

                        transaction.Commit();
                        DoLessonContentModified(lessons);
                        DoWordTypeContentModified(types);
                    }
                    catch (ADOException ex)
                    {
                        transaction.Rollback();
                        Trace.TraceError(ErrorHelper.Message(ex));
                        ErrorHelper.ShowDbError(this, ex);
                        gridEntries.Refresh();
                    }
                }
            }
        }

        void CreateWordTypeColumns()
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    types = session.QueryOver<WordType>().List();
                    foreach (DataGridViewColumn item in gridEntries.Columns)
                    {
                        IColumn column = item.Tag as IColumn;
                        if (column != null && column.Prefix == "WT")
                        {
                            KryptonDataGridViewComboBoxColumn c = item as KryptonDataGridViewComboBoxColumn;
                            c.Items.Clear();
                            c.Items.Add(string.Empty);
                            foreach (WordType wt in types)
                            {
                                c.Items.Add(wt.Name.PadLeft((wt.Level - 1) * 2 + wt.Name.Length));
                            }
                        }
                    }
                }
            }
        }

        void CreateColumns()
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    gridEntries.Columns.Clear();

                    Theme theme = session.Get<Theme>(host.CurrentTheme.Id);
                    foreach (Language language in theme.Languages)
                    {
                        CreateColumnLanguage(session, language);
                    }
                }
            }

            CreateWordTypeColumns();
        }
        
        /// <summary>
        /// Метод создает колонки для соответствующего языка. При этом создается минимум одна колонка,
        /// содержащая слово языка. Дополнительно, в зависимости от настроек, создаются колоники
        /// содержашие часть речи, произношение, синонимы, антонимы и т.д.
        /// При создании колонок, последним присваиваются имена:
        /// колонке, содержащей слово языка - трехбуквенный код языка, остальным - то же имя с добавлением
        /// соответсвующего префикса. Префиксы могут быть следующими:
        /// <para>- WT - часть речи;</para>
        /// <para>- PW - произношение;</para>
        /// <para>- SP - пример;</para>
        /// <para>- CW - комментарий;</para>
        /// <para>- MW - значение.</para>
        /// <para>Таким образом имя первой колонки состоит из 3 символов, остальные из 5-ти.</para>
        /// </summary>
        /// <param name = "session"></param>
        /// <param name="lang">Язык, слова которого должны содержаться в колонках.</param>
        void CreateColumnLanguage(ISession session, Language lang)
        {
            KryptonDataGridViewTextBoxColumn column = new KryptonDataGridViewTextBoxColumn();
            column.HeaderText = string.IsNullOrWhiteSpace(lang.AlternateName) ? lang.Name : lang.AlternateName;
            column.Name = lang.CultureLocale;
            column.Width = 100;
            column.Tag = lang;
            gridEntries.Columns.Add(column);
            foreach (IColumn c in lang.VisibleColumns)
            {
                if (c.IsCombo)
                {
                    CreateColumn<KryptonDataGridViewComboBoxColumn>(lang, c);
                }
                else
                {
                    CreateColumn<KryptonDataGridViewTextBoxColumn>(lang, c);
                }
            }
        }
        
        void CreateColumn<T>(Language lang, IColumn column) where T : DataGridViewColumn, new()
        {
            T gridColumn = new T();
            gridColumn.HeaderText = column.Name;
            gridColumn.Name = column.Prefix + lang.CultureLocale;
            gridColumn.Tag = column;
            gridColumn.ReadOnly = column.ReadOnly;
            gridEntries.Columns.Add(gridColumn);
        }
        
        void UpdateEntries()
        {
            updated = true;
            try
            {
                RefreshEntries();
                gridEntries.AllowUserToAddRows = filter.Lesson != null;
                SpellCheckEntries();
            }
            finally
            {
                updated = false;
            }
        }
        
        void RefreshEntries()
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    words = new Words(session, host, filter.Lesson);
                    
                    EntryRepository e_repo = new EntryRepository(session);
                    IList<Entry> list = e_repo.Entries(host.CurrentTheme, filter.Lesson).List();
                    if (filter.WordType != null)
                    {
                        list = list.Where(x => words.Contains(x, filter.WordType)).ToList();
                    }

                    entries = new BindingList<Entry>(list);
                    entries.AddingNew += (sender, e) => e.NewObject = new Entry() { Lesson = filter.Lesson };
                    bindingEntry.DataSource = entries;
                }
            }
        }

        void CreateLessonList()
        {
            menuMove.DropDownItems.Clear();
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Lesson l = null;
                    IQueryOver<Lesson, Lesson> query = session.QueryOver<Lesson>(() => l)
                        .Where(x => x.Theme == host.CurrentTheme);
                    
                    foreach (Lesson lesson in query.List())
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem(lesson.Name);
                        item.Tag = lesson;
                        item.Click += EntryMoveToLessonClick;
                        menuMove.DropDownItems.Add(item);
                    }
                }
            }
            
            menuMove.Visible = menuMove.DropDownItems.Count > 0;
        }

        IEnumerable<T> UniqueEntitiesList<T>(IEnumerable<T> entities) where T: Entity
        {
            List<T> list = new List<T>();
            foreach (T item in entities)
            {
                if (item != null && list.FirstOrDefault(x => x.Id == item.Id) == null)
                {
                    list.Add(item);
                }
            }

            return list;
        }

        void DoLessonContentModified(IEnumerable<Lesson> lessons)
        {
            IEnumerable<Lesson> l = UniqueEntitiesList(lessons);
            if (l.Any())
            {
                lessonContentModified?.Invoke(this, new EntitiesModifiedEventArgs<Lesson>(l));
            }
        }

        void DoWordTypeContentModified(IEnumerable<WordType> wordTypes)
        {
            IEnumerable<WordType> w = UniqueEntitiesList(wordTypes);
            if (w.Any())
            {
                wordTypeContentModified?.Invoke(this, new EntitiesModifiedEventArgs<WordType>(w));
            }
        }

        void DoGradeContentModified(IEnumerable<Grade> grades)
        {
            if (grades.Any())
            {
                gradeContentModified?.Invoke(this, new EntitiesModifiedEventArgs<Grade>(grades));
            }
        }

        void EntryMoveToLessonClick(object sender, EventArgs e)
        {
            if (gridEntries.SelectedCells.Count == 1)
            {
                int rowIndex = gridEntries.SelectedCells[0].RowIndex;
                Entry entry = entries[rowIndex];
                
                Lesson old = entry.Lesson;
                entry.Lesson = (Lesson)((ToolStripMenuItem)sender).Tag;
                
                using (ISession session = DataHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        try
                        {
                            session.SaveOrUpdate(entry);
                            transaction.Commit();
                        }
                        catch (ADOException ex)
                        {
                            transaction.Rollback();
                            Trace.TraceError(ErrorHelper.Message(ex));
                            ErrorHelper.ShowDbError(this, ex);
                        }
                    }
                }

                DoLessonContentModified(new Lesson[] { old, entry.Lesson });
                if (filter.Lesson != null)
                {
                    entries.Remove(entry);
                }
            }
        }
        
        void SetSpellCheck(Word word, SpellCheck check)
        {
            if (wordChecker.ContainsKey(word))
            {
                wordChecker[word] = check;
            }
            else
            {
                wordChecker.Add(word, check);
            }
        }
        
        void CheckSpellWord(Word word)
        {
            if (!wordChecker.ContainsKey(word))
            {
                wordChecker.Add(word, SpellCheck.None);
            }
            
            if (wordChecker[word] == SpellCheck.None)
            {
                SpellFactory factory = host.Dictionaries.GetSpellFactory(word.Language);
                if (factory != null)
                {
                    wordChecker[word] = factory.Spell(word.Writing) ? SpellCheck.Correct : SpellCheck.Invalid;
                }
            }
        }
        
        IEnumerable<Word> SelectedWords()
        {
            List<Word> selected = new List<Word>();
            foreach (DataGridViewCell cell in gridEntries.SelectedCells)
            {
                Word word = GetWord(cell);
                if (word != null)
                {
                    selected.Add(word);
                }
            }
            
            return selected;
        }
        
        Word GetWord(DataGridViewCell cell)
        {
            if (cell.RowIndex < entries.Count)
            {
                Entry entry = entries[cell.RowIndex];
                IColumn column = gridEntries.Columns[cell.ColumnIndex].Tag as IColumn;
                Language lang = column == null ? (Language)gridEntries.Columns[cell.ColumnIndex].Tag : column.Language;
                if (entry != null && lang != null)
                {
                    return words[entry, lang];
                }
            }
            
            return null;
        }

        private DataGridViewRow GetRow(Word word)
        {
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].Id == word.Entry.Id)
                {
                    return gridEntries.Rows[i];
                }
            }

            return null;
        }

        void ClearWordsMenu(ToolStripMenuItem menu)
        {
            while (menu.DropDownItems.Count > 2)
            {
                menu.DropDownItems.RemoveAt(2);
            }

            menu.DropDownItems[1].Visible = false;
        }

        /// <summary>
        /// Метод создает список элементов меню, содержащий синонимы/антонимы заданного слова.
        /// </summary>
        /// <param name="word">Слово, для которого создается список синонимов/антонимов.</param>
        /// <param name="menu">Элемент меню, в котором создается список синонимов/антонимов.</param>
        /// <param name="listWords">Список слов из которых формируется меню.</param>
        void CreateWordsMenu(Word word, ToolStripMenuItem menu, IEnumerable<Word> listWords)
        {
            menu.DropDownItems[1].Visible = listWords.Any();
            if (listWords != null)
            {
                foreach (Word w in listWords)
                {
                    ToolStripMenuItem submenu = new ToolStripMenuItem()
                    {
                        Text = w?.Writing ?? string.Empty,
                        Tag = w
                    };

                    submenu.Click += MenuSelectWord;
                    menu.DropDownItems.Add(submenu);
                }
            }
        }
        
        void MenuSelectWord(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            using (ISession session = DataHelper.OpenSession())
            {
                Word word = session.Get<Word>(((Word)menu.Tag).Id);
                if (filter.Lesson != null && word.Entry.Lesson.Id != filter.Lesson.Id)
                {
                    host.ExecuteCommand(Command.SelectLesson, word.Entry.Lesson);
                }

                if (filter.Lesson == null || word.Entry.Lesson.Id == filter.Lesson.Id)
                {
                    DataGridViewRow row = GetRow(word);
                    if (row != null)
                    {
                        gridEntries.ClearSelection();
                        DataGridViewCell cell = gridEntries[word.Language.CultureLocale, row.Index];
                        cell.Selected = true;
                        if (!cell.Displayed)
                        {
                            gridEntries.FirstDisplayedCell = cell;
                        }
                    }
                }
            }
        }

        void DrawSquigly(Graphics g, Pen pen, int left, int width, int y)
        {
            int curx = left;

            while (curx < left + width)
            {
                if (curx + 2 < left + width)
                {
                    g.DrawLine(pen, curx, y, curx + 2, y + 2);
                }

                if (curx + 4 < left + width)
                {
                    g.DrawLine(pen, curx + 2, y + 2, curx + 4, y);
                }

                curx += 4;
            }
        }

        #region Editing values block

        int rowEdited = -1;
        readonly Dictionary<string, string> temp = new Dictionary<string, string>();
        
        void GridEntriesCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (words == null || gridEntries.Columns[e.ColumnIndex].Tag == null)
            {
                return;
            }
            
            if (e.RowIndex < entries.Count || rowEdited == e.RowIndex)
            {
                string columnName = gridEntries.Columns[e.ColumnIndex].Name;
                if (rowEdited == e.RowIndex && temp.ContainsKey(columnName))
                {
                    e.Value = temp[columnName];
                }
                else
                {
                    Entry entry = entries[e.RowIndex];
                    IColumn column = gridEntries.Columns[e.ColumnIndex].Tag as IColumn;
                    Language language = column == null ? (Language)gridEntries.Columns[e.ColumnIndex].Tag : column.Language;
                    Word word = words[entry, language];
                    if (word == null)
                    {
                        e.Value = string.Empty;
                    }
                    else
                    {
                        if (column == null)
                        {
                            e.Value = word.Writing;
                            if (host.Settings.View.UseGradeColors.Enabled)
                            {
                                Grade grade = words.Grade(word);
                                if (grade != null)
                                {
                                    Color color = host.Settings.View.UseGradeColors[grade.Current].Color;
                                    gridEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = color;
                                    gridEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
                                }
                            }
                        }
                        else
                        {
                            e.Value = word.Detail(column);
                        }
                    }
                }
            }
        }
        
        void GridEntriesCellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (gridEntries.CurrentRow == null || gridEntries.CurrentRow.IsNewRow)
            {
                return;
            }
            
            int col = e.ColumnIndex;
            string columnName = gridEntries.Columns[col].Name;
            string editedValue = e?.Value.ToString() ?? string.Empty;
            if (temp.Count == 0)
            {
                foreach (DataGridViewColumn column in gridEntries.Columns)
                {
                    DataGridViewCell cell = gridEntries.Rows[e.RowIndex].Cells[column.Index];
                    temp.Add(column.Name, cell?.EditedFormattedValue.ToString() ?? string.Empty);
                }
                
                rowEdited = e.RowIndex;
            }
            
            temp[columnName] = editedValue;
        }
        
        void GridEntriesCancelRowEdit(object sender, QuestionEventArgs e)
        {
            rowEdited = -1;
            temp.Clear();
        }

        void GridEntriesRowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (rowEdited == -1 || e.RowIndex >= entries.Count)
            {
                return;
            }

            Entry entry = entries[e.RowIndex];
            bool isNewEntry = entry.Id == 0;
            List<WordType> wordTypeSettings = new List<WordType>();
            List<Grade> resetGrades = new List<Grade>();
            
            foreach (DataGridViewColumn column in gridEntries.Columns)
            {
                if (!temp.ContainsKey(column.Name))
                {
                    continue;
                }

                IColumn c = column.Tag as IColumn;
                Language language = c?.Language ?? (Language)column.Tag;
                Word word = words[entry, language];
                if (word == null)
                {
                    word = entry.Add(language);
                    words.Add(word);
                }
                
                if (c == null)
                {
                    if (word.Writing != temp[column.Name])
                    {
                        Grade grade = words.Grade(word);
                        if (grade != null)
                        {
                            resetGrades.Add(grade);
                        }

                        SetSpellCheck(word, SpellCheck.None);
                    }
                    
                    word.Writing = temp[column.Name];
                }
                else
                {
                    switch (c.Prefix)
                    {
                        case "WT":
                            WordType wordType = types.SingleOrDefault(x => x.Name == temp[column.Name].Trim());
                            wordTypeSettings.AddRange(new WordType[] { word.WordType, wordType });
                            word.WordType = wordType;
                            break;
                        case "PW":
                            word.Pronunciation = temp[column.Name];
                            break;
                        case "SP":
                            word.Sample = temp[column.Name];
                            break;
                        case "CW":
                            word.Note = temp[column.Name];
                            break;
                        case "MW":
                            word.Meaning = temp[column.Name];
                            break;
                    }
                }
            }

            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        bool needRefresh = false;
                        if (entry.IsNew)
                        {
                            session.SaveOrUpdate(entry);
                        }

                        wordTypeSettings.Add(filter.WordType);
                        foreach (Word word in words.From(entry).Where(x => !string.IsNullOrWhiteSpace(x.Writing)))
                        {
                            if (filter.WordType != null && word.WordType == null && word.Id == 0)
                            {
                                wordTypeSettings.Add(word.WordType);
                                word.WordType = filter.WordType;
                                needRefresh = true;
                            }

                            session.SaveOrUpdate(word);
                        }

                        foreach (Grade grade in resetGrades)
                        {
                            grade.Current = 0;
                            session.SaveOrUpdate(grade);
                        }

                        transaction.Commit();

                        if (isNewEntry)
                        {
                            DoLessonContentModified(new Lesson[] { entry.Lesson });
                        }

                        DoWordTypeContentModified(wordTypeSettings);
                        DoGradeContentModified(resetGrades);
                        foreach (Word word in words[entry])
                        {
                            CheckSpellWord(word);
                        }

                        if (needRefresh)
                        {
                            gridEntries.Refresh();
                        }
                    }
                    catch (ADOException ex)
                    {
                        transaction.Rollback();
                        Trace.TraceError(ErrorHelper.Message(ex));
                        ErrorHelper.ShowDbError(this, ex);
                        gridEntries.Refresh();
                    }
                }
            }
            
            temp.Clear();
            rowEdited = -1;
        }
        
        #endregion
        
        void GridEntriesSelectionChanged(object sender, EventArgs e)
        {
            if (updated)
            {
                return;
            }

            wordsSelected?.Invoke(
                this, 
                new WordsSelectedEventArgs(
                    entries[gridEntries.CurrentRow.Index], 
                    SelectedWords()));
        }
        
        #region Drag&Drop block
        
        int indexOfItemUnderMouseToDrag;
        Rectangle dragBoxFromMouseDown;
        Point screenOffset;
        
        void GridEntriesCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            indexOfItemUnderMouseToDrag = e.RowIndex;

            // Remember the point where the mouse down occurred. The DragSize indicates
            // the size that the mouse can move before a drag event should be started.
            Size dragSize = SystemInformation.DragSize;

            // Create a rectangle using the DragSize, with the mouse position being
            // at the center of the rectangle.
            dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width /2),
                                                                e.Y - (dragSize.Height /2)), dragSize);
        }
        
        void GridEntriesCellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // The screenOffset is used to account for any desktop bands
                    // that may be at the top or left side of the screen when
                    // determining when to cancel the drag drop operation.
                    screenOffset = SystemInformation.WorkingArea.Location;

                    // Proceed with the drag-and-drop, passing in the list item.
                    if (indexOfItemUnderMouseToDrag < entries.Count)
                    {
                        Entry dragEntry = entries[indexOfItemUnderMouseToDrag];
                        Word dObj = SelectedWords().FirstOrDefault();
                        DragDropEffects dropEffect = gridEntries.DoDragDrop(dObj, DragDropEffects.Move | DragDropEffects.Link);

                        // If the drag operation was a move then remove the item.
                        if (dropEffect == DragDropEffects.Move)
                        {
                            if (filter.Lesson != null)
                            {
                                entries.Remove(dObj.Entry);
                            }
                        }
                        else if (dropEffect == DragDropEffects.Link)
                        {
                            if (filter.WordType != null && !words.Contains(dragEntry, filter.WordType))
                            {
                                entries.Remove(dObj.Entry);
                            }
                            else
                            {
                                Refresh();
                            }
                        }
                    }
                }
            }
        }
        
        void GridEntriesCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Reset the drag rectangle when the mouse button is raised.
            dragBoxFromMouseDown = Rectangle.Empty;
        }
        
        void GridEntriesQueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            Form form = (Form)host;
            
            // Cancel the drag if the mouse moves off the form. The screenOffset
            // takes into account any desktop bands that may be at the top or left
            // side of the screen.
            if (((Control.MousePosition.X - screenOffset.X) < form.DesktopBounds.Left) ||
                ((Control.MousePosition.X - screenOffset.X) > form.DesktopBounds.Right) ||
                ((Control.MousePosition.Y - screenOffset.Y) < form.DesktopBounds.Top) ||
                ((Control.MousePosition.Y - screenOffset.Y) > form.DesktopBounds.Bottom))
            {
                e.Action = DragAction.Cancel;
            }
        }

        #endregion

        void MenuSelectTrueWord(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Tuple<DataGridViewCell, Word> cell = (Tuple<DataGridViewCell, Word>)item.Tag;
            cell.Item1.Value = item.Text;
            SetSpellCheck(cell.Item2, SpellCheck.Correct);
            gridEntries.Refresh();
        }

        void ContextMenuEntriesOpening(object sender, CancelEventArgs e)
        {
            bool visible = false;
            IEnumerable<Word> selected = SelectedWords();
            if (selected.Any())
            {
                foreach (ToolStripMenuItem item in menuMove.DropDownItems)
                {
                    Word curWord = selected.FirstOrDefault(x => x.Entry.Lesson.Id == ((Lesson)item.Tag).Id);
                    item.Visible = curWord == null;
                    visible = visible || curWord == null;
                }
            }

            menuMove.Visible = visible;
            
            separatorTop.Visible = false;
            while (!(contextMenuEntries.Items[0] is ToolStripSeparator))
            {
                contextMenuEntries.Items.RemoveAt(0);
            }

            ClearWordsMenu(menuSynonyms);
            ClearWordsMenu(menuAntonyms);

            bool lexicEnabled = selected.Any();
            menuAntonyms.Enabled = lexicEnabled;
            menuSynonyms.Enabled = lexicEnabled;
            if (!lexicEnabled)
            {
                return;
            }

            bool canDefineLexic = selected.Count() > 1;
            menuDefineAntonyms.Enabled = canDefineLexic;
            menuDefineSynonyms.Enabled = canDefineLexic;
            if (canDefineLexic)
            {
                return;
            }

            Word word = GetWord(gridEntries.SelectedCells[0]);
            if (word == null)
            {
                return;
            }

            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Dictionary> list = session.QueryOver<Dictionary>()
                        .Where(pr => pr.Left == word || pr.Right == word)
                        .List();

                    IEnumerable<Dictionary> synonyms = list.Where(pr => pr.DictionaryType == dictionary_type.synonym);
                    CreateWordsMenu(word, menuSynonyms, synonyms.Select(x => x.Left.Id == word.Id ? x.Right : x.Left));

                    IEnumerable<Dictionary> antonyms = list.Where(pr => pr.DictionaryType == dictionary_type.antonym);
                    CreateWordsMenu(word, menuAntonyms, antonyms.Select(x => x.Left.Id == word.Id ? x.Right : x.Left));
                }
            }

            if (wordChecker.ContainsKey(word) && wordChecker[word] == SpellCheck.Invalid)
            {
                try
                {
                    SpellFactory factory = host.Dictionaries.GetSpellFactory(word.Language);
                    if (factory == null)
                    {
                        return;
                    }

                    List<string> suggestList = factory.Suggest(word.Writing);
                    if (suggestList.Count > 0)
                    {
                        separatorTop.Visible = true;
                                    
                        int i = 0;
                        foreach (string suggest in suggestList)
                        {
                            ToolStripMenuItem submenu = new ToolStripMenuItem()
                            {
                                Text = suggest,
                                Tag = Tuple.Create<DataGridViewCell, Word>(gridEntries.SelectedCells[0], word)
                            };

                            submenu.Click += MenuSelectTrueWord;
                            contextMenuEntries.Items.Insert(i++, submenu);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Trace.TraceError(ErrorHelper.Message(exception));
                }
            }
        }

        void menuColumns_Click(object sender, EventArgs e)
        {
            ColumnsDialogCommand.Execute(this, host.CurrentTheme);
        }

        void menuDefineSynonyms_Click(object sender, EventArgs e)
        {
            ((IVocabularyWindow)this).DefineLexicalData(dictionary_type.synonym);
        }

        void menuDefineAntonyms_Click(object sender, EventArgs e)
        {
            ((IVocabularyWindow)this).DefineLexicalData(dictionary_type.antonym);
        }

        void gridEntries_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.RowIndex < entries.Count)
            {
                Entry entry = entries[e.RowIndex];
                IColumn column = gridEntries.Columns[e.ColumnIndex].Tag as IColumn;
                if (column != null)
                {
                    return;
                }

                Language language = column == null ? (Language)gridEntries.Columns[e.ColumnIndex].Tag : column.Language;
                Word word = words[entry, language];
                if (word == null)
                {
                    return;
                }

                SpellCheck check = SpellCheck.None;
                if (wordChecker.ContainsKey(word))
                {
                    check = wordChecker[word];
                }

                if (check == SpellCheck.Invalid)
                {
                    SizeF size = e.Graphics.MeasureString(word.Writing, gridEntries.StateCommon.DataCell.Content.Font);
                    int width = (int)size.Width - 4;
                    if (width + 5 > e.CellBounds.Width)
                    {
                        width = e.CellBounds.Width - 5;
                    }

                    DrawSquigly(e.Graphics, new Pen(Color.Red), e.CellBounds.Left + 5, width, e.CellBounds.Bottom - 5);
                }
            }
        }

        void backgroundSpellChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            wordChecker.Clear();
            foreach (Word w in words)
            {
                if (backgroundSpellChecker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (!string.IsNullOrEmpty(w.Language.DictionaryLocale))
                {
                    CheckSpellWord(w);
                }
            }
        }

        void backgroundSpellChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridEntries.Refresh();
        }

        void buttonSpecAny2_Click(object sender, EventArgs e)
        {
            textFind.ValueText = string.Empty;
        }

        void textFind_TextChanged(object sender, EventArgs e)
        {
            
        }

        void menuDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedEntries();
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            AddEntry();
        }
    }
}
