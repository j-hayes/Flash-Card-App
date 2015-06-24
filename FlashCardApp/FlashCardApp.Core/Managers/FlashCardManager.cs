using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Plugins.Messenger;
using FlashCardApp.Core.DAL;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.FlashCardService;
using SQLite.Net;
using SQLite.Net.Interop;

namespace FlashCardApp.Core.Managers
{
    public class FlashCardManager : IFlashCardManager
    {
        private readonly SQLiteConnection _connection;
        private readonly IMvxMessenger _messenger;
        public FlashCardServiceClient CloudClient;
    

        public FlashCardManager(ISQLiteConnection connection, IMvxMessenger messenger)
        {

            _messenger = messenger;
            CloudClient = new FlashCardServiceClient();

            _connection = connection.connection;
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
            return _connection.Get<FlashCard>(Id);
        }

        public void AddCardtoSet(int CardID, int SetID)
        {
            string query = "INSERT INTO CardInSet ('SetID','CardID') VALUES (?,?)"; //todo:create query that adds 
            _connection.Execute(query, SetID, CardID);
            //todo error messaging: don't allow multiple I think.
        }

        public void CreateSet(FlashCardSet set)
        {

            _connection.Insert(set);
            _messenger.Publish(new FlashCardSetListChangedMessage(this));
        }

        public void CreateSet(string name)
        {
            _connection.Insert(new FlashCardSet(name));
        }

        public void DeleteSet(FlashCardSet flashCardSet)
        {

            _connection.Delete<FlashCardSet>(flashCardSet.ID);
            string query = "Delete from CardInSet where SetID == ?"; //todo:create query that adds //and make these tables cascade foreign keys
            _connection.Execute(query, flashCardSet.ID);
            _messenger.Publish(new FlashCardSetListChangedMessage(this));
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
            try
            {
                List<FlashCard> cardsInSet =
                    _connection.Query<FlashCard>(
                        "SELECT DISTINCT * FROM FlashCard WHERE ID IN (Select CardID from CardInSet Where SetID = ?)", p)
                        .ToList();
                return cardsInSet;
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public List<FlashCard> GetAllCards(int p)
        {
            string query = "select * from CardInSet";
                // "SELECT DISTINCT * FROM FlashCard WHERE ID IN (Select CardID from CardInSet Where SetID = ?";
            return
                _connection.Query<FlashCard>(query).ToList();
        }

        public void DeleteAllCardsAndSets()
        {
            string query = "delete from CardInSet; delete from sqlite_sequence where name = 'CardInSet';";
            _connection.Execute(query);
            string query2 = "delete from FlashCard; delete from sqlite_sequence where name = 'FlashCard';";
            _connection.Execute(query2);
            string query3 = "delete from FlashCardSet; delete from sqlite_sequence where name = 'FlashCardSet';";
            _connection.Execute(query3);
        }

        public void ReplaceCardsWithCloudCards(List<FlashCardSet> sets)
        {
            DeleteAllCardsAndSets();
            foreach (var flashCardSet in sets)
            {
                CreateSet(flashCardSet);
                foreach (var card in flashCardSet.FlashCards)
                {
                    CreateCard(card);
                    AddCardtoSet(card.ID, flashCardSet.ID);
                }
            }
        }


        public ServiceFlashCardSet[] GetCloudSetsForUpload()
        {
            List<FlashCardSet> flashCardSets = GetSetList();
            foreach (var flashCardSet in flashCardSets)
            {
                flashCardSet.FlashCards = GetCardsForSet(flashCardSet.ID);
            }

            var cloudConverter = new ServiceCardConverter();
            List<ServiceFlashCardSet> cloudset = cloudConverter.ConvertSetToCloudSet(flashCardSets);

            return cloudset.ToArray();
        }

        public void MarkIncorrect(FlashCard setCard)
        {
            setCard.TotalTries++;

            if (setCard.Score > 10)
            {
                setCard.Score -= 10;
            }
            else
            {
                setCard.Score = 0;
            }

            _connection.Update(setCard);
        }

        public void MarkCorrect(FlashCard setCard)
        {
            setCard.TotalTries++;
            setCard.CorrectAnswers++;
            if (setCard.Score < 100)
            {
                setCard.Score += 10;

            }
            else
            {
                setCard.Score = 100;
            }
            _connection.Update(setCard);
            
        }
    }
}