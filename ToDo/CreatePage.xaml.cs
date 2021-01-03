using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToDo
{
    public partial class CreatePage : ContentPage
    {
        public List<ToDoItem> toDoItems;

        public CreatePage()
        {
            toDoItems = new List<ToDoItem>();
            InitializeComponent();
        }
        public void OnSave(object o, EventArgs e)
        {
            toDoItems.Add(
                new ToDoItem(
                    ToDoEntry.Text,
                    Priority.Text,
                    SetDueDate(
                        Date.Date,
                        Time.Time.Hours,
                        Time.Time.Minutes,
                        Time.Time.Seconds),
                    false
                    )
                );
            Clear();
        }

        private DateTime SetDueDate(DateTime date, int hour, int minute, int second)
        {
            DateTime retVal = new DateTime(
                date.Year,
                date.Month,
                date.Day,
                hour,
                minute,
                second
                );
            return retVal;
        }

        private void Clear()
        {
            ToDoEntry.Text = Priority.Text = String.Empty;
            Date.Date = DateTime.Now;
            Time.Time = new TimeSpan(
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second
                );
        }

        public void OnCancel(object o, EventArgs e)
        {

        }
        public void OnReview(object o, EventArgs e)
        {
            var tempList = toDoItems;
            Clear();
        }
    }
}
