//-----------------------------------------------------------------------
// <copyright file="GradeColorCollection.cs" company="Тепляшин Сергей Васильевич">
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
// <time>14:41</time>
// <summary>Defines the GradeColorCollection class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Configuration
{
    using System.Configuration;

    public sealed class GradeColorCollection : ConfigurationElementCollection
    {
        #region Properties

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        public GradeColorElement this[int index]
        {
            get
            {
                return (GradeColorElement)BaseGet(index);
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

        #endregion

        /// <summary>
        /// Adds a GradeColorElement to the configuration file.
        /// </summary>
        /// <param name="element">The GradeColorElement to add.</param>
        public void Add(GradeColorElement element)
        {
            BaseAdd(element);
        }

        /// <summary>
        /// Creates a new GradeColorElement.
        /// </summary>
        /// <returns>A new <c>GradeColorElement</c></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new GradeColorElement();
        }

        /// <summary>
        /// Gets the key of an element based on it's Id.
        /// </summary>
        /// <param name="element">Element to get the key of.</param>
        /// <returns>The key of <c>element</c>.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((GradeColorElement)element).Level;
        }

        /// <summary>
        /// Removes a GradeColorElement with the given name.
        /// </summary>
        /// <param name="name">The name of the GradeColorElement to remove.</param>
        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
}
