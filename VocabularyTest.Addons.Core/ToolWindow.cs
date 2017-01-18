//-----------------------------------------------------------------------
// <copyright file="ToolWindow.cs" company="Тепляшин Сергей Васильевич">
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
// <date>26.01.2011</date>
// <time>9:15</time>
// <summary>Defines the ToolWindow class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using WeifenLuo.WinFormsUI.Docking;
    
    abstract public class ToolWindow : DockContent, IAddon
    {
        readonly List<string> dependence = new List<string>();
        
        protected ToolWindow()
        {
            AddDependence();
            HideOnClose = true;
        }
        
        public bool Autostart { get; protected set; }

        #region IAddon interface implemented

        string IAddon.Name => Name;

        IEnumerable<string> IAddon.Dependence => dependence;
        
        void IAddon.RunOnce()
        {
            RunOnce();
        }
        
        void IAddon.Run()
        {
            Trace.TraceInformation($"******** Starting addon {((IAddon)this).Name}");
            Run();
        }
        
        void IAddon.Stop()
        {
            Hide();
        }

        void IAddon.ExecuteCommand(int command, object data)
        {
            ExecuteCommand(command, data);
        }

        #endregion

        new public void Hide()
        {
            base.Hide();
            OnHide();
        }
        
        protected abstract void Run();
        
        protected virtual void RunOnce() {}
        
        protected virtual void OnHide()
        {
            DockPanel = null;
        }
        
        protected void AddDependenceItem(string item)
        {
            if (!dependence.Contains(item))
            {
                dependence.Add(item);
            }
        }
        
        protected virtual void DoAddDependence() {}

        protected virtual void ExecuteCommand(int command, object data) {}

        protected void ShowWindow(DockPanel dockPanel, DockState defaultDockState)
        {
            if (DockState == DockState.Hidden)
            {
                Activate();
            }
            else if (DockState == DockState.Unknown)
            {
                Show(dockPanel, defaultDockState);
            }
        }
        
        void AddDependence()
        {
            DoAddDependence();
        }
    }
}
