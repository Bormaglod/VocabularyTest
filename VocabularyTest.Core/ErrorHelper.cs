//-----------------------------------------------------------------------
// <copyright file="ErrorHelper.cs" company="Тепляшин Сергей Васильевич">
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
// <date>18.10.2016</date>
// <time>15:20</time>
// <summary>Defines the ErrorHelper class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Core
{
    using System;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using Npgsql;
    
    public static class ErrorHelper
    {
        public static string Message(string procedure, string operation, Exception exception)
        {
            return string.Format("{0}: {1}: {2}. {3}",
                          DateTime.Now.ToString("s"),
                          procedure,
                          operation,
                          exception.Message);
        }
        
        public static string Message(Exception exception)
        {
            return string.Format("{0}: {1}\n{2}",
                          DateTime.Now.ToString("s"),
                          exception.Message,
                          exception.StackTrace);
        }
        
        public static void ShowDbError(IWin32Window owner, ADOException e)
        {
            PostgresException detail = e.InnerException as PostgresException;
            KryptonMessageBox.Show(owner, detail?.Message ?? e.Message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
