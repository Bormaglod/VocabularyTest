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

namespace VocabularyTest.Addons.GradeWindow
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using ComponentFactory.Krypton.Toolkit;
    using NHibernate;
    using NHibernate.Transform;
    using Core;
    using Data;
    using Data.Entities;
    using WeifenLuo.WinFormsUI.Docking;

    [Export(typeof(IAddon))]
    public partial class GradeWindow : ToolWindow
    {
        public class GradeCount
        {
            public int Grade { get; set; }
            public int Count { get; set; }
        }

        [Import(typeof(IHost))]
        IHost host { get; set; }

        [Import(typeof(IVocabularyWindow))]
        IVocabularyWindow vocabularyWindow { get; set; }

        public GradeWindow()
        {
            InitializeComponent();
        }

        protected override void DoAddDependence()
        {
            base.DoAddDependence();
            AddDependenceItem("GlobalAddon");
            AddDependenceItem("VocabularyWindow");
        }

        protected override void RunOnce()
        {
            host.MainMenu["View"].Items.AddCommand("ViewGrades", "ColumnsSeparator", Strings.Grades, new ViewWindowCommand(this));

            for (int grade = 7; grade > 0; grade--)
            {
                KryptonListItem item = new KryptonListItem()
                {
                    ShortText = $"{Strings.LevelNumber} {grade}",
                    LongText = 0.ToString(CultureInfo.InvariantCulture),
                    Image = host.Settings.View.UseGradeColors.Enabled ? GetBitmap(grade) : null,
                    Tag = grade
                };

                listGrades.Items.Add(item);
            }

            vocabularyWindow.GradeContentModified += (sender, e) => Update(e.Entities);
            vocabularyWindow.WordsSelected += (sender, e) => Update(e.Words);
        }

        protected override void Run()
        {
            ShowWindow(host.Workbench, DockState.DockLeft);
        }

        KryptonListItem Item(Grade grade) => listGrades.Items.OfType<KryptonListItem>().Single(x => (int)x.Tag == grade.Current);

        void Disable()
        {
            panelLanguage.Visible = false;
            listGrades.Enabled = false;
            foreach (KryptonListItem item in listGrades.Items)
            {
                item.LongText = 0.ToString(CultureInfo.InvariantCulture);
            }

            listGrades.Refresh();
        }

        void Update(IEnumerable<Grade> grades)
        {
            Update(grades.Select(x => x.Word).Distinct());
        }

        void Update(IEnumerable<Word> words)
        {
            switch (words.Count())
            {
                case 0:
                    Disable();
                    break;
                case 1:
                    UpdateCounts(words.First().Language);
                    break;
                default:
                    Language language = words.First().Language;
                    bool different = !words.Any(x => x.Language.Id == language.Id);

                    if (different)
                    {
                        Disable();
                    }
                    else
                    {
                        UpdateCounts(language);
                    }

                    break;
            }
        }

        void UpdateCounts(Language language)
        {
            panelLanguage.Visible = true;
            listGrades.Enabled = true;
            using (ISession session = DataHelper.OpenSession())
            {
                Grade grade = null;
                GradeCount result = null;
                IList<GradeCount> grades = session.QueryOver<Grade>(() => grade)
                    .JoinQueryOver(pr => pr.Word)
                    .SelectList(list => list
                        .SelectGroup(x => x.Current).WithAlias(() => result.Grade)
                        .SelectCount(x => x.Id).WithAlias(() => result.Count))
                    .TransformUsing(Transformers.AliasToBean<GradeCount>())
                    .Where(() => grade.User == host.User)
                    .And(x => x.Language == language)
                    .List<GradeCount>();
                foreach (var item in listGrades.Items.OfType<KryptonListItem>())
                {
                    int gradeValue = (int)item.Tag;
                    int count = grades.SingleOrDefault(x => x.Grade == gradeValue)?.Count ?? 0;
                    item.LongText = count.ToString(CultureInfo.InvariantCulture);
                }
            }

            listGrades.Refresh();
        }

        Bitmap GetBitmap(int grade)
        {
            Bitmap res = new Bitmap(16, 16);

            Graphics g = Graphics.FromImage(res);
            g.FillRectangle(new SolidBrush(host.Settings.View.UseGradeColors[grade].Color), new RectangleF(2, 2, 12, 12));

            return res;
        }
    }
}
