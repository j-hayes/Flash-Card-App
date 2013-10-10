using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlashCardApp.Core.Entities;
using FlashCardApp.Core.ViewModels.Dictionary;

namespace FlashCardApp.Core.Managers
{
    using System.Collections.Generic;

    namespace FlashCardApp.Core.Services
    {
        public interface IEnglishManager
        {
            List<English> EnglishesMatching(string filter);
            
            void Insert(English english);
            void Update(English english);
            void Delete(English English);

            List<English> GetEnglishesByChineseIds(List<int> ids);
        }
    }
}
