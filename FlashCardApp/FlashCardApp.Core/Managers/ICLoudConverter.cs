using System.Collections.Generic;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.FlashCardService;

namespace FlashCardApp.Core.Managers
{
    public interface IServiceCardConverter
    {
        List<ServiceFlashCardSet> ConvertSetToCloudSet(List<FlashCardSet> flashCardSets);
    }
}