//-----------------------------------------------------------------------
// <copyright file=PrimaryKeyConvention.cs company="Sergey Teplyashin">
//     Copyright (c) 2010-2016 Sergey Teplyashin. All rights reserved.
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
// <date>24.04.2016</date>
// <time>10:02</time>
// <summary>Defines the PrimaryKeyConvention.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Mappings.Convetions
{
    using System;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using Inflector;
    using Base;
    
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.GeneratedBy.Native();
            instance.Column("id");
            
            Type cur = instance.EntityType;
            if (cur.BaseType.Name != nameof(Entity) && cur.BaseType.IsAbstract)
            {
                while (cur.BaseType.Name != nameof(Entity))
                {
                    cur = cur.BaseType;
                }
            }
            
            instance.GeneratedBy.SequenceIdentity($"{cur.Name.Underscore()}_id_seq");
        }
    }
}
