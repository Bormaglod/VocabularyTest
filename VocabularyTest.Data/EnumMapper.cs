//-----------------------------------------------------------------------
// <copyright file="EnumMapper.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2015 Sergey Teplyashin. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergey-teplyashin@yandex.ru</email>
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
// <date>13.11.2014</date>
// <time>22:48</time>
// <summary>Defines the EnumMapper class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data
{
    using System.Data;
    using NHibernate.Type;

    public class EnumMapper<T> : EnumStringType<T>
    {
        public override NHibernate.SqlTypes.SqlType SqlType => new NHibernate.SqlTypes.SqlType(DbType.Object);
    }
}
