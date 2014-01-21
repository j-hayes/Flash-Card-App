using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Sqlite;

namespace FlashCardApp.Core.Managers
{
    public interface IDatabaseConnectionFactory
    {
        ISQLiteConnection dbConnection { get; }
    }
}
