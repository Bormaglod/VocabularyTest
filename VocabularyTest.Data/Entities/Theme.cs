//-----------------------------------------------------------------------
// <copyright file="Theme.cs" company="Тепляшин Сергей Васильевич">
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
// <date>05.12.2016</date>
// <time>15:38</time>
// <summary>Defines the Theme class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using Base;
    
    public class Theme : Entity
    {
        public virtual string Name { get; set; }
        public virtual DateTime AccessDate { get; set; }
        public virtual bool IsHidden { get; set; }
        public virtual string Author { get; set; }
        public virtual string EMail { get; set; }
        public virtual string Note { get; set; }
        public virtual string Category { get; set; }
        public virtual string License { get; set; }
        public virtual IList<Language> Languages { get; set; } = new List<Language>();

        public virtual void AddLanguage(Language language)
        {
            language.Themes.Add(this);
            Languages.Add(language);
        }

        public virtual void RemoveLanguage(Language language)
        {
            language.Themes.Remove(this);
            Languages.Remove(language);
        }

        public virtual void ReplaceLanguage(Language replacedLanguage, Language addingLanguage)
        {
            RemoveLanguage(replacedLanguage);
            AddLanguage(addingLanguage);
        }
    }
}
