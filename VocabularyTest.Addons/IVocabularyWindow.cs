//-----------------------------------------------------------------------
// <copyright file="IVocabularyWindow.cs" company="Тепляшин Сергей Васильевич">
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
// <time>12:35</time>
// <summary>Defines the IVocabularyWindow class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons
{
    using System;
    using Data.Base;
    using Data.Entities;
    
    public interface IVocabularyWindow
    {
        /// <summary>
        /// Событие вызывается при изменении выделенной ячейки (ячеек).
        /// </summary>
        event EventHandler<WordsSelectedEventArgs> WordsSelected;

        /// <summary>
        /// Событие вызывается при изменении содержимого урока (уроков). Например, при
        /// добавлении записи или при перемещении её.
        /// </summary>
        event EventHandler<EntitiesModifiedEventArgs<Lesson>> LessonContentModified;

        /// <summary>
        /// Событие вызывается при изменении части речи слова (слов), что должно приводить к изменению
        /// количества записей содержащих слова с данной частью речи.
        /// </summary>
        event EventHandler<EntitiesModifiedEventArgs<WordType>> WordTypeContentModified;

        /// <summary>
        /// Событие вызывается при изменении уровны изучения какого-либо слова или слов.
        /// </summary>
        event EventHandler<EntitiesModifiedEventArgs<Grade>> GradeContentModified;

        void Update();
        void RefreshColumns();
        void SetFilter<T>(T filterValue) where T : Entity;
        void SpellCheckEntries();
    }
}
