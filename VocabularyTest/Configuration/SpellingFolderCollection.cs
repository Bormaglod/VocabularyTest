//-----------------------------------------------------------------------
// <copyright file="SpellingFolderCollection.cs" company="Тепляшин Сергей Васильевич">
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
// <date>07.11.2016</date>
// <time>10:23</time>
// <summary>Defines the SpellingFolderCollection class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Configuration
{
    using System.Collections.Generic;
    using System.Configuration;

    public sealed class SpellingFolderCollection : ConfigurationElementCollection
    {
        #region Properties

        /// <summary>
        /// Gets the CollectionType of the ConfigurationElementCollection.
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
       
        /// <summary>
        /// Retrieve and item in the collection by index.
        /// </summary>
        public SpellingFolderElement this[int index]
        {
            get
            {
                return (SpellingFolderElement)BaseGet(index);
            }
            
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                
                BaseAdd(index, value);
            }
        }
        
        public IEnumerable<string> WithDefaultFolder
        {
            get
            {
                List<string> folders = new List<string>();
                folders.Add(System.Windows.Forms.Application.StartupPath + "\\Spelling");
                foreach (SpellingFolderElement folder in this)
                {
                    folders.Add(folder.Name);
                }
                
                return folders;
            }
        }

        #endregion

        /// <summary>
        /// Adds a SpellingFolderElement to the configuration file.
        /// </summary>
        /// <param name="element">The SpellingFolderElement to add.</param>
        public void Add(SpellingFolderElement element)
        {
            BaseAdd(element);
        }
       
        /// <summary>
        /// Creates a new SpellingFolderElement.
        /// </summary>
        /// <returns>A new <c>SpellingFolderElement</c></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new SpellingFolderElement();
        }
       
        /// <summary>
        /// Gets the key of an element based on it's Id.
        /// </summary>
        /// <param name="element">Element to get the key of.</param>
        /// <returns>The key of <c>element</c>.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SpellingFolderElement)element).Name;
        }
       
        /// <summary>
        /// Removes a SpellingFolderElement with the given name.
        /// </summary>
        /// <param name="name">The name of the SpellingFolderElement to remove.</param>
        public void Remove (string name)
        {
            BaseRemove(name);
        }
    }
}

