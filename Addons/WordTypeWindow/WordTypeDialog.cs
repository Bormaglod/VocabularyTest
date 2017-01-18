//-----------------------------------------------------------------------
// <copyright file="WordTypeDialog.cs" company="Тепляшин Сергей Васильевич">
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
// <date>23.11.2010</date>
// <time>8:58</time>
// <summary>Defines the WordTypeDialog class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Addons.WordTypeWindow
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Core;
    using Data.Entities;
    using VocabularyTest.Core.Dialogs;
    
    public partial class WordTypeDialog : ObjectDialog<WordType>
    {
        Theme theme;
        
        public WordTypeDialog(Theme theme)
        {
            InitializeComponent();
            ActiveControl = textWordTypeName;
            
            this.theme = theme;
        }
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            theme = Session.Get<Theme>(theme.Id);
            foreach (Language lang in theme.Languages)
            {
                AddLanguage(lang);
            }
            
            comboSpecial.SelectedIndex = (int)WordType.grammatical.none;
        }
        
        protected override void OnBeforeEditingObject()
        {
            base.OnBeforeEditingObject();
            textWordTypeName.Text = Current.Name;
            comboSpecial.SelectedIndex = (int)Current.Special;
            foreach (Language language in theme.Languages)
            {
                Abbreviation abbreviation = Current.Abbreviations.FirstOrDefault(x => x.Language.Id == language.Id);
                if (abbreviation == null)
                {
                    continue;
                }
                
                foreach (DataGridViewRow row in gridShortNames.Rows)
                {
                    Language lid = (Language)row.Tag;
                    if (lid == language)
                    {
                        row.Cells["ColumnShortName"].Value = abbreviation;
                        break;
                    }
                }
            }
        }
        
        protected override void OnBeforeCommitObject()
        {
            base.OnBeforeCommitObject();
            Current.Name = textWordTypeName.Text;
            Current.Special = comboSpecial.SelectedIndex != -1 ? (WordType.grammatical)comboSpecial.SelectedIndex : WordType.grammatical.none;;
            foreach (DataGridViewRow row in gridShortNames.Rows)
            {
                Current.AddAbbreviation((Abbreviation)row.Cells["ColumnShortName"].Value);
            }
        }
        
        protected override void OnBeforeCreatingObject()
        {
            base.OnBeforeCreatingObject();
            if (MasterEntity != null)
            {
                Current.ParentId = MasterEntity.Id;
            }
        }
        
        void AddLanguage(Language language)
        {
            int row = gridShortNames.Rows.Add();
            gridShortNames.Rows[row].Tag = language;
            gridShortNames.Rows[row].Cells["ColumnLangauge"].Value = language.Name;
            gridShortNames.Rows[row].Cells["ColumnShortName"].Value = null;
            gridShortNames.Rows[row].Cells["ColumnButtonChange"].Value = Strings.Change;
        }
        
        void TextWordTypeNameTextChanged(object sender, EventArgs e)
        {
            CanUpdate = textWordTypeName.Text.Length > 0;
        }
        
        void GridShortNamesCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                string abbreviationText;
                Abbreviation abbreviation = gridShortNames.Rows[e.RowIndex].Cells["ColumnShortName"].Value as Abbreviation;
                if (EditValueDialog.ShowDialog(
                    this, 
                    Strings.Abbreviation, 
                    Strings.EnterAbbreviation, 
                    abbreviation == null ? string.Empty : abbreviation.Name,
                    out abbreviationText))
                {
                    if (abbreviation == null)
                    {
                        abbreviation = new Abbreviation();
                    }
                    
                    abbreviation.Name = abbreviationText;
                    abbreviation.Language = (Language)gridShortNames.Rows[e.RowIndex].Tag;
                    gridShortNames.Rows[e.RowIndex].Cells["ColumnShortName"].Value = abbreviation;
                    gridShortNames.Refresh();
                }
            }
        }
    }
}
