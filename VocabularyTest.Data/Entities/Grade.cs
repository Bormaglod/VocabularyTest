//-----------------------------------------------------------------------
// <copyright file="Grade.cs" company="Тепляшин Сергей Васильевич">
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
// <date>13.01.2017</date>
// <time>12:41</time>
// <summary>Defines the Grade class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Entities
{
    using System;
    using Base;

    public class Grade : Entity
    {
        public virtual Word Word { get; set; }
        public virtual Account User { get; set; }
        public virtual short Current { get; set; }
        public virtual int AnswersCount { get; set; }
        public virtual int SuccessCount { get; set; }
        public virtual int ErrorCount { get; set; }
        public virtual DateTime DateTesting { get; set; }

        public override string ToString()
        {
            return $"Word: {Word}, Grade: {Current}";
        }
    }
}
