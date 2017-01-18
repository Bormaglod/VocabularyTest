//-----------------------------------------------------------------------
// <copyright file="AddonDispatcher.cs" company="Тепляшин Сергей Васильевич">
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
// <date>07.12.2016</date>
// <time>11:22</time>
// <summary>Defines the AddonDispatcher class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using Addons;

    public class AddonDispatcher
    {
        [ImportMany(typeof(IAddon))]
        IEnumerable<IAddon> addons { get; set; }
        
        readonly Dictionary<string, bool> runningAddons = new Dictionary<string, bool>();
        
        public AddonDispatcher(CompositionContainer container)
        {
            container.ComposeParts(this);
            foreach (IAddon addon in addons)
            {
                runningAddons.Add(addon.Name, false);
            }
            
            Autostart();
        }
        
        public IEnumerator<IAddon> GetEnumerator() => addons.GetEnumerator();
        
        public void Run()
        {
            foreach (IAddon addon in addons.Where(x => !x.Autostart))
            {
                RunAddon(addon);
            }
        }
        
        void Autostart()
        {
            foreach (IAddon addon in addons.Where(x => x.Autostart))
            {
                RunAddon(addon);
            }
        }
        
        void RunAddon(IAddon addon)
        {
            RunAddonOnce(addon);
            addon.Run();
        }
        
        void RunAddonOnce(IAddon addon)
        {
            if (addon.Dependence.Any())
            {
                foreach (string name in addon.Dependence)
                {
                    IAddon dependence = addons.FirstOrDefault(x => x.Name == name);
                    RunAddonOnce(dependence);
                }
            }
            
            if (!runningAddons[addon.Name])
            {
                addon.RunOnce();
                runningAddons[addon.Name] = true;
            }
        }
    }
}
