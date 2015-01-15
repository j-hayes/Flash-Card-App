﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Messenger;
using FlashCardApp.Core.Entities;

namespace FlashCardApp.Core.Messages
{
    public class SelectedSetChangedMessage : MvxMessage
    {
        
        public SelectedSetChangedMessage(object sender) : base(sender)
        {
        }

        public FlashCardSet SelctedSet { get; set; }
    }
}