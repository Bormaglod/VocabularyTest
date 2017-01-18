//-----------------------------------------------------------------------
// <copyright file="ObjectDialog.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2017 Sergey Teplyashin. All rights reserved.
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
// <date>23.10.2014</date>
// <time>15:18</time>
// <summary>Defines the ObjectDialog class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.Core
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using VocabularyTest.Core;
    using Data;
    using Data.Base;
    using Data.Repositories;

    public /*abstract */partial class ObjectDialog<T> : KryptonForm where T: Entity, new()
    {
        ISession session;
        T current;
        int locked;
        T master;
        
        protected ObjectDialog()
        {
            InitializeComponent();
        }
        
        protected T Current { get { return current; } }
        
        protected T MasterEntity { get { return master; } }
        
        protected ISession Session { get { return session; } }
        
        protected bool Locked { get { return locked > 0; } }
        
        protected bool CanUpdate
        {
            get { return buttonOK.Enabled; }
            set { buttonOK.Enabled = value; }
        }
        
        T NewObject(IWin32Window owner, T fromEntity = default(T))
        {
            OnInitialize();
            try
            {
                Text += " (новый)";
                
                current = new T();
                if (fromEntity != default(T))
                {
                    fromEntity.CopyTo(current);
                    session.Save(current);
                    DoBeforeEditingObject();
                }
                else
                {
                    DoBeforeCreatingObject();
                }
                
                if (ShowDialog(owner) == DialogResult.OK)
                {
                    session.Transaction.Commit();
                    return current;
                }
                
                session.Transaction.Rollback();
                return null;
            }
            finally
            {
                OnFinalize();
            }
        }
        
        public T CreateObject(IWin32Window owner)
        {
            return NewObject(owner, null);
        }
        
        public T CreateFromObject(IWin32Window owner, T fromEntity)
        {
            return NewObject(owner, fromEntity);
        }
        
        public T CreateObject(IWin32Window owner, T masterObject)
        {
            master = masterObject;
            return NewObject(owner);
        }
        
        public T Edit(IWin32Window owner, T editedObject)
        {
            OnInitialize();
            try
            {
                Repository<T> repo = new Repository<T>(session);
                current = repo.Get(editedObject.Id);
                
                DoBeforeEditingObject();
                if (ShowDialog(owner) == DialogResult.OK)
                {
                    session.Transaction.Commit();
                    return current;
                }
                
                session.Transaction.Rollback();
                return null;
            }
            finally
            {
                OnFinalize();
            }
        }
        
        protected virtual void OnInitialize() { OpenSession(); }
        protected virtual void OnFinalize() {}
        protected virtual void OnBeforeCreatingObject() { }
        protected virtual void OnBeforeCommitObject() { }
        protected virtual void OnCommitObject() { }
        protected virtual void OnAfterCommitObject() { }
        protected virtual void OnBeforeEditingObject() { }
        
        protected void Lock()
        {
            locked++;
        }
        
        protected void Unlock()
        {
            locked--;
        }
        
        void OpenSession()
        {
            session = DataHelper.OpenSession();
            session.BeginTransaction();
        }
        
        void DoBeforeCreatingObject()
        {
            Lock();
            try
            {
                OnBeforeCreatingObject();
            }
            finally
            {
                Unlock();
            }
        }
        
        void DoBeforeCommitObject()
        {
            Lock();
            try
            {
                OnBeforeCommitObject();
            }
            finally
            {
                Unlock();
            }
        }
        
        void DoBeforeEditingObject()
        {
            Lock();
            try
            {
                OnBeforeEditingObject();
            }
            finally
            {
                Unlock();
            }
        }
        
        void DoAfterCommitObject()
        {
            Lock();
            try
            {
                OnAfterCommitObject();
            }
            finally
            {
                Unlock();
            }
        }
        
        bool DoCommitObject()
        {
            DoBeforeCommitObject();
            try
            {
                current = session.Merge(current);
                OnCommitObject();
                session.Flush();
                DoAfterCommitObject();
                return true;
            }
            catch (ADOException ex)
            {
                Trace.TraceError(ErrorHelper.Message(ex));
                ErrorHelper.ShowDbError(this, ex);
                
                DialogResult = DialogResult.None;
                OpenSession();
            }
            
            return false;
        }
        
        void ButtonOKClick(object sender, EventArgs e)
        {
            DoCommitObject();
        }
    }
}
