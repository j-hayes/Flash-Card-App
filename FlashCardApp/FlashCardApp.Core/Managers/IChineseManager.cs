using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Core.Managers
{
    public interface IChineseManager
    {
        List<Chinese> ChinesesMatching(string searchFilter);
        List<Chinese> ChinesesRelated(string searchFilter);
        List<Chinese> PinyinMatching(string searchTerm);


        void Insert(Chinese chinese);
        void Update(Chinese chinese);
        void Delete(Chinese chinese);

        Chinese GetById(int p);
        List<Chinese> GetById(List<int> ids);

    }
}
