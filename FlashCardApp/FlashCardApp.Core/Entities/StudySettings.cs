using SQLite.Net.Attributes;

namespace FlashCardApp.Core.Entities
{
    public class StudySettings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [Ignore]
        public int SelectedSetId { get; set; }
        public int MaxCardsInStudySet { get; set; }
        public bool CanShowCharacters { get; set; }
        public string FirstSide { get; set; }
        public bool ShowPinyin { get; set; }
        public bool ShowTraditional { get; set; }
        public bool ShowSimplified { get; set; }
        public bool ShowDefinition { get; set; }



    }
}

