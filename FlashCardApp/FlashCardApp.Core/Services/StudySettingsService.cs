using System;
using System.Linq;
using FlashCardApp.Core.DAL;
using FlashCardApp.Core.Entities;
using SQLite.Net;
using SQLite.Net.Interop;

namespace FlashCardApp.Core.Services
{
    public class StudySettingsService : IStudySettingsService
    {
      
        private int SelectedSetId; // make this a global property
        private readonly SQLiteConnection _connection;

        public StudySettingsService(ISQLiteConnection connection)
        {
            _connection = connection.connection;
          
            _connection.CreateTable<StudySettings>();

            if (!(DefaultSettingsExist()))
            {

                _connection.InsertOrReplace(new StudySettings()
                {
                    Id = 1,
                    CanShowCharacters = true,
                    FirstSide = "English",
                    MaxCardsInStudySet = 10000,
                    Name = "Default Settings",
                    SelectedSetId = 0,
                    ShowSimplified = true,
                    ShowDefinition = true,
                    ShowPinyin = true,
                    ShowTraditional = true
                });
            }
        }

        public StudySettings GetStudySettings()
        {

            var defaultSettings = _connection.Table<StudySettings>()
                .FirstOrDefault((x => x.Id == (1)));
           
                

            return defaultSettings;
        }

        public int GetSelectedSetId()
        {
            if (SelectedSetId == 0)
            {
                try
                {
                    var sets = _connection.Table<FlashCardSet>().ToList();
                    if (sets != null && sets.Any())
                    {
                        return sets.FirstOrDefault().ID;
                    }
                    else
                    {
                        _connection.Insert(new FlashCard()
                        {
                            Pinyin = "",
                            Definition = "",
                            Simplified = ""
                        });
                        int id = _connection.Insert(new FlashCardSet() { ID = 500, SetName = "Your First Set" });
                        return id;
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return SelectedSetId;
        }

        public void SetStudySettings(StudySettings settings)
        {
            settings.Id = 1;
            _connection.Update(settings);
        }

        public void SetSelectedSetId(int id)
        {
            
            SelectedSetId = id;
            //todo publish a message saying the selected set has updated?
        }

        private bool DefaultSettingsExist()
        {
            var settings = _connection.Table<StudySettings>().Where(x=>x.Id == 1);



            if (settings.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    public interface IStudySettingsService
    {
        StudySettings GetStudySettings();
        void SetStudySettings(StudySettings settings);
        void SetSelectedSetId(int id);
        int GetSelectedSetId();
    }
}
