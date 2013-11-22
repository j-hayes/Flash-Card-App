using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FlashCardApp.Core.Helpers;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace FlashCardApp.Core.Entities
{

   public class Chinese
    {
        public int ID { get; set; }
        public string Traditional { get; set; }
        public string Simplified { get; set; }
        public string Pinyin { get; set; } 
        public string SearchablePinyin { get; set; }
       
       [Ignore]
       public string AccentedPinyin {
           get
           {

               return PinyinFormatHelper.ConvertNumericalPinYinToAccented(Pinyin);
           }
           
       }


        
   }
  
}