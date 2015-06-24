/*
using System;
using System.Collections.Generic;

using FlashCardApp.Core.DAL;
using FlashCardApp.Core.Entities;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace FlashCardApp.Store.Repositories 
{
    public class WindowsChineseRepository : IChineseRepository
    {
        private readonly SQLiteConnection _connection;
        public WindowsChineseRepository()
        {
            SQLitePlatformWinRT platform = new SQLitePlatformWinRT();
            _connection = new SQLiteConnection(platform, "");
            _connection.CreateTable<Chinese>();
        }

        public Chinese GetById(int id)
        {
            var chinese = _connection.Get<Chinese>(id);
            return chinese;
        }

        public void Delete(Chinese item)
        {
            _connection.Delete(item);
        }

        public Chinese Update(Chinese item)
        {
            var i =_connection.Update(item);
            return _connection.Get<Chinese>(item.ID);
        }

        public Chinese Create(Chinese item)
        {
            var result = _connection.Insert(item);
            return _connection.Get<Chinese>(result);
        }

        public List<Chinese> Query(string query)
        {

        }

        public List<Chinese> GetMatching(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
*/
