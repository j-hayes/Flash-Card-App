using FlashCardApp.Core.Helpers;
using SQLite.Net.Attributes;

namespace FlashCardApp.Core.Entities
{

   public class Chinese
    {
		[PrimaryKey, AutoIncrement]
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