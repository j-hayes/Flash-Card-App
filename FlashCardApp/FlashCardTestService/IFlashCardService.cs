using System.Collections.Generic;
using System.ServiceModel;
using FlashCardTestService.Entities;

namespace FlashCardTestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFlashCardService

    {

        [OperationContract]
        bool CreateUser(string emailAddress, string password);

        [OperationContract]
        List<ServiceFlashCardSet> GetSets(string userEmailAdress, string password);

        [OperationContract]
        bool UploadSets(List<ServiceFlashCardSet> serviceSets, string userEmailAddress, string password);


    }
}