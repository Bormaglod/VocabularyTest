//-----------------------------------------------------------------------
// <copyright file="GlobalAddon.cs" company="Тепляшин Сергей Васильевич">
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
// <date>28.11.2016</date>
// <time>13:48</time>
// <summary>Defines the GlobalAddon class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.Global
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using Addons;

    [Export(typeof(IAddon))]
    public class GlobalAddon : IAddon
    {
        const string addonName = "GlobalAddon";
        
        [Import(typeof(IHost))]
        IHost host { get; set; }

        #region IAddon interface impelemented
        
        string IAddon.Name => addonName;
        
        IEnumerable<string> IAddon.Dependence => new string[] {};
        
        bool IAddon.Autostart => false;
        
        void IAddon.RunOnce()
        {
        }
        
        void IAddon.Run()
        {
            host.MainMenu.AddMenu("View", "File", "Вид");
        }
        
        /// <summary>
        /// Остановка выполнения плагина.
        /// </summary>
        void IAddon.Stop()
        {
        }

        void IAddon.ExecuteCommand(int command, object data)
        {
        }

        #endregion
    }
}
