using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Core.Services
{
    public class StudySettingsService : IStudySettingsService
    {
        private ISQLiteConnection _connection;
        private ISQLiteConnectionFactory _factory;
        private int SelectedSetId; // make this a global property

        public StudySettingsService(ISQLiteConnectionFactory factory)
        {
            _factory = factory;

            _connection = factory.Create("Dictionary.sqlite");
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
                .Where((x => x.Id == (1)))
                .FirstOrDefault();

            return defaultSettings;
        }

        public int GetSelectedSetId()
        {
            if (SelectedSetId == 0)
            {
                try
                {
                    return _connection.Table<FlashCardSet>().First().ID;
                }
                catch (Exception e)
                {
                    int id =_connection.Insert(new FlashCardSet("First Set"));
                    return id;
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
