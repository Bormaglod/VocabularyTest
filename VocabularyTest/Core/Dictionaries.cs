//-----------------------------------------------------------------------
// <copyright file="Dictionaries.cs" company="Тепляшин Сергей Васильевич">
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
// <date>13.12.2010</date>
// <time>10:39</time>
// <summary>Defines the Dictionaries class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;
    using ComponentFactory.Krypton.Toolkit;
    using NHunspell;
    using Addons;
    using Data.Entities;

    public class Dictionaries : IDisposable, IDictionaries
    {
        bool disposed;
        List<SpellDictionary> dicts;
        readonly SpellEngine engine;
        IEnumerable<string> dictFolders;
        
        string tempLocalDir;
        string tempDisplayName;
        
        public Dictionaries(IEnumerable<string> dictionaryFolders)
        {
            dictFolders = dictionaryFolders;
            dicts = new List<SpellDictionary>();
            engine = new SpellEngine();

            KryptonTaskDialog dialog = new KryptonTaskDialog();
            dialog.WindowTitle = Strings.ErrorLoadDict;
            dialog.CheckboxText = Strings.IgnoreError;
            dialog.CheckboxState = false;
            dialog.Icon = MessageBoxIcon.Error;
                
            foreach (string folder in dictFolders)
            {
                if (!Directory.Exists(folder))
                {
                    continue;
                }

                string[] dictSubFolders = Directory.GetDirectories(folder);
                if (dictSubFolders.Length == 0)
                {
                    ShowErrorLoadDictionary(dialog, folder);
                }
                else
                {
                    foreach (string subFolder in dictSubFolders)
                    {
                        try
                        {
                            LoadDictionary(subFolder);
                            CultureInfo[] cultureinfo = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
                            foreach (CultureInfo info in cultureinfo)
                            {
                                foreach (SpellDictionary dict in dicts)
                                {
                                    if (dict.Locale.ToUpperInvariant() == info.Name.ToUpperInvariant())
                                    {
                                        dict.UpdateLocaleName(info.DisplayName);
                                        break;
                                    }
                                }
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            ShowErrorLoadDictionary(dialog, subFolder);
                        }
                    }
                }
            }
        }

        IEnumerable<ISpellDictionary> IDictionaries.Items => dicts.Cast<ISpellDictionary>();

        public IList<SpellDictionary> Items => dicts;
        
        public SpellDictionary this[Language lang] => GetDictionary(lang.DictionaryLocale);
        
        public bool Loaded { get; set; }

        #region IDisposable
        
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        #endregion
        
        public SpellFactory GetSpellFactory(Language lang) => GetDictionary(lang.DictionaryLocale)?.SpellFactory;
        
        static string GetValueNode(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                if (node.Name == "value")
                {
                    return node.InnerText;
                }
            }
            
            return string.Empty;
        }
        
        static string GetDisplayName(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                if (node.Name == "name")
                {
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        if ((attr.Name == "lang") && (attr.Value == "en"))
                        {
                            return node.InnerText;
                        }
                    }
                }
            }
            
            return string.Empty;
        }

        void LoadDictionary(string dir)
        {
            string file = dir + Strings.FileDescriptionXML;
            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }

            tempLocalDir = dir;
            
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            
            XmlNode root = doc.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == Strings.NodeDisplayName)
                {
                    tempDisplayName = Dictionaries.GetDisplayName(node.ChildNodes);
                    LoadDictionaryXCU();
                }
            }
        }
        
        void LoadDictionaryXCU()
        {
            string file = tempLocalDir + Strings.FileDescriptionXCU;
            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(file);
        
            XmlNode root = doc.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if ((attr.Name == Strings.NodeAttributeName) && (attr.Value == Strings.NodeServiceManager))
                    {
                        LoadServiceManager(node.ChildNodes);
                    }
                }
            }
        }
        
        void LoadServiceManager(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if ((attr.Name == Strings.NodeAttributeName) && (attr.Value == Strings.NodeDictionaries))
                    {
                        LoadDictionaries(node.ChildNodes);
                    }
                }
            }
        }
        
        void LoadDictionaries(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                LoadPropertyDictionary(node.ChildNodes);
            }
        }
        
        void LoadPropertyDictionary(XmlNodeList nodes)
        {
            string loc = string.Empty;
            string format = string.Empty;
            string locale = string.Empty;
            
            foreach (XmlNode node in nodes)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if (attr.Name == Strings.NodeAttributeName)
                    {
                        switch (attr.Value)
                        {
                            case "Locations":
                                loc = GetValueNode(node.ChildNodes);
                                break;
                            case "Format":
                                format = GetValueNode(node.ChildNodes);
                                break;
                            case "Locales":
                                locale = GetValueNode(node.ChildNodes);
                                break;
                        }
                    }
                }
            }
            
            // получим все локали для словаря
            string[] locales = locale.Split(new char[] { ' ' });
            foreach (string l in locales)
            {
                SpellDictionary dict = GetDictionary(l) ?? CreateDictionary(l);
                SetPropertyDictionary(dict, format, loc);
            }
        }
        
        void SetPropertyDictionary(SpellDictionary dict, string format, string location)
        {
            string[] files = location.Split(new char[] { ' ' });
            string aff = string.Empty;
            string dic = string.Empty;
            string idx = string.Empty;
            string dat = string.Empty;
            
            foreach (string file in files)
            {
                string f = file.Replace("%origin%", this.tempLocalDir).Replace('/', '\\');
                switch (Path.GetExtension(f).ToLowerInvariant())
                {
                    case ".aff":
                        aff = f;
                        break;
                    case ".dic":
                        dic = f;
                        break;
                    case ".dat":
                        dat = f;
                        break;
                    case ".idx":
                        idx = f;
                        break;
                }
            }
            
            switch (format)
            {
                case "DICT_SPELL":
                    dict.SetSpellFiles(aff, dic);
                    break;
                case "DICT_HYPH":
                    dict.SetHyphFiles(dic);
                    break;
                case "DICT_THES":
                    if (string.IsNullOrEmpty(idx))
                    {
                        string new_idx = dat.Replace(Path.GetExtension(dat), ".idx");
                        if (File.Exists(new_idx))
                        {
                            idx = new_idx;
                        }
                    }
                    
                    dict.SetThesFiles(dat, idx);
                    break;
            }
        }
        
        SpellDictionary GetDictionary(string locale) => dicts.FirstOrDefault(d => d.Locale == locale);
        
        SpellDictionary CreateDictionary(string locale)
        {
            SpellDictionary res = new SpellDictionary(engine, locale, tempDisplayName);
            dicts.Add(res);
            return res;
        }
        
        void ShowErrorLoadDictionary(KryptonTaskDialog dialog, string dir)
        {
            if (!dialog.CheckboxState)
            {
                dialog.Content = string.Format(Strings.DictNotFound, dir);
                dialog.ShowDialog();
            }
        }
        
        void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    engine.Dispose();
                }
            }
            
            disposed = true;         
        }
    }
}
