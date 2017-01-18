//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2016 Sergey Teplyashin. All rights reserved.
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
// <date>21.11.2014</date>
// <time>13:31</time>
// <summary>Defines the Repository class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Repositories
{
    using System.Collections.Generic;
    using NHibernate;
    using Base;
    using Infrastructure;

    public class Repository<T> : IRepository<T> where T: Entity
    {
        readonly ISession session;
        
        public Repository(ISession session)
        {
            this.session = session;
        }

        public ISession Session => session;
        
        #region IRepository<T> Members
        
        public virtual bool Add(T entity)
        {
            Session.Save(entity);
            return true;
        }
        
        public virtual bool Add(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                Add(entity);
            }
            
            return true;
        }
        
        public virtual bool Update(T entity)
        {
            Session.Update(entity);
            return true;
        }
        
        public virtual bool AddOrUpdate(T entity)
        {
            Session.SaveOrUpdate(entity);
            return true;
        }
        
        public virtual bool Delete(T entity)
        {
            Session.Delete(entity);
            return true;
        }

        public virtual bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                Delete(entity);
            }
            
            return true;
        }
        
        #endregion
        
        #region IReadOnlyRepository Members
        
        public virtual T Get(int id) => Session.Get<T>(id);
        
        public virtual ICriteria All() => Session.CreateCriteria<T>();
        
        #endregion
    }
}
