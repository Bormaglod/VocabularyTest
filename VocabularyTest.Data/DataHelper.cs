//-----------------------------------------------------------------------
// <copyright file="DataHelper.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2016 Sergey Teplyashin. All rights reserved.
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
// <date>19.09.2014</date>
// <time>8:39</time>
// <summary>Defines the DataHelper class.</summary>
//-----------------------------------------------------------------------

namespace VocabularyTest.Data
{
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using Mappings;

    public static class DataHelper
    {
        static ISessionFactory sessionFactory;
        
        public static ISessionFactory SessionFactory
        {
            get
            {
                if(sessionFactory == null)
                {
                    sessionFactory = Fluently.Configure()
                        .Database(PostgreSQLConfiguration.PostgreSQL82
                            .ConnectionString(c => c
                                  .FromConnectionStringWithKey("Postgres"))
                            .ShowSql())
                        .Mappings(x => x.AutoMappings.Add(ModelGenerator.Generate()))
                        .ExposeConfiguration(x => x.SetInterceptor(new SqlStatementInterceptor()))
                        .BuildSessionFactory();
                }
                
                return sessionFactory;
            }
        }
        
        public static ISession OpenSession() => SessionFactory.OpenSession();
    }
}
