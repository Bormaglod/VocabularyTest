//-----------------------------------------------------------------------
// <copyright file="Words.cs" company="Тепляшин Сергей Васильевич">
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
// <date>15.12.2016</date>
// <time>14:38</time>
// <summary>Defines the Words class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.VocabularyWindow
{
    using System.Collections.Generic;
    using System.Linq;
    using NHibernate;
    using Data.Entities;
    using Data.Repositories;

    public class Words
    {
        readonly IList<Word> words;
        readonly IList<Grade> grades;
        
        public Words(ISession session, IHost host, Lesson lesson)
        {
            WordRepository w_repo = new WordRepository(session);
            IQueryOver<Word> query = lesson == null ?
                w_repo.Words(host.CurrentTheme) :
                w_repo.Words(lesson);
            words = query.List();

            grades = session.QueryOver<Grade>()
                .Where(x => x.User == host.User)
                .List();
        }

        public IEnumerator<Word> GetEnumerator() => words.GetEnumerator();

        public Word this[Entry entry, Language language] => All().SingleOrDefault(x => x.Entry.Id == entry.Id && x.Language.Id == language.Id);

        public IEnumerable<Word> this[Entry entry] => From(entry);

        public IEnumerable<Word> All() => words;
        
        public IEnumerable<Word> From(Entry entry) => All().Where(x => x.Entry.Id == entry.Id);
        
        public IEnumerable<Word> From(WordType wordType) => All().Where(x => x.WordType != null && x.WordType.Id == wordType.Id);

        public IEnumerable<Word> From(Entry entry, WordType wordType) => All().Where(x => x.Entry.Id == entry.Id && x.WordType != null && x.WordType.Id == wordType.Id);

        public Grade Grade(Word word) => grades.Where(x => x.Word.Id == word.Id).SingleOrDefault();
        
        public bool Contains(Entry entry, WordType wordType) => From(entry, wordType).Any();

        public void Add(Word word)
        {
            words.Add(word);
        }

        public void Remove(IEnumerable<Word> deletedWords)
        {
            foreach (Word word in deletedWords)
            {
                words.Remove(word);
            }
        }
    }
}
