//-----------------------------------------------------------------------
// <copyright file="Word.cs" company="Тепляшин Сергей Васильевич">
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
// <time>9:29</time>
// <summary>Defines the Word class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Entities
{
    using Base;
    using Infrastructure;
    
    public class Word : Entity
    {
        public virtual Language Language { get; set; }
        public virtual Entry Entry { get; set; }
        public virtual string Writing { get; set; }
        public virtual WordType WordType { get; set; }
        public virtual string Pronunciation { get; set; }
        public virtual string Sample { get; set; }
        public virtual string Meaning { get; set; }
        public virtual string SoundPath { get; set; }
        public virtual string Note { get; set; }
        
        public virtual string Detail(IColumn column)
        {
            switch (column.Prefix)
            {
                case "WT":
                    return WordType?.Name ?? string.Empty;
                case "PW":
                    return Pronunciation;
                case "SP":
                    return Sample;
                case "CW":
                    return Note;
                case "MW":
                    return Meaning;
            }
            
            return null;
        }

        public override string ToString() => Writing;
    }
}
