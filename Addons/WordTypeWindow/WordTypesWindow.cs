//-----------------------------------------------------------------------
// <copyright file="WordTypesWindow.cs" company="Тепляшин Сергей Васильевич">
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
// <date>08.11.2016</date>
// <time>13:21</time>
// <summary>Defines the WordTypesWindow class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.WordTypeWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Controls;
    using NHibernate;
    using Addons;
    using Core;
    using VocabularyTest.Core;
    using Data;
    using Data.Entities;
    using WeifenLuo.WinFormsUI.Docking;
    
    [Export(typeof(IAddon))]
    public partial class WordTypesWindow : ToolWindow
    {
        [Import(typeof(IHost))]
        IHost host { get; set; }
        
        [Import(typeof(IVocabularyWindow))]
        IVocabularyWindow vocabularyWindow { get; set; }
        
        class WordTypeComparer : IEqualityComparer<Word>
        {
            public bool Equals(Word x, Word y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                {
                    return false;
                }

                if (ReferenceEquals(x.WordType, y.WordType))
                {
                    return true;
                }
                
                if (ReferenceEquals(x.WordType, null) || ReferenceEquals(y.WordType, null))
                {
                    return false;
                }
                
                return  x.WordType.Id == y.WordType.Id;
            }
            
            public int GetHashCode(Word word)
            {
                if (ReferenceEquals(word, null))
                {
                    return 0;
                }

                int hashWordType = word.WordType == null ? 0 : word.WordType.GetHashCode();
                return hashWordType;
            }
        }
        
        public WordTypesWindow()
        {
            InitializeComponent();
            
            foreach (grammatical field in Enum.GetValues(typeof(grammatical)))
            {
                Type typeField = field.GetType();
                
                foreach (FieldInfo fi in typeField.GetFields())
                {
                    if (fi.FieldType != typeof(grammatical))
                    {
                        continue;
                    }
                    
                    if (fi.Name != field.ToString())
                    {
                        continue;
                    }

                    LocalizedDescriptionAttribute attr = fi.GetCustomAttributes(typeof(LocalizedDescriptionAttribute), true).SingleOrDefault() as LocalizedDescriptionAttribute;
                    if (attr != null)
                    {
                        AddGrammaticalMenu(buttonGrammatical.DropDownItems, field, attr.Description);
                        AddGrammaticalMenu(menuGrammatical.DropDownItems, field, attr.Description);
                    }
                    
                    if (field == grammatical.none)
                    {
                        buttonGrammatical.DropDownItems.Add(new ToolStripSeparator());
                        menuGrammatical.DropDownItems.Add(new ToolStripSeparator());
                    }
                    
                    break;
                }
            }
        }
        
        public WordType CurrentWordType
        {
            get
            {
                if (treeWordTypes.SelectedNode != null && treeWordTypes.SelectedNode.Tag != null)
                {
                    TreeNodeColumn column = (TreeNodeColumn)treeWordTypes.SelectedNode;
                    return (WordType)column.Tag;
                }
                
                return null;
            }
        }
        
        protected override void DoAddDependence()
        {
            base.DoAddDependence();
            AddDependenceItem("GlobalAddon");
            AddDependenceItem("VocabularyWindow");
        }
        
        protected override void RunOnce()
        {
            host.MainMenu["View"].Items.AddCommand("ViewWordTypes", "ColumnsSeparator", Strings.WordTypes, new ViewWindowCommand(this));
            vocabularyWindow.WordTypeContentModified += VocabularyWindow_WordTypeContentModified;
        }

        protected override void Run()
        {
            treeWordTypes.BeginUpdate();
            try
            {
                treeWordTypes.Nodes.Clear();
                
                TreeNodeColumn root = new TreeNodeColumn(Strings.WordTypes);
                treeWordTypes.Nodes.Add(root);
                UpdateCountEntries();
                CreateWordTypeNodes(treeWordTypes.Nodes[0].Nodes);
                
                treeWordTypes.SelectedNode = treeWordTypes.Nodes[0];
                treeWordTypes.Nodes[0].ExpandAll();
            }
            finally
            {
                treeWordTypes.EndUpdate();
            }
            
            ShowWindow(host.Workbench, DockState.DockLeft);
        }

        void VocabularyWindow_WordTypeContentModified(object sender, EntitiesModifiedEventArgs<WordType> e)
        {
            foreach (WordType wordType in e.Entities)
            {
                UpdateCountEntries(wordType);
            }

            UpdateCountEntries();
        }

        void WordTypeModified(WordType oldWordType, WordType newWordType)
        {
            if (oldWordType != null)
            {
                UpdateCountEntries(oldWordType);
            }
            
            UpdateCountEntries(newWordType);
            UpdateCountEntries();
        }
        
        void UpdateCountEntries(WordType wordType = null)
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Word w = null;
                    Lesson l = null;
                    IQueryOver<Word, WordType> words = 
                        session.QueryOver<Word>(() => w)
                        .JoinQueryOver(pr => pr.Entry)
                        .JoinQueryOver(pr => pr.Lesson, () => l)
                        .Where(() => l.Theme == host.CurrentTheme)
                        .JoinQueryOver(pr => w.WordType);
                    if (wordType != null)
                    {
                        words.And(() => w.WordType == wordType);
                    }
                    
                    int count = words.RowCount();
                    
                    TreeNodeColumn node = 
                        wordType == null ?
                        (TreeNodeColumn)treeWordTypes.Nodes[0] :
                        GetNode(treeWordTypes.Nodes[0].Nodes, wordType);
                    node.FarText = count.ToString();
                }
            }
        }
        
        TreeNodeColumn GetNode(TreeNodeCollection nodes, WordType wordType)
        {
            TreeNodeColumn result = null;
            foreach (TreeNodeColumn node in nodes)
            {
                if (((WordType)node.Tag).Id == wordType.Id)
                {
                    result = node;
                    break;
                }
                
                result = GetNode(node.Nodes, wordType);
                if (result != null)
                {
                    break;
                }
            }
            
            return result;
        }
        
        void CreateWordTypeNodes(TreeNodeCollection nodes)
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<WordType> source = session.QueryOver<WordType>().List();
                    CreateWordTypeNodes(nodes, source);
                }
            }
        }
        
        void CreateWordTypeNodes(TreeNodeCollection nodes, IList<WordType> source, WordType parent = null)
        {
            IEnumerable<WordType> wordTypes = source.Where(x => x.ParentId.HasValue ? (parent != null && (x.ParentId == parent.Id)) : (parent == null));
            foreach (WordType wordType in wordTypes)
            {
                TreeNode node = AddWordTypeNode(nodes, wordType);
                CreateWordTypeNodes(node.Nodes, source, wordType);
            }
        }
        
        TreeNode AddWordTypeNode(TreeNodeCollection nodes, WordType wordType)
        {
            TreeNodeColumn node = new TreeNodeColumn(wordType.Name) { Tag = wordType };
            nodes.Add(node);
            UpdateCountEntries(wordType);
            return node;
        }
        
        void AddGrammaticalMenu(ToolStripItemCollection items, grammatical grammatical, string text)
        {
            ToolStripItem item = items.Add(text);
            item.Tag = grammatical;
            item.Click += GrammaticalItemClick;
            items.Add(item);
        }
        
        void GrammaticalItemClick(object sender, EventArgs e)
        {
            /*Grammatical g = (Grammatical)((ToolStripItem)sender).Tag;
            IWordType wordType = CurrentWordType;
            if (wordType == null)
            {
                return;
            }
            
            wordType.Special = g;
            RepoCollection.Get<IWordType>().Update(wordType);*/
        }
        
        void UpdateMenuGrammatical(ToolStripItemCollection menu, WordType wordType)
        {
            if (wordType == null)
            {
                return;
            }
            
            foreach (ToolStripItem item in menu)
            {
                if (item.Tag != null)
                {
                    ((ToolStripMenuItem)item).Checked = (grammatical)item.Tag == wordType.Special;
                }
            }
        }
        
        void ButtonAddClick(object sender, EventArgs e)
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    WordTypeDialog dialog  = new WordTypeDialog(host.CurrentTheme);
                    WordType wordType = dialog.CreateObject(this, CurrentWordType);
                    if (wordType != null)
                    {
                        TreeNodeCollection nodes = CurrentWordType != null ? treeWordTypes.SelectedNode.Nodes : treeWordTypes.Nodes[0].Nodes;
                        TreeNode node = AddWordTypeNode(nodes, wordType);
                        if (node.Parent != null && !node.Parent.IsExpanded)
                        {
                            node.Parent.Expand();
                        }
                    }
                }
            }
        }
        
        void ButtonEditClick(object sender, EventArgs e)
        {
            WordType wordType = CurrentWordType;
            if (wordType == null)
            {
                return;
            }
            
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    WordTypeDialog dialog  = new WordTypeDialog(host.CurrentTheme);
                    wordType = dialog.Edit(this, wordType);
                    if (wordType != null)
                    {
                        treeWordTypes.SelectedNode.Tag = wordType;
                        treeWordTypes.SelectedNode.Text = wordType.Name;
                        vocabularyWindow.Update();
                    }
                }
            }
        }
        
        void ButtonDeleteClick(object sender, EventArgs e)
        {
            WordType wordType = CurrentWordType;
            if (wordType != null)
            {
                if (KryptonMessageBox.Show(Strings.QuestionDeleteWordType, Strings.DeletingWordType, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (ISession session = DataHelper.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            try
                            {
                                session.Delete(wordType);
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

                    treeWordTypes.Nodes.Remove(treeWordTypes.SelectedNode);
                    UpdateCountEntries();
                    vocabularyWindow.Update();
                }
            }
        }
        
        void TreeWordTypesAfterSelect(object sender, TreeViewEventArgs e)
        {
            WordType wordType = CurrentWordType;
            
            menuDelete.Enabled = wordType != null;
            menuEdit.Enabled = wordType != null;
            
            buttonDelete.Enabled = wordType != null;
            buttonEdit.Enabled = wordType != null;
            
            buttonGrammatical.Enabled = wordType != null;
            menuGrammatical.Enabled = wordType != null;

            vocabularyWindow.SetFilter(wordType);
        }
        
        #region Drag&Drop block
        
        WordType wordTypeUnderMouseToDrop;
        
        void TreeWordTypesDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (!e.Data.GetDataPresent(typeof(Word)))
            {
                return;
            }
            
            TreeNode node = treeWordTypes.GetNodeAt(treeWordTypes.PointToClient(new Point(e.X, e.Y)));
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
            wordTypeUnderMouseToDrop = (WordType)column.Tag;
            if (dragObject.WordType.Id == wordTypeUnderMouseToDrop.Id)
            {
                return;
            }

            e.Effect = DragDropEffects.Link;
        }
        
        void TreeWordTypesDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Word)))
            {
                Word dragObject = (Word)e.Data.GetData(typeof(Word));
                if (e.Effect == DragDropEffects.Link)
                {
                    WordType old = dragObject.WordType;
                    dragObject.WordType = wordTypeUnderMouseToDrop;
                    using (ISession session = DataHelper.OpenSession())
                    {
                        using (ITransaction transaction = session.BeginTransaction())
                        {
                            try
                            {
                                session.SaveOrUpdate(dragObject);
                                transaction.Commit();
                            }
                            catch (ADOException ex)
                            {
                                transaction.Rollback();
                                dragObject.WordType = old;
                                Trace.TraceError(ErrorHelper.Message(ex));
                                ErrorHelper.ShowDbError(this, ex);
                            }
                        }
                    }

                    WordTypeModified(old, wordTypeUnderMouseToDrop);
                }
            }
        }
        
        #endregion
        
        void ContextMenuStrip1Opening(object sender, CancelEventArgs e)
        {
            UpdateMenuGrammatical(menuGrammatical.DropDownItems, CurrentWordType);
        }
        
        void ButtonGrammaticalDropDownOpening(object sender, EventArgs e)
        {
            UpdateMenuGrammatical(buttonGrammatical.DropDownItems, CurrentWordType);
        }
    }
}
