using System.Collections.Generic;

namespace FlashCardCloudService.Entities
{
    public class ServiceFlashCardSet
    {
        
        public int ID { get; set; }
        public string SetName { get; set; }

        public List<ServiceFlashCard> FlashCards; 

        /// <summary>
        /// Constructs a new Empty FlashCardSet Object
        /// </summary>
        public ServiceFlashCardSet()
        {
            FlashCards = new List<ServiceFlashCard>();
        }
        public ServiceFlashCardSet(string setName)
        {
            this.SetName = setName;
        }

    }
}