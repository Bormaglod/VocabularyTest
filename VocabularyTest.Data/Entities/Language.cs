//-----------------------------------------------------------------------
// <copyright file="Language.cs" company="Тепляшин Сергей Васильевич">
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
// <date>06.12.2016</date>
// <time>15:08</time>
// <summary>Defines the Language class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Base;
    using Infrastructure;
    using ComponentLib.Globalization;
    using Core;
    using static ColumnsHelper;
    
    public class Language : Entity
    {
        class Column : IColumn
        {
            readonly ColumnAttribute column;
            readonly Language language;
            
            public Column(Language columnLanguage, ColumnAttribute columnAttribute)
            {
                language = columnLanguage;
                column = columnAttribute;
            }

            Language IColumn.Language => language;
            
            string IColumn.Prefix => column.Prefix;
            
            string IColumn.Name => column.Name;
            
            bool IColumn.ReadOnly => column.ReadOnly;
            
            int IColumn.Index => column.Index;
            
            bool IColumn.IsCombo => column.ControlType == ControlType.Combo;

            public override string ToString() => ((IColumn)this).Name;
        }

        public Language() { }

        public Language(Culture culture)
        {
            SetFrom(culture);
        }

        public virtual string Name { get; set; }
        public virtual string AlternateName { get; set; }
        public virtual string CultureLocale { get; set; }
        public virtual int CultureIdentifier { get; set; }
        public virtual string ImageKey { get; set; }
        public virtual string DictionaryLocale { get; set; }
        public virtual IList<Theme> Themes { get; set; } = new List<Theme>();
        public virtual IList<Tense> Tenses { get; set; } = new List<Tense>();

        [Column(0, "Pronunciation", "PW")]
        public virtual bool Pronunciation { get; set; }
        
        [Column(1, "WordType", "WT", ControlType = ControlType.Combo)]
        public virtual bool WordType { get; set; }
        
        [Column(2, "Sample", "SP")]
        public virtual bool Sample { get; set; }
        
        [Column(3, "Note", "CW")]
        public virtual bool Note { get; set; }
        
        [Column(4, "Meaning", "MW")]
        public virtual bool Meaning { get; set; }
        
        public virtual IEnumerable<IColumn> VisibleColumns => GetVisibleColumns(this).Select<ColumnAttribute, IColumn>(x => new Column(this, x));
        
        public virtual IEnumerable<IColumn> Columns => GetColumns().Select<ColumnAttribute, IColumn>(x => new Column(this, x));

        public virtual void SetFrom(Culture culture)
        {
            Name = culture.Name.NullIfEmpty();
            CultureIdentifier = culture.Id;
            CultureLocale = culture.Locale.NullIfEmpty();
        }

        public virtual void AddTense(Tense tense)
        {
            tense.Language = this;
            Tenses.Add(tense);
        }

        public virtual Tense AddTense(string tenseName)
        {
            Tense tense = new Tense();
            tense.Name = tenseName;
            tense.Language = this;
            Tenses.Add(tense);
            return tense;
        }

        public virtual void RemoveTense(Tense tense)
        {
            //tense.Language = null;
            Tenses.Remove(tense);
        }

        public override string ToString() => AlternateName ?? Name;
    }
}
