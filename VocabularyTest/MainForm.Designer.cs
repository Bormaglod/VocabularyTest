//-----------------------------------------------------------------------
// <copyright file="${FileName}" company="Тепляшин Сергей Васильевич">
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
// <date>05.12.2016</date>
// <time>14:57</time>
// <summary>Defines the ${ClassName} class.</summary>
//-----------------------------------------------------------------------
namespace VocabularyTest
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuApp;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemRecentFiles;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadNewDictionary;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenVocabulary;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem menuItemImport;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem menuItemProperty;
        private System.Windows.Forms.ToolStripMenuItem menuItemPrint;
        private System.Windows.Forms.ToolStripMenuItem menuItemPreview;
        private System.Windows.Forms.ToolStripMenuItem menuItemPrintConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemPalettes;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteSystem;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteOffice2003;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteOffice2007Blue;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteOffice2007Silver;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteOffice2007Black;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteOffice2010Blue;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteOffice2010Silver;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteOffice2010Black;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteSparkleBlue;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteSparkleOrange;
        private System.Windows.Forms.ToolStripMenuItem menuItemPaletteSparklePurple;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStripApp;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusWordType;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusPronunciation;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusComment;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusLoading;
        private System.Windows.Forms.ToolStrip toolStripApp;
        private ComponentFactory.Krypton.Toolkit.KryptonManager paletteManager;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.menuApp = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoadNewDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenVocabulary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPrintConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPalettes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteOffice2003 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPaletteOffice2007Blue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteOffice2007Silver = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteOffice2007Black = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPaletteOffice2010Blue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteOffice2010Silver = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteOffice2010Black = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPaletteSparkleBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteSparkleOrange = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPaletteSparklePurple = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStripApp = new System.Windows.Forms.StatusStrip();
            this.toolStatusWordType = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatusPronunciation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatusComment = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatusLoading = new System.Windows.Forms.ToolStripStatusLabel();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStripApp = new System.Windows.Forms.ToolStrip();
            this.paletteManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.backgroundLoading = new System.ComponentModel.BackgroundWorker();
            this.menuApp.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStripApp.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuApp
            // 
            this.menuApp.Dock = System.Windows.Forms.DockStyle.None;
            this.menuApp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.menuApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemSettings,
            this.menuItemHelp});
            this.menuApp.Location = new System.Drawing.Point(0, 0);
            this.menuApp.Name = "menuApp";
            this.menuApp.Size = new System.Drawing.Size(962, 24);
            this.menuApp.TabIndex = 2;
            this.menuApp.Text = "menuStrip2";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCreate,
            this.menuItemOpen,
            this.menuItemRecentFiles,
            this.menuItemLoadNewDictionary,
            this.menuItemOpenVocabulary,
            this.toolStripSeparator8,
            this.menuItemImport,
            this.menuItemExport,
            this.toolStripSeparator9,
            this.menuItemProperty,
            this.menuItemPrint,
            this.menuItemPreview,
            this.menuItemPrintConfig,
            this.toolStripSeparator1,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(48, 20);
            this.menuItemFile.Text = "Файл";
            // 
            // menuItemCreate
            // 
            this.menuItemCreate.Image = global::VocabularyTest.Images.create;
            this.menuItemCreate.Name = "menuItemCreate";
            this.menuItemCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuItemCreate.Size = new System.Drawing.Size(279, 22);
            this.menuItemCreate.Text = "Создать";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Image = global::VocabularyTest.Images.open;
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemOpen.Size = new System.Drawing.Size(279, 22);
            this.menuItemOpen.Text = "Открыть";
            // 
            // menuItemRecentFiles
            // 
            this.menuItemRecentFiles.Name = "menuItemRecentFiles";
            this.menuItemRecentFiles.Size = new System.Drawing.Size(279, 22);
            this.menuItemRecentFiles.Text = "Последние файлы";
            // 
            // menuItemLoadNewDictionary
            // 
            this.menuItemLoadNewDictionary.Image = global::VocabularyTest.Images.load_new_dictionary;
            this.menuItemLoadNewDictionary.Name = "menuItemLoadNewDictionary";
            this.menuItemLoadNewDictionary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.menuItemLoadNewDictionary.Size = new System.Drawing.Size(279, 22);
            this.menuItemLoadNewDictionary.Text = "Загрузить новые словари...";
            // 
            // menuItemOpenVocabulary
            // 
            this.menuItemOpenVocabulary.Name = "menuItemOpenVocabulary";
            this.menuItemOpenVocabulary.Size = new System.Drawing.Size(279, 22);
            this.menuItemOpenVocabulary.Text = "Открыть загруженные словари...";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(276, 6);
            // 
            // menuItemImport
            // 
            this.menuItemImport.Image = global::VocabularyTest.Images.import;
            this.menuItemImport.Name = "menuItemImport";
            this.menuItemImport.Size = new System.Drawing.Size(279, 22);
            this.menuItemImport.Text = "Импорт...";
            // 
            // menuItemExport
            // 
            this.menuItemExport.Image = global::VocabularyTest.Images.export;
            this.menuItemExport.Name = "menuItemExport";
            this.menuItemExport.Size = new System.Drawing.Size(279, 22);
            this.menuItemExport.Text = "Экспорт...";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(276, 6);
            // 
            // menuItemProperty
            // 
            this.menuItemProperty.Image = global::VocabularyTest.Images.property;
            this.menuItemProperty.Name = "menuItemProperty";
            this.menuItemProperty.Size = new System.Drawing.Size(279, 22);
            this.menuItemProperty.Text = "Свойства...";
            // 
            // menuItemPrint
            // 
            this.menuItemPrint.Image = global::VocabularyTest.Images.document_print;
            this.menuItemPrint.Name = "menuItemPrint";
            this.menuItemPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuItemPrint.Size = new System.Drawing.Size(279, 22);
            this.menuItemPrint.Text = "Печать...";
            // 
            // menuItemPreview
            // 
            this.menuItemPreview.Image = global::VocabularyTest.Images.document_print_preview;
            this.menuItemPreview.Name = "menuItemPreview";
            this.menuItemPreview.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.menuItemPreview.Size = new System.Drawing.Size(279, 22);
            this.menuItemPreview.Text = "Предварительный просмотр";
            // 
            // menuItemPrintConfig
            // 
            this.menuItemPrintConfig.Name = "menuItemPrintConfig";
            this.menuItemPrintConfig.Size = new System.Drawing.Size(279, 22);
            this.menuItemPrintConfig.Text = "Настройка печати...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(276, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Image = global::VocabularyTest.Images.exit;
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(279, 22);
            this.menuItemExit.Text = "Выход";
            this.menuItemExit.Click += new System.EventHandler(this.MenuItemExitClick);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPalettes});
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(78, 20);
            this.menuItemSettings.Text = "Настройка";
            // 
            // menuItemPalettes
            // 
            this.menuItemPalettes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPaletteSystem,
            this.menuItemPaletteOffice2003,
            this.toolStripSeparator4,
            this.menuItemPaletteOffice2007Blue,
            this.menuItemPaletteOffice2007Silver,
            this.menuItemPaletteOffice2007Black,
            this.toolStripSeparator5,
            this.menuItemPaletteOffice2010Blue,
            this.menuItemPaletteOffice2010Silver,
            this.menuItemPaletteOffice2010Black,
            this.toolStripSeparator6,
            this.menuItemPaletteSparkleBlue,
            this.menuItemPaletteSparkleOrange,
            this.menuItemPaletteSparklePurple});
            this.menuItemPalettes.Name = "menuItemPalettes";
            this.menuItemPalettes.Size = new System.Drawing.Size(240, 22);
            this.menuItemPalettes.Text = "Пользовательский интерфейс";
            // 
            // menuItemPaletteSystem
            // 
            this.menuItemPaletteSystem.Name = "menuItemPaletteSystem";
            this.menuItemPaletteSystem.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteSystem.Tag = "ProfessionalSystem";
            this.menuItemPaletteSystem.Text = "Professional - System";
            // 
            // menuItemPaletteOffice2003
            // 
            this.menuItemPaletteOffice2003.Name = "menuItemPaletteOffice2003";
            this.menuItemPaletteOffice2003.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteOffice2003.Tag = "ProfessionalOffice2003";
            this.menuItemPaletteOffice2003.Text = "Professional - Office 2003";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // menuItemPaletteOffice2007Blue
            // 
            this.menuItemPaletteOffice2007Blue.Name = "menuItemPaletteOffice2007Blue";
            this.menuItemPaletteOffice2007Blue.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteOffice2007Blue.Tag = "Office2007Blue";
            this.menuItemPaletteOffice2007Blue.Text = "Office 2007 - Blue";
            // 
            // menuItemPaletteOffice2007Silver
            // 
            this.menuItemPaletteOffice2007Silver.Name = "menuItemPaletteOffice2007Silver";
            this.menuItemPaletteOffice2007Silver.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteOffice2007Silver.Tag = "Office2007Silver";
            this.menuItemPaletteOffice2007Silver.Text = "Office 2007 - Silver";
            // 
            // menuItemPaletteOffice2007Black
            // 
            this.menuItemPaletteOffice2007Black.Name = "menuItemPaletteOffice2007Black";
            this.menuItemPaletteOffice2007Black.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteOffice2007Black.Tag = "Office2007Black";
            this.menuItemPaletteOffice2007Black.Text = "Office 2007 - Black";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(205, 6);
            // 
            // menuItemPaletteOffice2010Blue
            // 
            this.menuItemPaletteOffice2010Blue.Name = "menuItemPaletteOffice2010Blue";
            this.menuItemPaletteOffice2010Blue.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteOffice2010Blue.Tag = "Office2010Blue";
            this.menuItemPaletteOffice2010Blue.Text = "Office 2010 - Blue";
            // 
            // menuItemPaletteOffice2010Silver
            // 
            this.menuItemPaletteOffice2010Silver.Name = "menuItemPaletteOffice2010Silver";
            this.menuItemPaletteOffice2010Silver.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteOffice2010Silver.Tag = "Office2010Silver";
            this.menuItemPaletteOffice2010Silver.Text = "Office 2010 - Silver";
            // 
            // menuItemPaletteOffice2010Black
            // 
            this.menuItemPaletteOffice2010Black.Name = "menuItemPaletteOffice2010Black";
            this.menuItemPaletteOffice2010Black.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteOffice2010Black.Tag = "Office2010Black";
            this.menuItemPaletteOffice2010Black.Text = "Office 2010 - Black";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(205, 6);
            // 
            // menuItemPaletteSparkleBlue
            // 
            this.menuItemPaletteSparkleBlue.Name = "menuItemPaletteSparkleBlue";
            this.menuItemPaletteSparkleBlue.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteSparkleBlue.Tag = "SparkleBlue";
            this.menuItemPaletteSparkleBlue.Text = "Sparkle - Blue";
            // 
            // menuItemPaletteSparkleOrange
            // 
            this.menuItemPaletteSparkleOrange.Name = "menuItemPaletteSparkleOrange";
            this.menuItemPaletteSparkleOrange.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteSparkleOrange.Tag = "SparkleOrange";
            this.menuItemPaletteSparkleOrange.Text = "Sparkle - Orange";
            // 
            // menuItemPaletteSparklePurple
            // 
            this.menuItemPaletteSparklePurple.Name = "menuItemPaletteSparklePurple";
            this.menuItemPaletteSparklePurple.Size = new System.Drawing.Size(208, 22);
            this.menuItemPaletteSparklePurple.Tag = "SparklePurple";
            this.menuItemPaletteSparklePurple.Text = "Sparkle - Purple";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(65, 20);
            this.menuItemHelp.Text = "Справка";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStripApp);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dockPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(962, 397);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(962, 468);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuApp);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripApp);
            // 
            // statusStripApp
            // 
            this.statusStripApp.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStripApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatusWordType,
            this.toolStatusPronunciation,
            this.toolStatusComment,
            this.toolStatusLoading});
            this.statusStripApp.Location = new System.Drawing.Point(0, 0);
            this.statusStripApp.Name = "statusStripApp";
            this.statusStripApp.Size = new System.Drawing.Size(962, 22);
            this.statusStripApp.TabIndex = 4;
            // 
            // toolStatusWordType
            // 
            this.toolStatusWordType.Name = "toolStatusWordType";
            this.toolStatusWordType.Size = new System.Drawing.Size(88, 17);
            this.toolStatusWordType.Text = "Часть речи: {0}";
            // 
            // toolStatusPronunciation
            // 
            this.toolStatusPronunciation.Name = "toolStatusPronunciation";
            this.toolStatusPronunciation.Size = new System.Drawing.Size(113, 17);
            this.toolStatusPronunciation.Text = "Произношение: {0}";
            // 
            // toolStatusComment
            // 
            this.toolStatusComment.Name = "toolStatusComment";
            this.toolStatusComment.Size = new System.Drawing.Size(104, 17);
            this.toolStatusComment.Text = "Комментарий: {0}";
            // 
            // toolStatusLoading
            // 
            this.toolStatusLoading.Name = "toolStatusLoading";
            this.toolStatusLoading.Size = new System.Drawing.Size(59, 17);
            this.toolStatusLoading.Text = "Loading...";
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(962, 397);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            autoHideStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            dockPaneStripSkin1.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.dockPanel1.TabIndex = 4;
            // 
            // toolStripApp
            // 
            this.toolStripApp.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripApp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.toolStripApp.Location = new System.Drawing.Point(3, 24);
            this.toolStripApp.Name = "toolStripApp";
            this.toolStripApp.Size = new System.Drawing.Size(43, 25);
            this.toolStripApp.TabIndex = 3;
            // 
            // paletteManager
            // 
            this.paletteManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.ProfessionalSystem;
            // 
            // backgroundLoading
            // 
            this.backgroundLoading.WorkerReportsProgress = true;
            this.backgroundLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundLoading_DoWork);
            this.backgroundLoading.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundLoading_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 468);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "MainForm";
            this.Text = "VocabularyTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.menuApp.ResumeLayout(false);
            this.menuApp.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStripApp.ResumeLayout(false);
            this.statusStripApp.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.ComponentModel.BackgroundWorker backgroundLoading;
    }
}
