using System;

namespace Calendar_2.Models
{
    public class CalendarViewModelBuilder
    {
        public CalendarViewModel GetCurrentData(int count)
        {
            DateTime[,] days = new DateTime[6, 7];
            DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime date = d;
            date = date.Date.AddMonths(count);
            d = d.Date.AddMonths(count);

            int offset = (int)d.DayOfWeek;

            if (offset == 0)
                offset = 7;

            offset--;
            d = d.AddDays(offset * -1);

            for (int i = 0; i != 6; i++)
            {
                for (int j = 0; j != 7; j++)
                {
                    days[i, j] = d;
                    d = d.AddDays(1);
                }
            }
            return new CalendarViewModel()
            {
                Date = date,
                Days = days
            };
        }
        /*
        public static int year { get; set; } = 0;
        public static int month { get; set; } = 0;
        public static int temp { get; set; } = 0; 
        public CalendarViewModel GetCurrentData(int count)
        {
            DateTime[,] days = new DateTime[6, 7];
            DateTime d = new DateTime();
            DateTime date = new DateTime();

            int x = DateTime.Now.Month + count;
            if (x > 12 && (x - 1) % 12 == 0 && temp < x)  //вправо 12->1(> поточного року)
            {
                ++year; month = 1;
                date = new DateTime(DateTime.Now.Year + year, month, 1);
                d = date;
            }
            else
            if (x % 12 == 0 && x > 12 && temp > x)  //вліво 1<-12 (> поточного року)
            {
                --year; month = 12;
                date = new DateTime(DateTime.Now.Year + year, month, 1);
                d = date;
            }
            else
            if (x >= 13) //(> поточного року)
            {
                if (temp > x) { --month; }
                else if (temp < x) { ++month; }
                date = new DateTime(DateTime.Now.Year + year, month, 1);
                d = date;
            }
            else
            if (x <= 0 && x % (-12) == 0 && temp > x)  //вліво 12<-1(< поточного року)
            {
                --year; month = 12;
                date = new DateTime(DateTime.Now.Year + year, month, 1);
                d = date;
            }
            else
            if (x <= 0 && (x - 1) % (-12) == 0 && temp < x) //вправо 1->12(< поточного року)
            {
                ++year; month = 1;
                date = new DateTime(DateTime.Now.Year + year, month, 1);
                d = date;
            }
            else
            if (x <= 0) //(< поточного року)
            {
                if (temp > x) { --month; }
                else if (temp < x) { ++month; }
                date = new DateTime(DateTime.Now.Year + year, month, 1);
                d = date;
            } 
            else
            if (x >= 1 && x <= 12) 
            {
                if (x == 12 || x == 1) { year = 0; }
                
                date = new DateTime(DateTime.Now.Year, DateTime.Now.Month + count, 1);
                d = date;
            }
            temp = x;

            int offset = (int)d.DayOfWeek;

            if (offset == 0)
                offset = 7;

            offset--;
            d = d.AddDays(offset * -1);

            for (int i = 0; i != 6; i++) 
            {
                for (int j = 0; j != 7; j++)
                {
                    days[i, j] = d;
                    d = d.AddDays(1);
                }
            }
            return new CalendarViewModel()
            {
                Date = date,
                Days = days
            };
        }*/

    }
}
