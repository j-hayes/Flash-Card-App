
using System;

namespace FlashCardCloudService.Entities
{
    public class ServiceFlashCard
    {
        public int ID { get; set; }
        public string Definition { get; set; }
        public string Pinyin { get; set; }
        public string Traditional { get; set; }
        public string Simplified { get; set; }
        public int SetID { get; set; }

        /// <summary>
        /// Creates and empty FlashCard object
        /// </summary>
        public ServiceFlashCard()
        {
        }
    }
}
 