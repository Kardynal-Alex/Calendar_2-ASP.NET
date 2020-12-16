using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar_2.Models
{
    public interface IDataRepository
    {
        public Task CreateEvent(Event newEvent);
        public IQueryable<Event> GetAllCurrentEvent(DateTime date);
        public Task DeleteEvent(int id);
        public Task UpdateEvent(Event updateEvent);
        public Event GetEvent(int id);
        public int[,] CountAllEvent(DateTime[,] date);
    }
}
