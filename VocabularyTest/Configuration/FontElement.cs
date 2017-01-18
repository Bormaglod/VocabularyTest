//-----------------------------------------------------------------------
// <copyright file="FontElement.cs" company="Тепляшин Сергей Васильевич">
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
// <date>30.12.2016</date>
// <time>10:29</time>
// <summary>Defines the FontElement class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Configuration
{
    using System.Configuration;
    using System.Drawing;
    using Addons;

    public sealed class FontElement : ConfigurationElement, IFontSettings
    {
        [ConfigurationProperty("name", DefaultValue = "Microsoft Sans Serif")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("bold")]
        public bool Bold
        {
            get { return (bool)this["bold"]; }
            set { this["bold"] = value; }
        }

        [ConfigurationProperty("italic")]
        public bool Italic
        {
            get { return (bool)this["italic"]; }
            set { this["italic"] = value; }
        }

        [ConfigurationProperty("strikeout")]
        public bool Strikeout
        {
            get { return (bool)this["strikeout"]; }
            set { this["strikeout"] = value; }
        }

        [ConfigurationProperty("underline")]
        public bool Underline
        {
            get { return (bool)this["underline"]; }
            set { this["underline"] = value; }
        }

        [ConfigurationProperty("size", DefaultValue = 8f)]
        public float Size
        {
            get { return (float)this["size"]; }
            set { this["size"] = value; }
        }

        [ConfigurationProperty("charset")]
        public byte CharSet
        {
            get { return (byte)this["charset"]; }
            set { this["charset"] = value; }
        }

        public Font Font()
        {
            FontStyle style = FontStyle.Regular;
            if (Italic)
            {
                style |= FontStyle.Italic;
            }

            if (Bold)
            {
                style |= FontStyle.Bold;
            }

            if (Strikeout)
            {
                style |= FontStyle.Strikeout;
            }

            if (Underline)
            {
                style |= FontStyle.Underline;
            }

            return new Font(Name, Size, style, GraphicsUnit.Point, CharSet);
        }
    }
}
