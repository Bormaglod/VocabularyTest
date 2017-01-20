//-----------------------------------------------------------------------
// <copyright file=LexicalWindow.cs company="Тепляшин Сергей Васильевич">
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
// <date>18.01.2017</date>
// <time>12:34</time>
// <summary>Defines the LexicalWindow class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.LexicalWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NHibernate;
    using VocabularyTest.Addons.Core;
    using VocabularyTest.Data;
    using VocabularyTest.Data.Entities;
    using VocabularyTest.Data.Repositories;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class LexicalWindow : ToolWindow
    {
        [Import(typeof(IHost))]
        IHost host { get; set; }

        [Import(typeof(IVocabularyWindow))]
        IVocabularyWindow vocabularyWindow { get; set; }

        IEnumerable<Word> lexical;

        public LexicalWindow()
        {
            InitializeComponent();
        }

        protected IHost Host => host;

        protected override void DoAddDependence()
        {
            base.DoAddDependence();
            AddDependenceItem("GlobalAddon");
            AddDependenceItem("VocabularyWindow");
        }

        protected override void RunOnce()
        {
            base.RunOnce();
            vocabularyWindow.WordsSelected += (sender, e) => Update(e.Words);
        }

        protected override void Run()
        {
            ShowWindow(host.Workbench, DockState.DockRight);
        }

        protected virtual IEnumerable<Word> Lexical(DictionaryRepository repo, Word word) => null;

        protected virtual dictionary_type? DictionaryType() => null;

        void Update(IEnumerable<Word> words)
        {
            int count = words.Count();
            buttonDelete.Enabled = count == 1;
            buttonDefine.Enabled = count > 1;
            listLexical.Enabled = count > 0;

            listLexical.Items.Clear();
            if (count == 1)
            {
                Update(words.First());
            }
        }

        void Update(Word word)
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    DictionaryRepository repo = new DictionaryRepository(session);
                    foreach (Word w in Lexical(repo, word))
                    {
                        listLexical.Items.Add(w);
                    }
                }
            }
        }

        void buttonDefine_Click(object sender, EventArgs e)
        {
            vocabularyWindow.DefineLexicalData(DictionaryType().Value);
        }

        void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
