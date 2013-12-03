using System;
using System.Linq;
using System.Web;
using FlashCardApp.Core.Helpers;

namespace FlashCardApp.Web.Models
{
    public class FlashCard
    {
        public int ID { get; set; }

        public int SetID { get; set; }
        public int setIDs { get; set; }
        public string Definition { get; set; }
        public string Pinyin { get; set; }
        public string Traditional { get; set; }
        public string Simplified { get; set; }

        public string AccentedPinyin
        {
            get
            {

                return PinyinFormatHelper.ConvertNumericalPinYinToAccented(Pinyin);
            }
        }

        ///statistics 
        public int TotalTries { get; set; }

        public int CorrectAnswers { get; set; }
        public int Score { get; set; }
    }
}