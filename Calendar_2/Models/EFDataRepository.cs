using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar_2.Models
{
    public class EFDataRepository : IDataRepository
    {
        private EFDatabaseContext context;
        public EFDataRepository(EFDatabaseContext ctx)
        {
            context = ctx;
        }
        public int [,] CountAllEvent(DateTime [,] date)
        {
            DateTime[,] Days = date;
            int[,] arr = new int[6, 7];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    arr[i, j] = GetAllCurrentEventWithoutOrder(Days[i,j]).Count();
                }
            }
            return arr;
        }
        public IQueryable<Event> GetAllCurrentEventWithoutOrder(DateTime date) => context.Events.Where(x => x.Date == date);
        public async Task<Event> GetEvent(int id) => await context.Events.FindAsync(id);
        public async Task CreateEvent(Event newEvent)
        {
            newEvent.Id = 0;
            context.Events.Add(newEvent);
            await context.SaveChangesAsync();
        }
        public IQueryable<Event> GetAllCurrentEvent(DateTime date)
        {
            return context.Events.OrderBy(x => x.Time).Where(x => x.Date == date);
        }
        public async Task DeleteEvent(int id)
        {
            context.Events.Remove(new Event { Id = id });
            await context.SaveChangesAsync();
        }
        public async Task UpdateEvent(Event updateEvent)
        {
            context.Events.Update(updateEvent);
            await context.SaveChangesAsync();
        }
    }
}
