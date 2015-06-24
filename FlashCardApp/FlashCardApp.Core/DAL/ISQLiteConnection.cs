using SQLite.Net;

namespace FlashCardApp.Core.DAL
{
    public interface ISQLiteConnection
    {
        SQLiteConnection connection { get; }
    }
}