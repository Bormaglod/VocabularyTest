//-----------------------------------------------------------------------
// <copyright file="ColumnAttribute.cs" company="Тепляшин Сергей Васильевич">
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
// <date>17.05.2012</date>
// <time>13:54</time>
// <summary>Defines the ColumnAttribute class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data
{
    using System;
    
    public enum ControlType { Combo, Text }
    
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        readonly int index;
        readonly string resourceName;
        readonly string prefix;
        
        public ColumnAttribute(int index, string resourceName, string prefix)
        {
            this.index = index;
            this.resourceName = resourceName;
            this.prefix = prefix;
        }

        public string ResourceName => resourceName;

        public string Prefix => prefix;
        
        public string Name => Strings.ResourceManager.GetString(ResourceName);

        public int Index => index;

        public ControlType ControlType { get; set; } = ControlType.Text;
        
        public bool ReadOnly { get; set; }
    }
}
