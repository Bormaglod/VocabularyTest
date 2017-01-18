//-----------------------------------------------------------------------
// <copyright file="SelectUserDialog.cs" company="Тепляшин Сергей Васильевич">
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
// <date>25.10.2011</date>
// <time>9:17</time>
// <summary>Defines the SelectUserDialog class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using Data;
    using Data.Entities;
    using Data.Repositories;
    
    public partial class SelectUserDialog : KryptonForm
    {
        public SelectUserDialog()
        {
            InitializeComponent();
        }
        
        SelectUserDialog(IEnumerable<Account> users, Account defaultUser) : this()
        {
            comboUsers.Items.Clear();
            foreach (Account user in users)
            {
                comboUsers.Items.Add(user);
            }
            
            comboUsers.SelectedItem = defaultUser;
        }
        
        public static Account Get(IWin32Window owner)
        {
            bool admin = Environment.GetCommandLineArgs().Contains("/admin");
            using (ISession session = DataHelper.OpenSession())
            {
                Repository<Account> repo = new Repository<Account>(session);
                
                IEnumerable<Account> users = from Account account in repo.All().List()
                    where account.Role == Account.account_role.user || (account.Role == Account.account_role.administrator && admin)
                    select account;
                
                if (users.FirstOrDefault() == null)
                {
                    return null;
                }
                
                SelectUserDialog dialog = null;
                if (users.Count() > 1)
                {
                    dialog = new SelectUserDialog(users, null);
                }
                else
                {
                    Account user = users.First();
                    dialog = new SelectUserDialog(users, user);
                    /*if (!string.IsNullOrEmpty(user.Password))
                    {
                        dialog = new SelectUserDialog(users, user);
                    }
                    else
                    {
                        return user;
                    }*/
                }
                
                if (dialog != null && dialog.ShowDialog(owner) == DialogResult.OK)
                {
                    return dialog.comboUsers.SelectedItem as Account;
                }
            }
            
            return null;
        }
        
        void ButtonOKClick(object sender, EventArgs e)
        {
            if (comboUsers.SelectedItem != null)
            {
                Account user = (Account)this.comboUsers.SelectedItem;
                /*if (user.Password != this.textPassword.Text)
                {
                    KryptonMessageBox.Show(Strings.IncorrectPassword, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }*/
            }
            else
            {
                KryptonMessageBox.Show(Strings.UserNeeded, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }
    }
}
