using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cirrious.MvvmCross.Plugins.Sqlite;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.Managers.FlashCardApp.Core.Services;
using FlashCardApp.Core.ViewModels.Dictionary;


namespace FlashCardApp.Core.Managers
{
    class EnglishManager : IEnglishManager
    {
        private readonly ISQLiteConnection _connection;

        public EnglishManager(ISQLiteConnectionFactory factory)
        {
            _connection = factory.Create("Dictionary.sqlite");
            
           
        }

        public List<English> EnglishesMatching(string filter)
        {
            var queryString = string.Format("Select * from English WHERE definition match '{0}' ORDER BY definitionLength asc limit 50", filter);
            List<English> englishResutlsList = _connection.Query<English>(queryString).ToList();
            return englishResutlsList;
        }

        public void Insert(English English)
        {
            _connection.Insert(English);
        }

        public void Update(English English)
        {
            _connection.Update(English);
        }

        public void Delete(English English)
        {
            _connection.Delete(English);
        }



        public List<English> GetEnglishesByChineseIds(List<int> chineseIds)
        {

            string query = "select * from English where ChineseID in";
            string chineseIdsForQuery = " (";

            foreach (int id in chineseIds)
            {
                chineseIdsForQuery += string.Format("{0},", id);
            }
            chineseIdsForQuery = chineseIdsForQuery.Remove(chineseIdsForQuery.Length - 1) + ")";

            query = query + chineseIdsForQuery;

            List<English> results = _connection.Query<English>(query).ToList();
            return results;
        }


    }
}