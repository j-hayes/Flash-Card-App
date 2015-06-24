using System;
using System.Collections.Generic;
using FlashCardApp.Core.DAL;
using SQLite.Net;
using System.Linq;
using FlashCardApp.Core.Entities;
using SQLite.Net.Interop;

namespace FlashCardApp.Core.Managers
{
    public class ChineseManager : IChineseManager
    {
        private readonly SQLiteConnection _connection;
      

        public ChineseManager(ISQLiteConnection connection)
        {
            _connection = connection.connection;
        }

        public List<Chinese> ChinesesMatching(string searchFilter)
        {

                List<Chinese> matchingChinese = _connection.Query<Chinese>(
                    "Select * from Chinese WHERE Simplified match ? limit 100", searchFilter);
                return matchingChinese;
            
            
        }

        public List<Chinese> ChinesesRelated(string searchFilter)
        {
            throw new NotImplementedException("");
            //todo: This should get more results than the match query
        }

        public List<Chinese> PinyinMatching(string searchTerm)
        {
            List<Chinese> matchingChinese =
                _connection.Query<Chinese>("Select * from Chinese WHERE SearchablePinyin match ? Limit 100", searchTerm);


            return matchingChinese;
        }

        public void Insert(Chinese chinese)
        {
            _connection.Insert(chinese);
        }

        public void Update(Chinese chinese)
        {
            _connection.Update(chinese);
        }

        public void Delete(Chinese chinese)
        {
            _connection.Delete(chinese);
        }

        public int Count
        {
            get
            {
                return _connection.Table<Chinese>().Count();
            }
        }


        public Chinese GetById(int id)
        {
            return _connection.Table<Chinese>()
                .Where((x => x.ID == (id)))
                .FirstOrDefault();
        }

        public List<Chinese> GetById(List<int> ids)
        {
            string query = "select * from Chinese where ID in";
            string chineseIntsForQuery = " (";

            foreach (int id in ids)
            {
                chineseIntsForQuery += string.Format("{0},", id);
            }
            chineseIntsForQuery = chineseIntsForQuery.Remove(chineseIntsForQuery.Length - 1) + ")";

            query = query + chineseIntsForQuery;

            List<Chinese> results = _connection.Query<Chinese>(query).ToList();
            return results;
        }

    }
}