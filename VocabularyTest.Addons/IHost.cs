//-----------------------------------------------------------------------
// <copyright file="IHost.cs" company="Тепляшин Сергей Васильевич">
//     Copyright (c) 2010-2017 Тепляшин Сергей Васильевич. All rights reserved.
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
// <date>26.10.2016</date>
// <time>8:37</time>
// <summary>Defines the IHost class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons
{
    using Data.Entities;
    using WeifenLuo.WinFormsUI.Docking;
    
    public interface IHost
    {
        DockPanel Workbench { get; }
        IMenu MainMenu { get; }
        IToolBar ToolBar { get; }
        IDictionaries Dictionaries { get; }
        ISettings Settings { get; }

        Theme CurrentTheme { get; }
        Account User { get; }
        
        bool Open(Theme theme);
        bool Create();
        bool Delete(Theme theme);
        bool Hide(Theme theme);
        void StartPractice(Theme theme);
        void LoadVocabulary();
        void ExecuteCommand(int command, object data);
    }
}
