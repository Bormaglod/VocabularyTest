//-----------------------------------------------------------------------
// <copyright file="EntitiesModifiedEventArgs.cs" company="Тепляшин Сергей Васильевич">
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
// <date>10.01.2017</date>
// <time>13:45</time>
// <summary>Defines the EntitiesModifiedEventArgs class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons
{
    using System;
    using System.Collections.Generic;
    using Data.Base;

    public class EntitiesModifiedEventArgs<T> : EventArgs where T: Entity
    {
        readonly IEnumerable<T> entities;

        public EntitiesModifiedEventArgs(IEnumerable<T> entities)
        {
            this.entities = entities;
        }

        public IEnumerable<T> Entities => entities;
    }
}
