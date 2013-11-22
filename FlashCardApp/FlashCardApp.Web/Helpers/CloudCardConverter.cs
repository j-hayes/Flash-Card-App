using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlashCardApp.Web.Models;
using FlashCardApp.Core.FlashCardService;

namespace FlashCardApp.Web.Helpers
{
    public class CloudCardConverter
    {
        
        public List<FlashCardSet> ConvertCloudSetToSet(List<CloudFlashCardSet> cloudSets)
        {
            var flashCardSets = new List<FlashCardSet>()
            {
                
            };

            foreach (CloudFlashCardSet cloudFlashCardSet in cloudSets)
            {
                var flashCards = new List<FlashCard>();
                foreach (var card in cloudFlashCardSet.CloudFlashCards)
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
                    FlashCards = flashCards,
                    ID= cloudFlashCardSet.ID
                    
                });
            }
            return flashCardSets;
        }

    }
}