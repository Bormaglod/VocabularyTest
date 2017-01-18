//-----------------------------------------------------------------------
// <copyright file="IAddon.cs" company="Тепляшин Сергей Васильевич">
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
// <date>18.11.2016</date>
// <time>12:52</time>
// <summary>Defines the IAddon class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons
{
    using System.Collections.Generic;
    
    public interface IAddon
    {
        string Name { get; }
        
        IEnumerable<string> Dependence { get; }
        
        /// <summary>
        /// Возвращает true, если запуск плагина осуществляется автоматически.
        /// </summary>
        bool Autostart { get; }
        
        /// <summary>
        /// Метод запускается один раз перед <see cref="Run"/> диспетчером дополнений и предназначен для
        /// инициализации дополнения.
        /// </summary>
        void RunOnce();
        
        /// <summary>
        /// Метод предназначен для выполнения функционала плагина.
        /// </summary>
        void Run();
        
        /// <summary>
        /// Остановка выполнения плагина.
        /// </summary>
        void Stop();

        void ExecuteCommand(int command, object data);
    }
}
