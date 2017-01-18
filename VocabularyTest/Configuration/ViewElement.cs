//-----------------------------------------------------------------------
// <copyright file="ViewElement.cs" company="Тепляшин Сергей Васильевич">
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
// <date>25.10.2016</date>
// <time>10:46</time>
// <summary>Defines the ViewElement class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Configuration
{
    using System.Configuration;
    using ComponentFactory.Krypton.Toolkit;
    using Addons;
    
    /// <summary>
    /// Represents a single XML tag inside a ConfigurationSection
    /// or a ConfigurationElementCollection.
    /// </summary>
    public sealed class ViewElement : ConfigurationElement, IViewSettings
    {
        [ConfigurationProperty("local_code", DefaultValue="ru-RU")]
        public string LocalCode
        {
            get { return (string)this["local_code"]; }
            set { this["local_code"] = value; }
        }
        
        [ConfigurationProperty("warning_change_language", DefaultValue=true)]
        public bool WarningChangeLanguage
        {
            get { return (bool)this["warning_change_language"]; }
            set { this["warning_change_language"] = value; }
        }
        
        [ConfigurationProperty("palette_mode", DefaultValue="ProfessionalSystem")]
        public PaletteModeManager Mode
            {
            get { return (PaletteModeManager)this["palette_mode"]; }
            set { this["palette_mode"] = value; }
        }
        
        [ConfigurationProperty("size")]
        public SizeElement Size => (SizeElement)this["size"];
        
        [ConfigurationProperty("visible")]
        public VisibleElement Visible => (VisibleElement)this["visible"];

        [ConfigurationProperty("use_grade_colors")]
        public GradeElement UseGradeColors => (GradeElement)this["use_grade_colors"];

        IGradeSettings IViewSettings.UseGradeColors => UseGradeColors;
    }
}

