//-----------------------------------------------------------------------
// <copyright file="WordType.cs" company="Тепляшин Сергей Васильевич">
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
// <time>15:29</time>
// <summary>Defines the WordType class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data.Entities
{
    using System.Collections.Generic;
    using System.Drawing;
    using ComponentFactory.Krypton.Toolkit;
    using Core;
    using Base;

    public enum grammatical
    {
        [LocalizedDescription("WordTypeIsNotDefined")]
        none,

        /// <summary>
        /// Существительное.
        /// </summary>
        [LocalizedDescription("Noun")]
        noun,

        /// <summary>
        /// Существительное, мужской род.
        /// </summary>
        [LocalizedDescription("Male")]
        male,

        /// <summary>
        /// Существительное, женский род.
        /// </summary>
        [LocalizedDescription("Female")]
        female,

        /// <summary>
        /// Существительное, средний род.
        /// </summary>
        [LocalizedDescription("Neutral")]
        neutral,

        /// <summary>
        /// Прилагательное.
        /// </summary>
        [LocalizedDescription("Adjective")]
        adjective,

        /// <summary>
        /// Наречие.
        /// </summary>
        [LocalizedDescription("Adverb")]
        adverb,

        /// <summary>
        /// Глагол.
        /// </summary>
        [LocalizedDescription("Verb")]
        verb
    }

    public class WordType : Entity, IContentValues
    {
        public virtual int? ParentId { get; set; }
        public virtual string Name { get; set; }
        public virtual grammatical Special { get; set; }
        public virtual int Level { get; set; }
        public virtual int CountChilds { get; set; }
        public virtual IList<Abbreviation> Abbreviations { get; set; } = new List<Abbreviation>();

        public virtual void AddAbbreviation(Abbreviation abbreviation)
        {
            if (abbreviation == null)
            {
                return;
            }
            
            if (abbreviation.WordType == null)
            {
                abbreviation.WordType = this;
                Abbreviations.Add(abbreviation);
            }
        }

        public override string ToString() => Name;

        #region IContentValues implementation

        Image IContentValues.GetImage(PaletteState state)
        {
            if (ParentId == null && CountChilds == 0)
            {
                return null;
            }

            int l = Level;
            Image image = new Bitmap(l * 16, 16);
            Graphics g = Graphics.FromImage(image);
            int x = 0;
            for (int i = 1; i < l; i++)
            {
                g.DrawImage(Images.blank, x, 0);
                x += 16;
            }

            g.DrawImage(CountChilds > 0 ? Images.right_down_arrow : Images.blank, x, 0);

            return image;
        }

        Color IContentValues.GetImageTransparentColor(PaletteState state) => Color.Empty;

        string IContentValues.GetShortText() => Name;

        string IContentValues.GetLongText() => null;

        #endregion
    }
}
