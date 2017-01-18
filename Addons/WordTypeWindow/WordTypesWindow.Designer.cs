//-----------------------------------------------------------------------
// <copyright file="WordTypesWindow.Designer.cs" company="Тепляшин Сергей Васильевич">
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
// <date>08.11.2016</date>
// <time>13:21</time>
// <summary>Defines the WordTypesWindow class.</summary>
//-----------------------------------------------------------------------
namespace VocabularyTest.Addons.WordTypeWindow
{
    partial class WordTypesWindow
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentLib.Controls.TreeViewColumns treeWordTypes;
        private System.Windows.Forms.ToolStripButton buttonAdd;
        private System.Windows.Forms.ToolStripButton buttonEdit;
        private System.Windows.Forms.ToolStripButton buttonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton buttonGrammatical;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuGrammatical;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordTypesWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonEdit = new System.Windows.Forms.ToolStripButton();
            this.buttonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonGrammatical = new System.Windows.Forms.ToolStripSplitButton();
            this.treeWordTypes = new ComponentLib.Controls.TreeViewColumns();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuGrammatical = new System.Windows.Forms.ToolStripMenuItem();
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
            this.buttonDelete,
            this.toolStripSeparator1,
            this.buttonGrammatical});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // buttonAdd
            // 
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAdd.Image = global::VocabularyTest.Addons.WordTypeWindow.Images.action_add;
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // buttonEdit
            // 
            resources.ApplyResources(this.buttonEdit, "buttonEdit");
            this.buttonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEdit.Image = global::VocabularyTest.Addons.WordTypeWindow.Images.action_edit;
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // buttonDelete
            // 
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDelete.Image = global::VocabularyTest.Addons.WordTypeWindow.Images.action_remove;
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // buttonGrammatical
            // 
            resources.ApplyResources(this.buttonGrammatical, "buttonGrammatical");
            this.buttonGrammatical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonGrammatical.Name = "buttonGrammatical";
            this.buttonGrammatical.DropDownOpening += new System.EventHandler(this.ButtonGrammaticalDropDownOpening);
            // 
            // treeWordTypes
            // 
            resources.ApplyResources(this.treeWordTypes, "treeWordTypes");
            this.treeWordTypes.AllowDrop = true;
            this.treeWordTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.treeWordTypes.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeWordTypes.HideSelection = false;
            this.treeWordTypes.HotTracking = true;
            this.treeWordTypes.ItemHeight = 20;
            this.treeWordTypes.Name = "treeWordTypes";
            this.treeWordTypes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeWordTypesAfterSelect);
            this.treeWordTypes.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeWordTypesDragDrop);
            this.treeWordTypes.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeWordTypesDragOver);
            this.treeWordTypes.DoubleClick += new System.EventHandler(this.ButtonEditClick);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuEdit,
            this.menuDelete,
            this.toolStripSeparator3,
            this.menuGrammatical});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
            // 
            // menuAdd
            // 
            resources.ApplyResources(this.menuAdd, "menuAdd");
            this.menuAdd.Image = global::VocabularyTest.Addons.WordTypeWindow.Images.action_add;
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // menuEdit
            // 
            resources.ApplyResources(this.menuEdit, "menuEdit");
            this.menuEdit.Image = global::VocabularyTest.Addons.WordTypeWindow.Images.action_edit;
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // menuDelete
            // 
            resources.ApplyResources(this.menuDelete, "menuDelete");
            this.menuDelete.Image = global::VocabularyTest.Addons.WordTypeWindow.Images.action_remove;
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // menuGrammatical
            // 
            resources.ApplyResources(this.menuGrammatical, "menuGrammatical");
            this.menuGrammatical.Name = "menuGrammatical";
            // 
            // WordTypesWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeWordTypes);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WordTypesWindow";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
