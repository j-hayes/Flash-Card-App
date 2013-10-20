using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using FlashCardApp.Core.Entities;

namespace FlashCardTestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetRandom();

        [OperationContract]
        List<FlashCardSet> GetSets();

        [OperationContract]
        int UploadSets(FlashCardSet set, List<FlashCard> cards);
    }
}