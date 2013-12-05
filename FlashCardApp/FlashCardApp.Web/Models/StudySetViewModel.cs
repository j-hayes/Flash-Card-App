using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashCardApp.Web.Models
{
    public class StudySetViewModel
    {
        private int _currentIndex;

        public CloudFlashCardSet Set { get; set; }

        public bool ShowEnglish { get; set; }

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set
            {
                _currentIndex = value;
                CurrentCard = Set.CloudFlashCards[_currentIndex];
            }
        }

        public CloudFlashCard CurrentCard { get; set; }

        public StudySetViewModel(CloudFlashCardSet set)
        {
            Set = set;
            CurrentIndex = 0;
            CurrentCard = set.CloudFlashCards[CurrentIndex];
            ShowEnglish = false;

        }

        public void FlipCard()
        {
            ShowEnglish = !ShowEnglish;
        }

        public void NextCard(int direction)
        {
            if (direction > 0)
            {
                if (CurrentIndex < Set.CloudFlashCards.Count - 1)
                {
                    CurrentIndex ++;
                }
            }
            else
            {
                if (CurrentIndex > 0)
                {
                    CurrentIndex--;
                }
            }
            ShowEnglish = false;
        }
    }
}