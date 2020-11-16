using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calendar_2.Models;
namespace Calendar_2.Models
{
    public class EFDataRepository : IDataRepository
    {
        private EFDatabaseContext context;
        public EFDataRepository(EFDatabaseContext ctx)
        {
            context = ctx;
        }
        CalendarViewModelBuilder calendar = new CalendarViewModelBuilder();
        public int [,] CountAllEvent(DateTime [,] date)
        {
            DateTime[,] Days = date;
            int[,] arr = new int[6, 7];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    arr[i, j] = GetAllCurrentEvent(Days[i,j]).Count();
                }
            }
            return arr;
        }
        public Event GetEvent(int id)
        {
            return context.Events.Find(id);
        }
        public void CreateEvent(Event newEvent)
        {
            newEvent.Id = 0;
            context.Events.Add(newEvent);
            context.SaveChanges();
        }
        public IQueryable<Event> GetAllCurrentEvent(DateTime date)
        {
            IQueryable<Event> events = context.Events.OrderBy(x=>x.Time).Where(x => x.Date == date);
            
            return events;
        }
        public void DeleteEvent(int id)
        {
            context.Events.Remove(new Event { Id = id });
            context.SaveChanges();
        }
        public void UpdateEvent(Event updateEvent)
        {
            context.Events.Update(updateEvent);
            context.SaveChanges();
        }
    }
}
