//-----------------------------------------------------------------------
// <copyright file=SynonymWindow.cs company="Тепляшин Сергей Васильевич">
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
// <time>12:41</time>
// <summary>Defines the SynonymWindow class.</summary>
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
    using VocabularyTest.Addons.Core;
    using Data.Entities;
    using Data.Repositories;

    [Export(typeof(IAddon))]
    public partial class SynonymWindow : LexicalWindow
    {
        public SynonymWindow()
        {
            InitializeComponent();
        }

        protected override void RunOnce()
        {
            base.RunOnce();
            Host.MainMenu["View"].Items.AddCommand("ViewGrades", "ColumnsSeparator", "Синонимы", new ViewWindowCommand(this));
        }

        protected override IEnumerable<Word> Lexical(DictionaryRepository repo, Word word)
        {
            return repo.Synonyms(word);
        }

        protected override dictionary_type? DictionaryType()
        {
            return dictionary_type.synonym;
        }
    }
}
