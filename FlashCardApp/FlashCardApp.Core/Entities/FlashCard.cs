
using System;
using FlashCardApp.Core.Helpers;
using SQLite.Net.Attributes;

namespace FlashCardApp.Core.Entities
{
    public class FlashCard
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int SetID { get; set; }
        public int setIDs { get; set; }
        public string Definition { get; set; }
        public string Pinyin { get; set; }
        public string Traditional { get; set; }
        public string Simplified { get; set; }


        [Ignore]
        public string AccentedPinyin
        {
            get
            {

                return PinyinFormatHelper.ConvertNumericalPinYinToAccented(Pinyin);
            }
        }

        ///statistics 
        public int TotalTries { get; set; }
        public int CorrectAnswers { get; set; }
        public int Score { get; set; }

        
        /// <summary>
        /// Creates and empty FlashCard object
        /// </summary>
        public FlashCard()
        {
        }

        /// <summary>
        /// Adds the FlashCard to the Database
        /// </summary>
        public void AddToDatabase()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the FlashCard from the Database. Card object is retained in tact
        /// </summary>

        public void Delete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the card with the matching primary key in the database to the current state of the FlashCard
        /// </summary>
        public void Update()
        {
            throw new NotImplementedException();

            /// <summary>
            /// Todo: searchForCards
            /// </summary>
            /// <param name="searchString"></param>
            /// <returns></returns>
            // public  Task<List<FlashCard>> searchCards(string searchString) { }

        }
    }
}
 