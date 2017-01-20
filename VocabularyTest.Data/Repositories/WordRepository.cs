//-----------------------------------------------------------------------
// <copyright file="WordRepository.cs" company="Тепляшин Сергей Васильевич">
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
// <date>12.12.2016</date>
// <time>13:41</time>
// <summary>Defines the WordRepository class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Repositories
{
    using NHibernate;
    using Entities;

    public class WordRepository : Repository<Word>
    {
        public WordRepository(ISession session) : base(session)
        {
        }
        
        public IQueryOver<Word> Words(Theme theme)
        {
            return Words(theme, null);
        }
        
        public IQueryOver<Word> Words(Lesson lesson)
        {
            return Words(lesson, null);
        }
        
        public IQueryOver<Word> Words(Theme theme, WordType wordType)
        {
            Word word = null;
            IQueryOver<Word, Lesson> query = Session.QueryOver<Word>(() => word)
                .JoinQueryOver(pr => pr.Entry)
                .JoinQueryOver(pr => pr.Lesson)
                .Where(x => x.Theme == theme);
            if (wordType != null)
            {
                query.Where(() => word.WordType.Id == wordType.Id);
            }
            
            return query;
        }
        
        public IQueryOver<Word> Words(Lesson lesson, WordType wordType)
        {
            Word word = null;
            IQueryOver<Word, Entry> query = Session.QueryOver<Word>(() => word)
                .JoinQueryOver(pr => pr.Entry)
                .Where(x => x.Lesson == lesson);
            if (wordType != null)
            {
                query.Where(() => word.WordType.Id == wordType.Id);
            }
            
            return query;
        }
    }
}
