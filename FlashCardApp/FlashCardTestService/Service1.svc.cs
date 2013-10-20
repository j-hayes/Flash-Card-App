using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FlashCardApp.Core.Entities;

namespace FlashCardTestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public string GetRandom()
        {
            Random r = new Random();
            return r.Next().ToString();
        }

        public List<FlashCardSet> GetSets()
        {
            List<FlashCardSet> sets = new List<FlashCardSet>();

            for (int i = 0; i < 10; i++)
            {
                sets.Add(new FlashCardSet(i.ToString()));
            }
            return sets;
        }

        public int UploadSets(FlashCardSet set, List<FlashCard> cards)
        {
            FakeBlogDataContext connContext =
                new FakeBlogDataContext(ConfigurationManager.ConnectionStrings["BlogDbConnectionString"].ConnectionString);



            var results = from b in connContext.BlogPosts
                select new {ID = b.ID, blah = b.PostedOn, content = b.Content};

            var resultslist = results.ToList();
            return resultslist[1].content.Length;



        }
    }

}