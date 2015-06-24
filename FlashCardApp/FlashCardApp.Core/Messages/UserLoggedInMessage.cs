using Cirrious.MvvmCross.Plugins.Messenger;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Core.Messages
{
    internal class UserLoggedInMessage : MvxMessage
    {
        public UserLoggedInMessage(object sender) : base(sender)
        {
        }
        public FlashCardSet SelctedSet { get; set; }
    }
}
