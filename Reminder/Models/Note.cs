using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reminder.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}