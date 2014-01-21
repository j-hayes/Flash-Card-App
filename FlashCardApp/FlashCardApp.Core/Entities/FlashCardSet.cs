using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace FlashCardApp.Core.Entities
{
    public class FlashCardSet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string SetName { get; set; }

        [Ignore]
        public List<FlashCard> FlashCards { get; set; } 

        /// <summary>
        /// Constructs a new Empty FlashCardSet Object
        /// </summary>
        public FlashCardSet()
        {
        }
        public FlashCardSet(string setName)
        {
            this.SetName = setName;
        }

    }
}