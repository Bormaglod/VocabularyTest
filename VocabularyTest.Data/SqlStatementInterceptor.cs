//-----------------------------------------------------------------------
// <copyright file="SqlStatementInterceptor.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2016 Sergey Teplyashin. All rights reserved.
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
// <date>06.11.2014</date>
// <time>21:19</time>
// <summary>Defines the SqlStatementInterceptor class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data
{
    using System.Diagnostics;
    using NHibernate;
    using NHibernate.SqlCommand;

    public class SqlStatementInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            //Trace.TraceInformation(sql.ToString());
            return sql;
        }
    }
}
