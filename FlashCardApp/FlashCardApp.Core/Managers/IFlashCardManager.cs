using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.FlashCardService;

namespace FlashCardApp.Core.Managers
{
    public interface IFlashCardManager
    {

        int CreateCard(FlashCard flashCared);
        void EditCard(FlashCard flashCard);
        void DeleteCard(FlashCard flashCard);
        FlashCard GetCard(int Id);
        void AddCardtoSet(int CardID, int SetID);
      //  void AddCardtoSet(FlashCard flashCArd, int SetID); //may not be necessary

        void CreateSet(FlashCardSet set);
        void DeleteSet(FlashCardSet flashCardSet);
        void RenameSet(FlashCardSet flashCardSet);
        FlashCardSet GetSet(int id);

        List<FlashCardSet> GetSetList();

        List<FlashCard> GetCardsForSet(int p);

        List<FlashCard> GetAllCards(int p);

        void DeleteAllCardsAndSets();

        void ReplaceCardsWithCloudCards(List<FlashCardSet> sets);
        


        ServiceFlashCardSet[] GetCloudSetsForUpload();


        void MarkIncorrect(FlashCard setCard);
        void MarkCorrect(FlashCard setCard);
    }
}
