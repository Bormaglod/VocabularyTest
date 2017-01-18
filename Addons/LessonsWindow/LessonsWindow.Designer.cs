//-----------------------------------------------------------------------
// <copyright file=LessonsWindow.cs company="Тепляшин Сергей Васильевич">
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
// <date>27.10.2016</date>
// <time>13:55</time>
// <summary>Defines the LessonsWindow class.</summary>
//-----------------------------------------------------------------------
namespace VocabularyTest.Addons.LessonsWindow
{
    partial class LessonsWindow
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentLib.Controls.TreeViewColumns treeLessons;
        private System.Windows.Forms.ToolStripButton buttonAdd;
        private System.Windows.Forms.ToolStripButton buttonEdit;
        private System.Windows.Forms.ToolStripButton buttonDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LessonsWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonEdit = new System.Windows.Forms.ToolStripButton();
            this.buttonDelete = new System.Windows.Forms.ToolStripButton();
            this.treeLessons = new ComponentLib.Controls.TreeViewColumns();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonAdd,
            this.buttonEdit,
            this.buttonDelete});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // buttonAdd
            // 
            this.buttonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAdd.Image = global::VocabularyTest.Addons.LessonsWindow.Images.action_add;
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // buttonEdit
            // 
            this.buttonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEdit.Image = global::VocabularyTest.Addons.LessonsWindow.Images.action_edit;
            resources.ApplyResources(this.buttonEdit, "buttonEdit");
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDelete.Image = global::VocabularyTest.Addons.LessonsWindow.Images.action_remove;
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // treeLessons
            // 
            this.treeLessons.AllowDrop = true;
            this.treeLessons.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.treeLessons, "treeLessons");
            this.treeLessons.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeLessons.HideSelection = false;
            this.treeLessons.HotTracking = true;
            this.treeLessons.ItemHeight = 20;
            this.treeLessons.Name = "treeLessons";
            this.treeLessons.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeLessonsAfterSelect);
            this.treeLessons.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeLessonsDragDrop);
            this.treeLessons.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeLessonsDragOver);
            this.treeLessons.DoubleClick += new System.EventHandler(this.ButtonEditClick);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuEdit,
            this.menuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // menuAdd
            // 
            this.menuAdd.Image = global::VocabularyTest.Addons.LessonsWindow.Images.action_add;
            this.menuAdd.Name = "menuAdd";
            resources.ApplyResources(this.menuAdd, "menuAdd");
            this.menuAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // menuEdit
            // 
            this.menuEdit.Image = global::VocabularyTest.Addons.LessonsWindow.Images.action_edit;
            this.menuEdit.Name = "menuEdit";
            resources.ApplyResources(this.menuEdit, "menuEdit");
            this.menuEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // menuDelete
            // 
            this.menuDelete.Image = global::VocabularyTest.Addons.LessonsWindow.Images.action_remove;
            this.menuDelete.Name = "menuDelete";
            resources.ApplyResources(this.menuDelete, "menuDelete");
            this.menuDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // LessonsWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeLessons);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LessonsWindow";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
