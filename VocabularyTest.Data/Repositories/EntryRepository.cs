//-----------------------------------------------------------------------
// <copyright file="EntryRepository.cs" company="Тепляшин Сергей Васильевич">
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
// <date>12.12.2016</date>
// <time>9:03</time>
// <summary>Defines the EntryRepository class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Repositories
{
    using NHibernate;
    using Entities;

    public class EntryRepository : Repository<Entry>
    {
        public EntryRepository(ISession session) : base(session)
        {
        }
        
        public IQueryOver<Entry> Entries(Theme theme) => Entries(theme, null);
        
        public IQueryOver<Entry> Entries(Theme theme, Lesson lesson)
        {
            IQueryOver<Entry, Lesson> query = Session.QueryOver<Entry>()
                .JoinQueryOver(pr => pr.Lesson)
                .Where(x => x.Theme == theme);
            
            if (lesson != null)
            {
                query = query.And(x => x.Id == lesson.Id);
            }
            
            return query;
        }
    }
}
