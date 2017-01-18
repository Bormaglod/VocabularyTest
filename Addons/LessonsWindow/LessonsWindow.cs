//-----------------------------------------------------------------------
// <copyright file=LessonsWindow.cs company="Тепляшин Сергей Васильевич">
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
// <date>27.10.2016</date>
// <time>13:55</time>
// <summary>Defines the LessonsWindow class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.LessonsWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Controls;
    using NHibernate;
    using NHibernate.Transform;
    using Core;
    using VocabularyTest.Core;
    using Data;
    using Data.Entities;
    using WeifenLuo.WinFormsUI.Docking;

    [Export(typeof(IAddon))]
    public partial class LessonsWindow : ToolWindow
    {
        class LessonCount
        {
            public Lesson Lesson { get; set; }
            public int Count { get; set; }
        }

        [Import(typeof(IHost))]
        IHost host { get; set; }
        
        [Import(typeof(IVocabularyWindow))]
        IVocabularyWindow vocabularyWindow { get; set; }
        
        public LessonsWindow()
        {
            InitializeComponent();
        }
        
        public Lesson CurrentLesson
        {
            get
            {
                if (treeLessons.SelectedNode != null && treeLessons.SelectedNode.Tag != null)
                {
                    TreeNodeColumn column = (TreeNodeColumn)treeLessons.SelectedNode;
                    return (Lesson)column.Tag;
                }

                return null;
            }
            
            set
            {
                foreach (var node in treeLessons.Nodes[0].Nodes)
                {
                    TreeNodeColumn column = node as TreeNodeColumn;
                    if (node == null)
                    {
                        continue;
                    }
                    
                    Lesson lesson = column.Tag as Lesson;
                    if (lesson == null)
                    {
                        continue;
                    }
                    
                    if (lesson.Id == value.Id)
                    {
                        treeLessons.SelectedNode = column;
                        break;
                    }
                }
            }
        }
        
        protected override void DoAddDependence()
        {
            base.DoAddDependence();
            AddDependenceItem("GlobalAddon");
            AddDependenceItem("VocabularyWindow");
        }

        protected override void ExecuteCommand(int command, object data)
        {
            Lesson lesson = data as Lesson;
            if (lesson == null)
            {
                return;
            }

            switch (command)
            {
                case Command.SelectLesson:
                    CurrentLesson = lesson;
                    break;
                default:
                    break;
            }
        }

        protected override void RunOnce()
        {
            host.MainMenu["View"].Items.AddCommand("ViewLessons", "ColumnsSeparator", Strings.Lessons, new ViewWindowCommand(this));
            host.ToolBar.AddSeparator("LanguageSeparator", "Languages");
            host.ToolBar.AddCommand("AddLesson", "LanguageSeparator", Strings.AddLesson, Images.action_add, new CommonCommand(AddLesson));
            vocabularyWindow.LessonContentModified += (sender, e) => UpdateAllCountEntries();
        }

        protected override void Run()
        {
            treeLessons.BeginUpdate();
            try
            {
                treeLessons.Nodes.Clear();
                
                TreeNodeColumn root = new TreeNodeColumn(Strings.Lessons);
                treeLessons.Nodes.Add(root);
                
                using (ISession session = DataHelper.OpenSession())
                {
                    IList<Lesson> lessons = session.QueryOver<Lesson>()
                        .Where(x => x.Theme == host.CurrentTheme).List();
                    foreach (Lesson lesson in lessons)
                    {
                        AddLessonNode(lesson);
                    }
                }

                UpdateAllCountEntries();
                treeLessons.SelectedNode = treeLessons.Nodes[0];
                treeLessons.Nodes[0].Expand();
            }
            finally
            {
                treeLessons.EndUpdate();
            }
            
            ShowWindow(host.Workbench, DockState.DockLeft);
        }

        void AddLesson()
        {
            LessonDialog dialog = new LessonDialog(host.CurrentTheme);
            Lesson lesson = dialog.CreateObject(this);
            if (lesson != null)
            {
                AddLessonNode(lesson);
                treeLessons.Nodes[0].Expand();
            }
        }

        void UpdateAllCountEntries()
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    LessonCount result = null;
                    IList<LessonCount> items = session.QueryOver<Entry>()
                        .SelectList(list => list
                            .SelectGroup(pr => pr.Lesson).WithAlias(() => result.Lesson)
                            .SelectCount(pr => pr.Id).WithAlias(() => result.Count))
                        .TransformUsing(Transformers.AliasToBean<LessonCount>())
                        .List<LessonCount>();

                    IEnumerable<TreeNodeColumn> nodes = treeLessons.Nodes[0].Nodes.OfType<TreeNodeColumn>();
                    foreach (TreeNodeColumn node in nodes)
                    {
                        Lesson lesson = (Lesson)node.Tag;
                        var item = items.FirstOrDefault(x => x.Lesson.Id == lesson.Id);
                        node.FarText = item?.Count.ToString() ?? "0";
                    }

                    ((TreeNodeColumn)treeLessons.Nodes[0]).FarText = items.Sum(x => x.Count).ToString();
                }
            }
        }
        
        void AddLessonNode(Lesson lesson)
        {
            TreeNodeColumn node = new TreeNodeColumn(lesson.Name);
            node.Tag = lesson;
            node.FarText = "0";
            treeLessons.Nodes[0].Nodes.Add(node);
        }
        
        void ButtonAddClick(object sender, EventArgs e)
        {
            AddLesson();
        }
        
        void ButtonEditClick(object sender, EventArgs e)
        {
            Lesson lesson = CurrentLesson;
            if (lesson != null)
            {
                LessonDialog dialog = new LessonDialog(host.CurrentTheme);
                lesson = dialog.Edit(this, lesson);
                if (lesson != null)
                {
                    treeLessons.SelectedNode.Tag = lesson;
                    treeLessons.SelectedNode.Text = lesson.Name;
                }
            }
        }
        
        void ButtonDeleteClick(object sender, EventArgs e)
        {
            Lesson lesson = CurrentLesson;
            if (lesson != null)
            {
                if (KryptonMessageBox.Show(Strings.QuestionDeleteLesson, Strings.DeletingLesson, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (ISession session = DataHelper.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            try
                            {
                                session.Delete(lesson);
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

                    treeLessons.Nodes.Remove(treeLessons.SelectedNode);
                    UpdateAllCountEntries();
                }
            }
        }
        
        #region Drag&Drop block
        
        Lesson lessonUnderMouseToDrop;
        
        void TreeLessonsDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Word)))
            {
                Word dragObject = (Word)e.Data.GetData(typeof(Word));
                if (e.Effect == DragDropEffects.Move)
                {
                    using (ISession session = DataHelper.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            Lesson old = dragObject.Entry.Lesson;
                            try
                            {
                                dragObject.Entry.Lesson = lessonUnderMouseToDrop;
                                session.SaveOrUpdate(dragObject.Entry);
                                transaction.Commit();
                            }
                            catch (ADOException ex)
                            {
                                transaction.Rollback();
                                dragObject.Entry.Lesson = old;
                                Trace.TraceError(ErrorHelper.Message(ex));
                                ErrorHelper.ShowDbError(this, ex);
                            }
                        }
                    }

                    UpdateAllCountEntries();
                }
            }
        }
        
        void TreeLessonsDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (!e.Data.GetDataPresent(typeof(Word)))
            {
                return;
            }
            
            TreeNode node = treeLessons.GetNodeAt(treeLessons.PointToClient(new Point(e.X, e.Y)));
            
            if (node == null)
            {
                return;
            }
            
            TreeNodeColumn column = node as TreeNodeColumn;
            if (column == null || column.Tag == null)
            {
                return;
            }

            Word dragObject = (Word)e.Data.GetData(typeof(Word));
            lessonUnderMouseToDrop = (Lesson)column.Tag;
            if (dragObject.Entry.Lesson.Id == lessonUnderMouseToDrop.Id)
            {
                return;
            }

            e.Effect = DragDropEffects.Move;
        }
        
        #endregion
        
        void TreeLessonsAfterSelect(object sender, TreeViewEventArgs e)
        {
            Lesson lesson = CurrentLesson;
            
            menuDelete.Enabled = lesson != null;
            menuEdit.Enabled = lesson != null;
            
            buttonDelete.Enabled = lesson != null;
            buttonEdit.Enabled = lesson != null;

            vocabularyWindow.SetFilter(lesson);
        }
    }
}
