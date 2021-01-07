using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace ToDo
{
    public class ToDoDatabase
    {
        private SQLiteConnection database;
        //blocheaza db in timp ce se fac schimbari
        static object locker = new object();

        public ToDoDatabase()
        {
            //database = DependencyService.Get<ISQLite>.GetConnection();
            database = DependencyService.Get<ISQLite>.
            database.CreateTable<ToDoItem>();
        }

        public int SaveToDo(ToDoItem toDoItem)
        {
            lock (locker)
            {
                if (toDoItem.ID != 0)
                {
                    database.Update(toDoItem);
                    return toDoItem.ID;
                }
                else
                {
                    return database.Insert(toDoItem);
                }
            }
        }

        public IEnumerable<ToDoItem> GetToDos()
        {
            lock (locker)
            {
                return (from c in database.Table<ToDoItem>()
                        select c).ToList();
            }
        }

        public ToDoItem GetToDo(int id)
        {
            lock (locker)
            {
                return database.Table<ToDoItem>()
                    .Where(c => c.ID == id)
                    .FirstOrDefault();
            }
        }
    }
}
