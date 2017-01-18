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
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using Addons;
    using Configuration;
    using Core;
    using Data;
    using Data.Entities;
    using NHibernate;
    using WeifenLuo.WinFormsUI.Docking;

    [Export(typeof(IHost))]
    public partial class MainForm : KryptonForm, IHost
    {
        struct DictionaryProperty
        {
            public Dictionaries Dictionaries;
            public IEnumerable<Language> Languages;

            public DictionaryProperty(Dictionaries dictionaries, IEnumerable<Language> languages)
            {
                Dictionaries = dictionaries;
                Languages = languages;
            }
        }

        readonly VocabularyTestSettings settings = VocabularyTestSettings.GetSection(ConfigurationUserLevel.None);
        
        Dictionaries dictionaries;
        Menu mainMenu;
        ToolBar toolBar;
        Theme currentTheme;
        Account user;
        AddonDispatcher addons;

        [Import(typeof(IVocabularyWindow))]
        IVocabularyWindow vocabularyWindow { get; set; }

        public MainForm()
        {
            CultureInfo ci = new CultureInfo(settings.View.LocalCode);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            InitializeComponent();
            
            CurrentPaletteMode = settings.View.Mode;
            Size = new Size(settings.View.Size.Width, settings.View.Size.Height);
            
            dictionaries = new Dictionaries(settings.Folders.Spelling.WithDefaultFolder);
            
            CreateApplicationComponents();
            AssemblyAddonsComponents();
        }
        
        PaletteModeManager CurrentPaletteMode
        {
            get
            {
                foreach (ToolStripMenuItem item in menuItemPalettes.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    if (item.Checked)
                    {
                        return (PaletteModeManager)Enum.Parse(typeof(PaletteModeManager), item.Tag.ToString());
                    }
                }
                
                return PaletteModeManager.ProfessionalSystem;
            }
            
            set
            {
                ToolStripMenuItem menuItem = menuItemPalettes.DropDownItems.OfType<ToolStripMenuItem>().FirstOrDefault(x => x.Checked);
                if (menuItem != null)
                {
                    menuItem.Checked = false;
                }
                
                foreach (ToolStripMenuItem item in menuItemPalettes.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    if (item.Tag != null)
                    {
                        PaletteModeManager mode = (PaletteModeManager)Enum.Parse(typeof(PaletteModeManager), item.Tag.ToString());
                        if (mode == value)
                        {
                            item.Checked = true;
                            paletteManager.GlobalPaletteMode = value;
                        }
                    }
                }
            }
        }
        
        #region IApplication interface
        
        DockPanel IHost.Workbench => dockPanel1;
        
        IMenu IHost.MainMenu => mainMenu;
        
        IToolBar IHost.ToolBar => toolBar;
        
        IDictionaries IHost.Dictionaries => dictionaries;

        ISettings IHost.Settings => settings;

        Theme IHost.CurrentTheme => currentTheme;

        Account IHost.User => user;

        bool IHost.Open(Theme theme)
        {
            user = SelectUserDialog.Get(this);
            if (user != null)
            {
                currentTheme = theme;
                Text = $"{Strings.VocabularyTest} - {theme.Name}";
                LoadWindowLayout();
                addons.Run();
                using (ISession session = DataHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        try
                        {
                            currentTheme.AccessDate = DateTime.Now;
                            session.SaveOrUpdate(currentTheme);
                            transaction.Commit();
                            backgroundLoading.RunWorkerAsync(new DictionaryProperty(dictionaries, theme.Languages.ToList()));
                            return true;
                        }
                        catch (ADOException e)
                        {
                            transaction.Rollback();
                            Trace.TraceError(ErrorHelper.Message(e));
                            ErrorHelper.ShowDbError(this, e);
                            return false;
                        }
                    }
                }
            }
            
            return false;
        }
        
        bool IHost.Create()
        {
            currentTheme = ThemeDialog.Create(this);
            if (currentTheme != null)
            {
                user = SelectUserDialog.Get(this);
                if (user != null)
                {

                    Text = $"{Strings.VocabularyTest} - {currentTheme.Name}";
                    LoadWindowLayout();
                    addons.Run();
                    return true;
                }
            }

            return false;
        }

        bool IHost.Delete(Theme theme)
        {
            if (KryptonMessageBox.Show(this, Strings.QuestionDeleteTheme, Strings.DeleteTheme, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Account user = SelectUserDialog.Get(this);
                if (user == null)
                {
                    return false;
                }

                using (ISession session = DataHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        try
                        {
                            session.Delete(theme);
                            transaction.Commit();
                            return true;
                        }
                        catch (ADOException e)
                        {
                            transaction.Rollback();
                            Trace.TraceError(ErrorHelper.Message(e));
                            ErrorHelper.ShowDbError(this, e);
                            return false;
                        }
                        
                    }
                }
            }

            return false;
        }

        bool IHost.Hide(Theme theme)
        {
            return false;
        }

        void IHost.StartPractice(Theme theme)
        {
            
        }
        
        void IHost.LoadVocabulary()
        {
            
        }

        void IHost.ExecuteCommand(int command, object data)
        {
            foreach (IAddon addon in addons)
            {
                addon.ExecuteCommand(command, data);
            }
        }

        #endregion

        void CreateApplicationComponents()
        {
            mainMenu = new Menu(menuApp.Items);
            toolBar = new ToolBar(toolStripApp);
        }

        void FillDirectoryCatalog(AggregateCatalog catalog, string path)
        {
            foreach (string folder in Directory.EnumerateDirectories(path))
            {
                catalog.Catalogs.Add(new DirectoryCatalog(folder));
                FillDirectoryCatalog(catalog, folder);
            }
        }
        
        void AssemblyAddonsComponents()
        {
            try
            {
                AggregateCatalog catalog = new AggregateCatalog();
                
                string addonsFolder = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath) + "\\AddOns";
                catalog.Catalogs.Add(new DirectoryCatalog(addonsFolder));
                FillDirectoryCatalog(catalog, addonsFolder);
                
                catalog.Catalogs.Add(new ApplicationCatalog());
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
                addons = new AddonDispatcher(container);
                
            }
            catch (Exception e)
            {
                Trace.TraceError(ErrorHelper.Message(e));
                throw new Exception(Strings.ErrorLoadingAddons, e);
            }
        }
        
        IDockContent GetContent(string persistString)
        {
            foreach (IAddon addon in addons)
            {
                if (persistString == addon.GetType().ToString())
                {
                    return (IDockContent)addon;
                }
            }
            
            return null;
        }
        
        void LoadWindowLayout(string fileName)
        {
            while (dockPanel1.Contents.Count > 0)
            {
                DockContent content = (DockContent)dockPanel1.Contents[0];
                ((IAddon)content).Stop();
            }
            
            dockPanel1.LoadFromXml(fileName, GetContent);
        }
        
        void LoadWindowLayout()
        {
            if (File.Exists("CurrentSchema.xml"))
            {
                LoadWindowLayout("CurrentSchema.xml");
            }
            else if (File.Exists("DefaultSchema.xml"))
            {
                LoadWindowLayout("DefaultSchema.xml");
            }
        }
        
        void  SaveSettings()
        {
            dockPanel1.SaveAsXml("CurrentSchema.xml");
            settings.View.Size.Width = Size.Width;
            settings.View.Size.Height = Size.Height;
            settings.View.Mode = CurrentPaletteMode;
            settings.Save();
        }
        
        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
        
        void MenuItemExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void backgroundLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            DictionaryProperty property = (DictionaryProperty)e.Argument;
            foreach (Language language in property.Languages)
            {
                foreach (SpellDictionary d in property.Dictionaries.Items.Where(x => x.Locale == language.DictionaryLocale))
                {
                    d.Load();
                }
            }

            property.Dictionaries.Loaded = true;
        }

        private void backgroundLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            vocabularyWindow.SpellCheckEntries();
        }
    }
}
