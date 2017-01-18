//-----------------------------------------------------------------------
// <copyright file="LanguagesDialogCommand.cs" company="Тепляшин Сергей Васильевич">
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
// <date>28.12.2016</date>
// <time>14:06</time>
// <summary>Defines the LanguagesDialogCommand class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.VocabularyWindow
{
    using System.Windows.Forms;
    using Data.Entities;

    public class LanguagesDialogCommand : ICommand
    {
        readonly IHost host;
        readonly IVocabularyWindow owner;
        readonly Theme theme;

        public LanguagesDialogCommand(IHost host, IVocabularyWindow owner, Theme theme)
        {
            this.host = host;
            this.owner = owner;
            this.theme = theme;
        }

        void ICommand.Execute(object sender)
        {
            if (LanguageDialog.ShowDialog(host, (IWin32Window)owner, theme))
            {
                owner.RefreshColumns();
            }
        }

        static public void Execute(IHost host, IVocabularyWindow owner, Theme theme)
        {
            ICommand command = new LanguagesDialogCommand(host, owner, theme);
            command.Execute(owner);
        }
    }
}
