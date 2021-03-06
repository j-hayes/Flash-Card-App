﻿using System.Collections.Generic;
using System.ServiceModel;
using FlashCardCloudService.Entities;

namespace FlashCardCloudService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFlashCardService

    {

        [OperationContract]
        bool CreateUser(string emailAddress, string password);

        [OperationContract]
        bool VerifyUser(string emailAddress, string password);

        [OperationContract]
        List<ServiceFlashCardSet> GetSets(string userEmailAdress, string password);

        [OperationContract]
        bool UploadSets(List<ServiceFlashCardSet> serviceSets, string userEmailAddress, string password);

        [OperationContract]
        bool DeleteUser(string emailAddress, string password);


    }
}