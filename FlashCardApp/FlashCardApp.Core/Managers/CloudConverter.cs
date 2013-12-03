using System.Collections.Generic;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.FlashCardService;

namespace FlashCardApp.Core.Managers
{
    public class ServiceCardConverter : IServiceCardConverter
    {
        public List<ServiceFlashCardSet> ConvertSetToCloudSet(List<FlashCardSet> flashCardSets)
        {
            List<ServiceFlashCardSet> cloudFlashCardSets = new List<ServiceFlashCardSet>();
            foreach (FlashCardSet flashCardSet in flashCardSets)
            {
                List<ServiceFlashCard> ServiceFlashCards = new List<ServiceFlashCard>();
                foreach (FlashCard card in flashCardSet.FlashCards)
                {
                    ServiceFlashCards.Add(new ServiceFlashCard()
                    {
                        Traditional = card.Traditional,
                        Simplified = card.Simplified,
                        Pinyin = card.Pinyin,
                        Definition = card.Definition,
                        ID = card.ID
                       
                    });
                }
                cloudFlashCardSets.Add(new ServiceFlashCardSet()
                {
                    SetName = flashCardSet.SetName,
                    ID = flashCardSet.ID,
                    FlashCards = ServiceFlashCards.ToArray()
                });





            }
            return cloudFlashCardSets;
        }

        public List<FlashCardSet> ConvertCloudSetToSet(List<ServiceFlashCardSet> cloudSets)
        {
            var flashCardSets = new List<FlashCardSet>();

            foreach (ServiceFlashCardSet cloudFlashCardSet in cloudSets)
            {
                var flashCards = new List<FlashCard>();
                foreach (var card in cloudFlashCardSet.FlashCards)
                {
                    flashCards.Add(new FlashCard()
                    {
                        Traditional = card.Traditional,
                        Simplified = card.Simplified,
                        Pinyin = card.Pinyin,
                        Definition = card.Definition,
                    //    SetID = card.SetId
                    });
                }
                flashCardSets.Add(new FlashCardSet()
                {
                    SetName = cloudFlashCardSet.SetName,
                    FlashCards = flashCards
                });
            }
            return flashCardSets;
        }

        
    }
}