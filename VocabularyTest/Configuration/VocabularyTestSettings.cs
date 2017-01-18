//-----------------------------------------------------------------------
// <copyright file="VocabularyTestSettings.cs" company="Тепляшин Сергей Васильевич">
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
// <time>10:47</time>
// <summary>Defines the VocabularyTestSettings class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Configuration
{
    using System.Configuration;
    using Addons;

    /// <summary>
    /// Configuration section &lt;VocabularyTest&gt;
    /// </summary>
    /// <remarks>
    /// Assign properties to your child class that has the attribute 
    /// <c>[ConfigurationProperty]</c> to store said properties in the xml.
    /// </remarks>
    public sealed class VocabularyTestSettings : ConfigurationSection, ISettings
    {
        Configuration config;

        #region ConfigurationProperties
        
        [ConfigurationProperty("view")]
        public ViewElement View => (ViewElement)this["view"];
        
        [ConfigurationProperty("folders")]
        public FoldersElement Folders => (FoldersElement)this["folders"];

        [ConfigurationProperty("fonts")]
        public FontsTableElement Fonts => (FontsTableElement)this["fonts"];

        #endregion

        #region ISettings implementation

        IViewSettings ISettings.View => View;

        IFolderSettings ISettings.Folders => Folders;

        IFontsTableSettings ISettings.Fonts => Fonts;

        #endregion

        /// <summary>
        /// Private Constructor used by our factory method.
        /// </summary>
        VocabularyTestSettings()
        {
            // Allow this section to be stored in user.app. By default this is forbidden.
            SectionInformation.AllowExeDefinition = ConfigurationAllowExeDefinition.MachineToLocalUser;
        }

        #region Public Methods
        
        /// <summary>
        /// Saves the configuration to the config file.
        /// </summary>
        public void Save()
        {
            config.Save();
        }
        
        #endregion
        
        #region Static Members
        
        /// <summary>
        /// Gets the current applications &lt;VocabularyTest&gt; section.
        /// </summary>
        /// <param name="ConfigLevel">
        /// The &lt;ConfigurationUserLevel&gt; that the config file
        /// is retrieved from.
        /// </param>
        /// <returns>
        /// The configuration file's &lt;VocabularyTest&gt; section.
        /// </returns>
        public static VocabularyTestSettings GetSection (ConfigurationUserLevel ConfigLevel)
        {
            /* 
             * This class is setup using a factory pattern that forces you to
             * name the section &lt;VocabularyTest&gt; in the config file.
             * If you would prefer to be able to specify the name of the section,
             * then remove this method and mark the constructor public.
             */ 
            Configuration Config = ConfigurationManager.OpenExeConfiguration(ConfigLevel);
            VocabularyTestSettings oVocabularyTestSettings;
            
            oVocabularyTestSettings = (VocabularyTestSettings)Config.GetSection("VocabularyTestSettings");
            if (oVocabularyTestSettings == null)
            {
                oVocabularyTestSettings = new VocabularyTestSettings();
                Config.Sections.Add("VocabularyTestSettings", oVocabularyTestSettings);
            }
            
            oVocabularyTestSettings.config = Config;
            
            return oVocabularyTestSettings;
        }
        
        #endregion
    }
}

