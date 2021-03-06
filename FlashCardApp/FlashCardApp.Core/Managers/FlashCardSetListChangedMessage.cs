﻿using Cirrious.MvvmCross.Plugins.Messenger;

namespace FlashCardApp.Core.Managers
{
    internal class FlashCardSetListChangedMessage : MvxMessage
    {
        public FlashCardSetListChangedMessage(object sender) : base(sender)
        {

        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
