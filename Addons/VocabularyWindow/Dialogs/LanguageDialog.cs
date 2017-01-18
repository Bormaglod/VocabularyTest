//-----------------------------------------------------------------------
// <copyright file="LanguageDialog.cs" company="Тепляшин Сергей Васильевич">
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
// <date>26.11.2010</date>
// <time>15:12</time>
// <summary>Defines the LanguageDialog class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.VocabularyWindow

{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using ComponentLib.Globalization;
    using Data;
    using Data.Entities;
    using Addons;
    using VocabularyTest.Core;
    using VocabularyTest.Core.Dialogs;
    using NHibernate;

    public partial class LanguageDialog : KryptonForm
    {
        bool updating;
        bool adding;
        Theme theme;
        IList<Language> languages;
        IList<Culture> cultures;

        public LanguageDialog()
        {
            InitializeComponent();
            
            foreach (string flagImage in imageSmallFlags.Images.Keys)
            {
                comboFlag.Items.Add(
                    new KryptonListItem()
                    {
                        ShortText = flagImage.Substring(0, flagImage.Length - 4),
                        Image = imageSmallFlags.Images[flagImage]
                    });
            }

            cultures = Cultures.CreateListCultures();
            comboLang.Items.AddRange(AvailableCultures.ToArray());
        }

        IEnumerable<Language> CurrentLanguageList => listLang.Items.OfType<KryptonListItem>().Select(x => (Language)x.Tag);

        IEnumerable<Culture> AvailableCultures => cultures.Where(x => CurrentLanguageList.FirstOrDefault(y => y.CultureIdentifier == x.Id) == null);

        static public bool ShowDialog(IHost host, IWin32Window owner, Theme theme)
        {
            LanguageDialog dialog = new LanguageDialog();
            return dialog.ShowDialog(host, owner, theme.Id);
        }

        public bool ShowDialog(IHost host, IWin32Window owner, int themeId)
        {
            using (ISession session = DataHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    theme = session.Get<Theme>(themeId);
                    languages = session.QueryOver<Language>().List();
                    Fill(host, theme);
                    if (ShowDialog(owner) == DialogResult.OK)
                    {
                        try
                        {
                            session.SaveOrUpdate(theme);
                            transaction.Commit();
                            return true;
                        }
                        catch (ADOException e)
                        {
                            transaction.Rollback();
                            Trace.TraceError(ErrorHelper.Message(e));
                            ErrorHelper.ShowDbError(this, e);
                        }
                        
                    }
                }
            }

            return false;
        }
        
        void Fill(IHost host, Theme theme)
        {
            foreach (ISpellDictionary d in host.Dictionaries.Items)
            {
                comboDicts.Items.Add(d);
            }
            
            foreach (Language language in theme.Languages)
            {
                AddItem(language);
            }
            
            listLang.SelectedIndex = 0;
        }

        KryptonListItem CreateItem(Language language)
        {
            return 
                new KryptonListItem()
                {
                    ShortText = language.Name,
                    Image = string.IsNullOrWhiteSpace(language.ImageKey) ? null : imageLargeFlags.Images[language.ImageKey],
                    Tag = language
                };
        }

        KryptonListItem AddItem(KryptonListItem replaced, Language language)
        {
            adding = true;
            try
            {
                KryptonListItem item = CreateItem(language);

                int selected = listLang.SelectedIndex;
                int index = listLang.Items.IndexOf(replaced);
                listLang.Items.Remove(replaced);
                listLang.Items.Insert(index, item);
                listLang.SelectedIndex = selected;

                return item;
            }
            finally
            {
                adding = false;
            }
        }

        KryptonListItem AddItem(Language language)
        {
            adding = true;
            try
            {
                KryptonListItem item = CreateItem(language);
                listLang.Items.Add(item);
                return item;
            }
            finally
            {
                adding = false;
            }
        }

        void RefreshLanguageProperty(Language language)
        {
            labelHeader.Text = $"{Strings.PropertyLanguage} {language}";
            pictureFlag.Image = imageLargeFlags.Images[language.ImageKey];

            listTenses.Items.Clear();
            foreach (Tense tense in language.Tenses)
            {
                listTenses.Items.Add(tense);
            }

            if (listTenses.Items.Count > 0)
            {
                listTenses.SelectedIndex = 0;
            }
        }
        
        void FillLanguageProperty()
        {
            updating = true;
            try
            {
                if (listLang.SelectedIndex != -1)
                {
                    Language language = (Language)((KryptonListItem)listLang.Items[listLang.SelectedIndex]).Tag;

                    RefreshLanguageProperty(language);
                    
                    comboLang.SelectedIndex = GetLanguageIndex(language);
                    comboFlag.SelectedIndex = GetFlagIndex(language);
                    textName.Text = language.AlternateName;
                    
                    comboDicts.SelectedIndex = GetDictionary(language);
                    UpdateButtons();
                    
//                foreach (Control c in tablePronouns.Controls)
//                {
//                    if (c is KryptonTextBox)
//                    {
//                        string s = c.Tag.ToString();
//                        s = s.PadLeft(2, '0');
//                        int i = Convert.ToInt32(s[0]);
//                        int j = Convert.ToInt32(s[1]);
//                        switch (j) {
//                            case 0:
//                                (c as KryptonTextBox).Text = l.work.PronounsSingular[i];
//                                break;
//                        }
//                    }
//                }
                
                    EnableControls(true);
                }
                else
                {
                    EnableControls(false);
                }
            }
            finally
            {
                updating = false;
            }
        }
        
        int GetLanguageIndex(Language lang)
        {
            for (int i = 0; i < comboLang.Items.Count; i++)
            {
                if (((Culture)comboLang.Items[i]).Id == lang.CultureIdentifier)
                {
                    return i;
                }
            }
            
            return -1;
        }
        
        int GetFlagIndex(Language lang)
        {
            for (int i = 0; i < comboFlag.Items.Count; i++)
            {
                string s = ((KryptonListItem)comboFlag.Items[i]).ShortText;
                
                if (lang.ImageKey == s + ".ico")
                {
                    return i;
                }
            }
            
            return -1;
        }
        
        int GetDictionary(Language lang)
        {
            for (int i = 0; i < comboDicts.Items.Count; i++)
            {
                if (((ISpellDictionary)comboDicts.Items[i]).Locale == lang.DictionaryLocale)
                {
                    return i;
                }
            }
            
            return -1;
        }
        
        void UpdateButtons()
        {
            buttonChangeTense.Enabled = listTenses.SelectedIndex != -1;
            buttonDeleteTense.Enabled = listTenses.SelectedIndex != -1;
        }
        
        void EnableControls(bool enable)
        {
            tabMain.Enabled = enable;
            tabPage3.Enabled = false;//enable;
            tabTense.Enabled = enable;
            tabArticle.Enabled = false;//enable;
            if (enable)
            {
                UpdateControls();
            }
            else
            {
                ClearAllControls();
            }
        }
        
        void ClearAllControls()
        {
            foreach (TabPage page in tcProperty.TabPages)
            {
                ClearAllControls(page.Controls);
            }
        }
        
        void ClearAllControls(IEnumerable controls)
        {
            foreach (Control c in controls)
            {
                KryptonComboBox combo = c as KryptonComboBox;
                if (combo != null)
                {
                    combo.SelectedIndex = -1;
                    continue;
                }
                
                KryptonTextBox text = c as KryptonTextBox;
                if (text != null)
                {
                    text.Text = string.Empty;
                    continue;
                }
                
                KryptonCheckBox check = c as KryptonCheckBox;
                if (check != null)
                {
                    check.Checked = false;
                }
                
                KryptonListBox list = c as KryptonListBox;
                if (list != null)
                {
                    list.Items.Clear();
                }
                
                TableLayoutPanel table = c as TableLayoutPanel;
                if (table != null)
                {
                    ClearAllControls(table.Controls);
                }
            }
        }
        
        void UpdateControls()
        {
            checkNeutral.Enabled = checkDifferent.Checked;
            
            textSingularNeutral.Enabled = checkNeutral.Checked && checkDifferent.Checked;
            textDualNeutral.Enabled = checkNeutral.Checked && checkDifferent.Checked;
            textPluralNeutral.Enabled = checkNeutral.Checked && checkDifferent.Checked;
            
            ColumnStyle cs = tablePronouns.ColumnStyles[2];
            if (checkDual.Checked)
            {
                cs.SizeType = SizeType.Percent;
                cs.Width = 33;
            }
            else
            {
                cs.SizeType = SizeType.Absolute;
                cs.Width = 0;
            }
        }
        
        void ListLangSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!adding)
            {
                FillLanguageProperty();
            }
        }
        
        void ComboFlagSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFlag.SelectedIndex != -1 && listLang.SelectedIndex != -1 && !updating)
            {
                KryptonListItem item = (KryptonListItem)listLang.Items[listLang.SelectedIndex];
                Language language = (Language)item.Tag;
                
                language.ImageKey = comboFlag.Text + ".ico";
                
                AddItem(item, language);
                RefreshLanguageProperty(language);
            }
        }
        
       void ComboLangSelectedIndexChanged(object sender, EventArgs e)
       {
            if (comboLang.SelectedIndex != -1 && listLang.SelectedIndex != -1 && !updating)
            {
                Culture culture = (Culture)comboLang.Items[comboLang.SelectedIndex];
                KryptonListItem item = (KryptonListItem)listLang.Items[this.listLang.SelectedIndex];

                Language language = languages.SingleOrDefault<Language>(x => x.CultureIdentifier == culture.Id) ?? new Language(culture);
                theme.ReplaceLanguage((Language)item.Tag, language);
                AddItem(item, language);

                RefreshLanguageProperty(language);
            }
        }
        
        void TextNameTextChanged(object sender, EventArgs e)
        {
            if (listLang.SelectedIndex != -1 && !updating)
            {
                KryptonListItem item = (KryptonListItem)listLang.Items[listLang.SelectedIndex];
                Language language = (Language)item.Tag;
                language.AlternateName = textName.Text.NullIfEmpty();

                RefreshLanguageProperty(language);
            }
        }

        void ButtonAddLangClick(object sender, EventArgs e)
        {
            Culture culture = AvailableCultures.FirstOrDefault();
            if (culture == null)
            {
                return;
            }

            Language language = languages.SingleOrDefault<Language>(x => x.CultureIdentifier == culture.Id) ?? new Language(culture);
            theme.AddLanguage(language);
            AddItem(language);

            RefreshLanguageProperty(language);
        }
        
        void ButtonDeleteLangClick(object sender, EventArgs e)
        {
            if (listLang.SelectedIndex != -1)
            {
                Language language = (Language)((KryptonListItem)listLang.Items[listLang.SelectedIndex]).Tag;
                if (KryptonMessageBox.Show(string.Format(Strings.QuestionDeleteIdentifier,  language), Strings.DeletingLanguage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listLang.Items.RemoveAt(listLang.SelectedIndex);
                    theme.RemoveLanguage(language);

                    RefreshLanguageProperty(language);

                    if (listLang.SelectedIndex == -1)
                    {
                        EnableControls(false);
                    }
                }
            }
        }
        
        void ButtonAddTenseClick(object sender, EventArgs e)
        {
            if (listLang.SelectedIndex != -1)
            {
                string tenseName;
                if (EditValueDialog.ShowDialog(this, Strings.TenseNameHeader, Strings.TenseNameEnter, string.Empty, out tenseName))
                {
                    KryptonListItem item = (KryptonListItem)this.listLang.Items[this.listLang.SelectedIndex];
                    Language language = (Language)item.Tag;
                    listTenses.Items.Add(language.AddTense(tenseName));
                }
            }
        }
        
        void ButtonChangeTenseClick(object sender, EventArgs e)
        {
            if (listLang.SelectedIndex != -1 && listTenses.SelectedIndex != -1)
            {
                string tenseName;
                Tense selected_tense = (Tense)listTenses.SelectedItem;
                if (EditValueDialog.ShowDialog(this, Strings.TenseNameHeader, Strings.TenseNameEnter, selected_tense.Name, out tenseName))
                {
                    KryptonListItem item = (KryptonListItem)listLang.Items[this.listLang.SelectedIndex];
                    Language language = (Language)item.Tag;

                    selected_tense.Name = tenseName;
                    listTenses.Refresh();
                }
            }
        }
        
        void ButtonDeleteTenseClick(object sender, EventArgs e)
        {
            if (listLang.SelectedIndex != -1 && listTenses.SelectedIndex != -1)
            {
                Tense selected_tense = (Tense)listTenses.SelectedItem;

                KryptonListItem item = (KryptonListItem)listLang.Items[listLang.SelectedIndex];
                Language language = (Language)item.Tag;

                language.RemoveTense(selected_tense);
                listTenses.Items.Remove(selected_tense);
            }
        }
        
        void CheckDifferentCheckedChanged(object sender, EventArgs e)
        {
            //this.UpdateControls();
        }
        
        void CheckNeutralCheckedChanged(object sender, EventArgs e)
        {
            //this.UpdateControls();
        }
        
        void CheckDualCheckedChanged(object sender, EventArgs e)
        {
            //this.UpdateControls();
        }
        
        void ChangePronounsData(object sender, EventArgs e)
        {
            // TODO: Изменение личных местоимений
            /*if (listLang.SelectedIndex != -1)
            {
                KryptonListItem item = (KryptonListItem)listLang.Items[listLang.SelectedIndex];
                LangPair lang = (LangPair)item.Tag;
                
                if (sender is KryptonTextBox)
                {
                    KryptonTextBox textBox = sender as KryptonTextBox;
                    
                    string s = textBox.Tag.ToString();
                    s = s.PadLeft(2, '0');
                    int i = Convert.ToInt32(s[0]);
                    int j = Convert.ToInt32(s[1]);
                    switch (j) {
                        case 0:
                            lang.work.PronounsSingular[i] = textBox.Text;
                            break;
                    }
                }
            }*/
        }
        
        void ComboDictsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listLang.SelectedIndex != -1)
            {
                KryptonListItem item = (KryptonListItem)listLang.Items[listLang.SelectedIndex];
                Language language = (Language)item.Tag;
                
                if (comboDicts.SelectedIndex != -1)
                {
                    ISpellDictionary d = (ISpellDictionary)comboDicts.Items[comboDicts.SelectedIndex];
                    language.DictionaryLocale = d.Locale;
                }
                else
                {
                    language.DictionaryLocale = null;
                }
            }
        }
        
        void ButtonSpecAny1Click(object sender, EventArgs e)
        {
            comboDicts.SelectedIndex = -1;
        }
        
        void ListTensesSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }
    }
}
