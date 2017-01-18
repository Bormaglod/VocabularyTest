//-----------------------------------------------------------------------
// <copyright file="AutoMappingConfig.cs" company="Тепляшин Сергей Васильевич">
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
// <date>16.12.2016</date>
// <time>13:24</time>
// <summary>Defines the AutoMappingConfig class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Mappings
{
    using System;
    using FluentNHibernate.Automapping;
    using Base;
    using ComponentLib.Core;
    using FluentNHibernate;

    public class AutoMappingConfig : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            /*bool include = type.IsSubclassOf(typeof(Dictionary)) || type == typeof(Dictionary);
            return include;*/
            return
                type.Namespace.EndsWith("Entities", StringComparison.CurrentCulture) &&
                type.Inherits(typeof(Entity));
        }

        public override bool ShouldMap(Member member)
        {
            return base.ShouldMap(member) && member.Name != "IsNew";
        }

        /*public override bool IsDiscriminated(Type type)
        {
            return typeof(Dictionary).IsAssignableFrom(type);
        }*/
    }
}
