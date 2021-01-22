using System;

namespace Calendar_2.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
    }
}
