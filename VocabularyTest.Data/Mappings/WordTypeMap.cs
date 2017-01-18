//-----------------------------------------------------------------------
// <copyright file="WordTypeMap.cs" company="Тепляшин Сергей Васильевич">
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
// <date>09.12.2016</date>
// <time>15:35</time>
// <summary>Defines the WordTypeMap class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Mappings
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Entities;

    public class WordTypeMap : IAutoMappingOverride<WordType>
    {
        public void Override(AutoMapping<WordType> mapping)
        {
            mapping.Map(x => x.Special).CustomType<int>();
            mapping.HasMany(x => x.Abbreviations).Cascade.All().Inverse();
        }
    }
}
