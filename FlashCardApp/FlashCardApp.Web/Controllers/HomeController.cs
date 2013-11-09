using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlashCardApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string s = "";
            string ss = "";


            return ShowJacksonSets(s, ss);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowJacksonSets(string username, string password)
        {
            throw new NotImplementedException();
        }

        public ActionResult ShowJacksonSets()
        {

            CloudSetDataContext dataContext = new CloudSetDataContext();

            var user = dataContext.CloudUsers.First(x => x.UserEmail == "jacksonjhayes@gmail.com" && x.Password == "jh01123581321");

            List<CloudFlashCardSet> sets = dataContext.CloudFlashCardSets.Where(x => x.CloudUser == user).ToList();

            return View(sets);
        }

    }
}
