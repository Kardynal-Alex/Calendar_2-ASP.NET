using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar_2.Models
{
    public class CalendarViewModel
    {
        public DateTime Date { get; set; }
        public DateTime[,] Days { get; set; }
    }
}
