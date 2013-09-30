using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace FlashCardApp.Core.Managers
{
    internal class FlashCardSetListChangedMessage : MvxMessage
    {
        public FlashCardSetListChangedMessage(object sender) : base(sender)
        {
        }
    }
}
