using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.Plugins.Sqlite;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Core.Managers
{
    public class FlashCardManager : IFlashCardManager
    {
        private readonly ISQLiteConnection _connection;
        private readonly IMvxMessenger _messenger;

        public FlashCardManager(ISQLiteConnectionFactory factory, IMvxMessenger messenger)
        {
            _messenger = messenger;
            _connection = factory.Create("Dictionary.sqlite");
            _connection.CreateTable<FlashCardSet>();
            _connection.CreateTable<FlashCard>();
        }

        public int CreateCard(FlashCard flashCard)
        {
            _connection.Insert(flashCard);
            return flashCard.ID;
        }

        public void EditCard(FlashCard flashCard)
        {
            _connection.Update(flashCard);
        }

        public void DeleteCard(FlashCard flashCard)
        {
            _connection.Delete(flashCard);
            _messenger.Publish(new FlashCardSetListChangedMessage(this));
        }

        public FlashCard GetCard(int Id)
        {
            return _connection.Table<FlashCard>().Where(x => x.ID == Id).FirstOrDefault();
        }

        public void AddCardtoSet(int CardID, int SetID)
        {
            string query = "INSERT INTO CardInSet ('SetID','CardID') VALUES (?,?)";//todo:create query that adds 
            _connection.Execute(query, SetID,CardID);
            //todo error messaging: don't allow multiple I think.
        }

    

        public void CreateSet(FlashCardSet set)
        {
            _connection.Insert(set);
        }

        public void CreateSet(string name)
        {
            _connection.Insert(new FlashCardSet(name));
        }

        public void DeleteSet(FlashCardSet flashCardSet)
        {
            _connection.Delete<FlashCardSet>(flashCardSet);
            //todo:add messaging to alert that a set no longer exists
        }

        public void RenameSet(FlashCardSet flashCardSet)
        {
            _connection.Update(flashCardSet);
        }

        public FlashCardSet GetSet(int id)
        {
           return _connection.Get<FlashCardSet>(id);
        }


        public List<FlashCardSet> GetSetList()
        {
            return _connection.Table<FlashCardSet>().ToList();
        }

        public List<FlashCard> GetCardsForSet(int p)
        {
            List<FlashCard> cardsInSet = _connection.Query<FlashCard>("SELECT DISTINCT * FROM FlashCard WHERE ID IN (Select CardID from CardInSet Where SetID = ?)", p).ToList();
            return cardsInSet;

        }


        public List<FlashCard> GetAllCards(int p)
        {
            string query = "select * from CardInSet";// "SELECT DISTINCT * FROM FlashCard WHERE ID IN (Select CardID from CardInSet Where SetID = ?";
            return
                _connection.Query<FlashCard>(query).ToList();
        }
    }
}