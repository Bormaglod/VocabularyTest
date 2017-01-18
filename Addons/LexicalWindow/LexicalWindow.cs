//-----------------------------------------------------------------------
// <copyright file=LexicalWindow.cs company="Тепляшин Сергей Васильевич">
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
// <date>18.01.2017</date>
// <time>12:34</time>
// <summary>Defines the LexicalWindow class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.LexicalWindow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VocabularyTest.Addons.Core;
    using WeifenLuo.WinFormsUI.Docking;

    public partial class LexicalWindow : ToolWindow
    {
        [Import(typeof(IHost))]
        IHost host { get; set; }

        [Import(typeof(IVocabularyWindow))]
        IVocabularyWindow vocabularyWindow { get; set; }

        public LexicalWindow()
        {
            InitializeComponent();
        }

        protected IHost Host => host;

        protected override void DoAddDependence()
        {
            base.DoAddDependence();
            AddDependenceItem("GlobalAddon");
            AddDependenceItem("VocabularyWindow");
        }

        protected override void Run()
        {
            ShowWindow(host.Workbench, DockState.DockRight);
        }

        void buttonDefine_Click(object sender, EventArgs e)
        {

        }

        void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
