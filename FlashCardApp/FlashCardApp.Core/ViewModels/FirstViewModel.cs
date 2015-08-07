using Cirrious.MvvmCross.ViewModels;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        public void Init()
        {
            FlashCard flashCard1 = new FlashCard()
            {
               Definition = "Hello",
               Pinyin = "nǐ hǎo",
               Traditional = "你好",
               Simplified = "你好"
            };
            FlashCard flashCard2 = new FlashCard()
            {
                Definition = "car",
                Pinyin = "Qìchē",
               Traditional = "汽车",
               Simplified = "汽车"
            }; 
            FlashCard flashCard3 = new FlashCard()
            {
               Definition = "Book",
               Pinyin = "Shū",
               Traditional = "书",
               Simplified = "书"
            }; 
            FlashCard flashCard4 = new FlashCard()
            {
                Definition = "Computer",
                Pinyin = "Jìsuànjī",
                Traditional = "计算机",
                Simplified = "计算机"
            };
            FlashCard flashCard5 = new FlashCard()
            {
               Definition = "Programmer",
               Pinyin = "Ni3Hao3",
               Traditional = "程序员",
               Simplified = "程序员"
            };   FlashCard flashCard6 = new FlashCard()
            {
               Definition = "Ten",
               Pinyin = "Shí",
               Traditional = "十",
               Simplified = "十"
            };
            FlashCard flashCard7 = new FlashCard()
            {
                Definition = "Ten",
                Pinyin = "Wēiruǎn",
                Traditional = "微软",
                Simplified = "微软"
            };
        }
    }
}
