using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;

using FlashCardApp.Web.Helpers;
using FlashCardApp.Web.Models;

namespace FlashCardApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private CloudFlashCardDataContext flashCardDataContex;
        private CloudCardConverter cloudConverter;


        private CloudUser user;

        public HomeController()
        {
            flashCardDataContex = new CloudFlashCardDataContext();
            cloudConverter = new CloudCardConverter();
        } //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.UserIsLoggedIn = false;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            user = flashCardDataContex.CloudUsers.First(x => x.UserEmail == userName
                                                             & x.Password == password);
            if (user == null)
            {
                ViewBag.ErrorMessage = "No User Found Please Check Password";
            }
            Session.Add("UserID", user.Id);
            List<CloudFlashCardSet> cloudSets =
                flashCardDataContex.CloudFlashCardSets.Where(x => x.UserID == user.Id).ToList();


            List<FlashCardSet> sets = cloudConverter.ConvertCloudSetToSet(cloudSets);
                ViewBag.UserIsLoggedIn = true;
            return View(sets);
        }


        public ActionResult DisplaySet(int setID)
        {
            int userID = (int) Session["UserId"];
            var cloudset = flashCardDataContex.CloudFlashCardSets.Where(x => x.ID == setID
                                                                        & x.UserID == userID).ToList();
                //todo:make this more safe 
            var sets = cloudConverter.ConvertCloudSetToSet(cloudset);
         

          
            return View(sets[0]);
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return Redirect("Index");
        }

        public ActionResult StudySet(int setID)
        {
            int userID = (int)Session["UserId"];
            var cloudset = flashCardDataContex.CloudFlashCardSets.First(x => x.ID == setID
                                                                             & x.UserID == userID);
            Session["StudySetViewModel"] = new StudySetViewModel(cloudset);
            return View((StudySetViewModel)Session["StudySetViewModel"]);

        }

        public ActionResult FlipCard()
        {
            StudySetViewModel viewModel = (StudySetViewModel) Session["StudySetViewModel"];
            viewModel.FlipCard();
           return View("StudySet", viewModel);
        }

        public ActionResult NextCard()
        {
               StudySetViewModel viewModel = (StudySetViewModel) Session["StudySetViewModel"];
            viewModel.NextCard(1);
            return View("StudySet", viewModel);
        }

        public ActionResult PreviousCard()
        {

            StudySetViewModel viewModel = (StudySetViewModel)Session["StudySetViewModel"];
            viewModel.NextCard(-1);
            return View("StudySet", viewModel);
        }


    }
}
