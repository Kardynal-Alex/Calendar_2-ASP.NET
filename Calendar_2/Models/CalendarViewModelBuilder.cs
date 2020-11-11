using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar_2.Models
{
    public class CalendarViewModelBuilder
    {

        public CalendarViewModel GetCurrentData(int count)
        {
            DateTime[,] days = new DateTime[6, 7];
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + count, 1);
            int offset = (int)date.DayOfWeek;

            if (offset == 0)
                offset = 7;

            offset--;
            date = date.AddDays(offset * -1);

            for (int i = 0; i != 6; i++)
            {
                for (int j = 0; j != 7; j++)
                {
                    days[i, j] = date;
                    date = date.AddDays(1);
                }
            }
            return new CalendarViewModel()
            {
                Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + count, 1),
                Days = days
            };
        }
      
    }
}
