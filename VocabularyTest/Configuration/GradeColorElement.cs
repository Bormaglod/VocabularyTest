//-----------------------------------------------------------------------
// <copyright file="GradeColorElement.cs" company="Тепляшин Сергей Васильевич">
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
// <date>23.12.2016</date>
// <time>14:38</time>
// <summary>Defines the GradeColorElement class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Configuration
{
    using System.Configuration;
    using System.Drawing;
    using Addons;

    public sealed class GradeColorElement : ConfigurationElement, IGradeColor
    {
        [ConfigurationProperty("level")]
        public int Level
        {
            get { return (int)this["level"]; }
            set { this["level"] = value; }
        }

        [ConfigurationProperty("color")]
        public Color Color
        {
            get { return (Color)this["color"]; }
            set { this["color"] = value; }
        }
    }
}
