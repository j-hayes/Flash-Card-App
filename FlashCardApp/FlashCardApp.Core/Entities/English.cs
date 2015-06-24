using SQLite.Net.Attributes;

namespace FlashCardApp.Core.Entities
{
   public class English
    {
        public string Definition { get; set; }
        public int ChineseId { get; set; }
        public int DefinitionLength { get; set; }
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
   }
}
