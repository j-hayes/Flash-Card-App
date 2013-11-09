using System;
using System.Collections.Generic;
using System.Configuration;

using System.Linq;
using System.ServiceModel;
using System.Web.Security;
using FlashCardTestService.Entities;

namespace FlashCardTestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FlashCardService : IFlashCardService
    {
        private readonly CloudFlashCardDataContext _dbContext = new CloudFlashCardDataContext(ConfigurationManager
            .ConnectionStrings["FlashCardDbConnectionString"].ConnectionString);


        public bool CreateUser(string emailAddress, string password)
        {
            if (_dbContext.CloudUsers.FirstOrDefault(x => x.UserEmail == emailAddress) == null)
            {
                _dbContext.CloudUsers.InsertOnSubmit(new CloudUser()
                {
                    Password = password,
                    UserEmail = emailAddress
                });

                _dbContext.SubmitChanges();
                return true;
            }
            else
            {
                throw new FaultException("The Email Address entered already is in use");
            }

        }

        public List<ServiceFlashCardSet> GetSets(string userEmailAdress, string password)
        {

            CloudUser user = VerifyUserAndGetUser(userEmailAdress, password);

            var s  = _dbContext.CloudFlashCardSets.Where(x => x.UserID == user.Id).ToList();

            List<ServiceFlashCardSet> sets = ConvertToServiceCards(s);
            return sets;
        }

        private List<ServiceFlashCardSet> ConvertToServiceCards(List<CloudFlashCardSet> cloudFlashCardSets)
        {
            List<ServiceFlashCardSet> sets = new List<ServiceFlashCardSet>();
            foreach (var cloudFlashCardSet in cloudFlashCardSets)
            {
                var set = new ServiceFlashCardSet()
                {
                    SetName = cloudFlashCardSet.SetName,
                    ID = cloudFlashCardSet.ID
                };
                foreach (var flashCard in cloudFlashCardSet.CloudFlashCards)
                {
                    var flashcard = new ServiceFlashCard()
                    {
                        Traditional = flashCard.Traditional,
                        Simplified = flashCard.Simplified,
                        Definition = flashCard.Definition,
                        Pinyin = flashCard.Pinyin,
                        ID = flashCard.ID
                    };
                    set.FlashCards.Add(flashcard);
                }
                sets.Add(set);
            }
            return sets;
        }

        public bool UploadSets(List<ServiceFlashCardSet> serviceSets, string userEmailAddress, string password)
        {
           
            CloudUser user = VerifyUserAndGetUser(userEmailAddress, password);
            List<CloudFlashCardSet> sets = ConverToCloudSet(serviceSets, user);

            DeleteUserCards(user.Id);

            _dbContext.CloudFlashCardSets.InsertAllOnSubmit(sets);
            _dbContext.SubmitChanges();

            return true;
        }

        private List<CloudFlashCardSet> ConverToCloudSet(List<ServiceFlashCardSet> serviceSets, CloudUser user)
        {
            List<CloudFlashCardSet> sets = new List<CloudFlashCardSet>();
            foreach (var serviceFlashCardSet in serviceSets)
            {
                CloudFlashCardSet set = new CloudFlashCardSet()
                {
                    SetName =  serviceFlashCardSet.SetName, 
                    CloudUser = user
                };
                foreach (var serviceCard in serviceFlashCardSet.FlashCards)
                {
                    CloudFlashCard card = new CloudFlashCard()
                    {
                        Traditional = serviceCard.Traditional,
                        Simplified = serviceCard.Simplified,
                        Pinyin = serviceCard.Pinyin,
                        CloudFlashCardSet = set,
                        Definition = serviceCard.Definition,
                        ID = serviceCard.ID

                    };
                    set.CloudFlashCards.Add(card);
                }
                sets.Add(set);
            }
            return sets;
        }

        private CloudUser VerifyUserAndGetUser(string userEmailAdress, string password)
        {

            CloudUser user = _dbContext.CloudUsers.First(x => x.UserEmail == userEmailAdress && x.Password == password);
            if (user != null)
            {
                return user;
            }
            throw new MembershipPasswordException("There is no user with this Email address and Password Combination");
        }

     
        private void DeleteUserCards(int userId)
        {
            _dbContext.CloudFlashCards.DeleteAllOnSubmit(
            _dbContext.CloudFlashCards.Where(x => x.OwnerID == userId).ToList());
            
            
            _dbContext.SubmitChanges();
            _dbContext.CloudFlashCardSets.DeleteAllOnSubmit(
            _dbContext.CloudFlashCardSets.Where(x => x.UserID == userId).ToList());


            _dbContext.SubmitChanges();
        }
    }
}