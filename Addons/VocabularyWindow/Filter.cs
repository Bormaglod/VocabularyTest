//-----------------------------------------------------------------------
// <copyright file=Filter.cs company="Тепляшин Сергей Васильевич">
//     Copyright (c) 2010-2017 Тепляшин Сергей Васильевич. All rights reserved.
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
// <date>12.01.2017</date>
// <time>09:56</time>
// <summary>Defines the Filter class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.VocabularyWindow
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Base;
    using Data.Entities;

    public class Filter
    {
        public Lesson Lesson { get; set; }

        public WordType WordType { get; set; }

        public void Set<T>(T value) where T : Entity
        {
            switch (typeof(T).Name)
            {
                case nameof(Lesson):
                    Lesson = value as Lesson;
                    break;
                case nameof(WordType):
                    WordType = value as WordType;
                    break;
            }
        }

        public bool In(Entry entry, IEnumerable<Word> words)
        {
            bool canView = true;
            if (Lesson != null)
            {
                canView = entry.Lesson.Id == Lesson.Id;
            }

            if (WordType != null && canView)
            {
                canView = words.FirstOrDefault(x => x.WordType.Id == WordType.Id) != null;
            }

            return canView;
        }
    }
}
