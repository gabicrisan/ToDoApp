using System;
using WebKit;
using System.IO;
using ToDo.iOS;

[assembly:Xamarin.Forms.Dependency(typeof(SQLite_iOS))]
namespace ToDo.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        public SQLite.SQLiteConnection GetConnection()
        {
            var path = "/Users/gabi/Data/ToDo.db";
            File.Open(path, FileMode.OpenOrCreate);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
