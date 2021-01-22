using System;

namespace Calendar_2.Models
{
    public class CalendarViewModel
    {
        public DateTime Date { get; set; }
        public DateTime[,] Days { get; set; }
    }
}
