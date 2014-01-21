using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace FlashCardApp.Core.Messages
{
    internal class UserLoggedInMessage : MvxMessage
    {
        public UserLoggedInMessage(object sender) : base(sender)
        {
        }
    }
}
