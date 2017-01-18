//-----------------------------------------------------------------------
// <copyright file="SpellDictionary.cs" company="Тепляшин Сергей Васильевич">
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
// <time>10:35</time>
// <summary>Defines the SpellDictionary class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest
{
    using NHunspell;
    using Addons;

    public class SpellDictionary : ISpellDictionary
    {
        readonly string locale;
        string localeName;
        string displayName;
        bool isLoad;
        bool isLoading;
        SpellEngine engine;
        string hunspellAffFile;
        string hunspellDictFile;
        string hyphenDictFile;
        string myThesIdxFile;
        string myThesDatFile;
        
        public SpellDictionary(SpellEngine spellEngine, string localeLang, string dispName)
        {
            engine = spellEngine;
            locale = localeLang;
            displayName = dispName;
            hunspellAffFile = string.Empty;
            hunspellDictFile = string.Empty;
            hyphenDictFile = string.Empty;
            myThesIdxFile = string.Empty;
            myThesDatFile = string.Empty;
            localeName = string.Empty;
        }

        public string Locale => locale;

        public string LocaleName => localeName;

        public string DisplayName => displayName;

        public bool IsLoad => isLoad;

        public SpellEngine Engine => engine;
        
        public SpellFactory SpellFactory
        {
            get
            {
                if (isLoading)
                {
                    return null;
                }
                
                if (!isLoad)
                {
                    Load();
                }
               
                return engine[locale];
            }
        }
        
        public string HunspellAffFile => hunspellAffFile;
        
        public string HunspellDictFile => hunspellDictFile;
        
        public string HyphenDictFile => hyphenDictFile;
        
        //public string MyThesIdxFile => myThesIdxFile;
        
        public string MyThesDatFile => myThesDatFile;
        
        public void Load()
        {
            isLoading = true;
            try
            {
                LanguageConfig config = new LanguageConfig()
                {
                    LanguageCode = Locale,
                    HunspellAffFile = HunspellAffFile,
                    HunspellDictFile = HunspellDictFile,
                    HunspellKey = string.Empty,
                    HyphenDictFile = HyphenDictFile
                };

                /*if (!string.IsNullOrEmpty(MyThesIdxFile))
                {
                    config.MyThesIdxFile = MyThesIdxFile;
                }*/
                
                config.MyThesDatFile = MyThesDatFile;
                Engine.AddLanguage(config);
                isLoad = true;
            }
            finally
            {
                isLoading = false;
            }
        }
        
        public void SetSpellFiles(string aff, string dic)
        {
            hunspellAffFile = aff;
            hunspellDictFile = dic;
        }
        
        public void SetHyphFiles(string dic)
        {
            hyphenDictFile = dic;
        }
        
        public void SetThesFiles(string dat, string idx)
        {
            myThesDatFile = dat;
            myThesIdxFile = idx;
        }
        
        public void UpdateLocaleName(string name)
        {
            localeName = name;
        }
        
        public override string ToString() => string.IsNullOrEmpty(localeName) ? locale : localeName;
    }
}
