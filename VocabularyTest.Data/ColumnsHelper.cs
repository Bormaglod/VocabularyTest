//-----------------------------------------------------------------------
// <copyright file="ColumnsHelper.cs" company="Тепляшин Сергей Васильевич">
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
// <date>02.11.2016</date>
// <time>12:29</time>
// <summary>Defines the ColumnsHelper class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Entities;
    
    static public class ColumnsHelper
    {
        static IEnumerable<PropertyInfo> ColumnProperties
        {
            get
            {
                List<PropertyInfo> properties = new List<PropertyInfo>();
                foreach (PropertyInfo prop in typeof(Language).GetProperties())
                {
                    ColumnAttribute attr = Attribute.GetCustomAttribute(prop, typeof(ColumnAttribute)) as ColumnAttribute;
                    if (attr != null)
                    {
                        properties.Add(prop);
                    }
                }
                
                return properties;
            }
        }
        
        static IEnumerable<Tuple<PropertyInfo, ColumnAttribute>> ColumnPropertiesWithAttribues
        {
            get
            {
                List<Tuple<PropertyInfo, ColumnAttribute>> properties = new List<Tuple<PropertyInfo, ColumnAttribute>>();
                foreach (PropertyInfo prop in typeof(Language).GetProperties())
                {
                    ColumnAttribute attr = Attribute.GetCustomAttribute(prop, typeof(ColumnAttribute)) as ColumnAttribute;
                    if (attr != null)
                    {
                        properties.Add(Tuple.Create<PropertyInfo, ColumnAttribute>(prop, attr));
                    }
                }
                
                return properties;
            }
        }
        
        static public int Count => ColumnProperties.Count();
        
        static public IEnumerable<ColumnAttribute> GetVisibleColumns(Language language)
        {
            return ColumnPropertiesWithAttribues
                .Where(x => (bool)x.Item1.GetValue(language, null))
                .Select<Tuple<PropertyInfo, ColumnAttribute>, ColumnAttribute>(y => y.Item2);
        }
        
        static public IEnumerable<ColumnAttribute> GetColumns()
        {
            return ColumnPropertiesWithAttribues
                .Select<Tuple<PropertyInfo, ColumnAttribute>, ColumnAttribute>(y => y.Item2);
        }
        
        static public bool IsVisible(Language language, int index)
        {
            return GetVisibleColumns(language).SingleOrDefault(x => x.Index == index) != null;
        }
        
        static public void SetVisible(Language language, int index, bool visible)
        {
            Tuple<PropertyInfo, ColumnAttribute> pi = ColumnPropertiesWithAttribues.SingleOrDefault(x => x.Item2.Index == index);
            pi.Item1.SetValue(language, visible, null);
        }
    }
}
