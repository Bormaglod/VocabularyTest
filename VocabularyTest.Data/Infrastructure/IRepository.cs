//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Sergey Teplyashin">
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
// <time>10:46</time>
// <summary>Defines the IRepository class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Infrastructure
{
    using System.Collections.Generic;
    using Base;
    
    public interface IRepository<TEntity> : IReadOnlyReposytory<TEntity> where TEntity: Entity
    {
        bool Add(TEntity entity);
        bool Add(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);
        bool AddOrUpdate(TEntity entity);
        bool Delete(TEntity entity);
        bool Delete(IEnumerable<TEntity> entities);
    }
}
