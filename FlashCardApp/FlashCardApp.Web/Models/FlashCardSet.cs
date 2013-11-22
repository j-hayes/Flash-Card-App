using System.Collections.Generic;

namespace FlashCardApp.Web.Models
{
    public class FlashCardSet
    {
        public int ID { get; set; }
        public string SetName { get; set; }

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