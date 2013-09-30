using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace FlashCardApp.Core.Entities
{
    public class FlashCardSet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Constructs a new Empty FlashCardSet Object
        /// </summary>
        public FlashCardSet()
        {
        }
        public FlashCardSet(string Name)
        {
            this.Name = Name;
        }
    }
}