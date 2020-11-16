using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calendar_2.Models;

namespace Calendar_2.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository repository;

        public HomeController(IDataRepository repo)
        {
            repository = repo;
        }

        public async Task<IActionResult> Index(int count=0)
        {
            var calendarViewModel = new CalendarViewModelBuilder().GetCurrentData(count);
            ViewBag.Array = await Task.Run(() => repository.CountAllEvent(calendarViewModel.Days));
            Page page = new Page(count);
            IndexViewModel indexViewModel = new IndexViewModel
            {
                CalendarViewModel=calendarViewModel,
                Page=page
            };
            ViewBag.p = count;
            return View(indexViewModel);
        }
     
        public async Task<IActionResult> TimeTable(int i,int j, int count)
        {
            CalendarViewModelBuilder cl = new CalendarViewModelBuilder();
            DateTime[,] Days = await Task.Run(() => cl.GetCurrentData(count).Days);
            ViewBag.CurDate = Days[i,j].ToString("dd-MM-yyyy");
            DateTime dt = Days[i,j];
            ViewBag.Ev = await Task.Run(() => repository.GetAllCurrentEvent(dt));
            ViewBag.i = i;
            ViewBag.j = j;
            ViewBag.page = count;
            return View();
        }
        public IActionResult Edit(int id,int i,int j)
        {
            ViewBag.i = i;
            ViewBag.j = j;
            return View("Editor",repository.GetEvent(id));
        }
        [HttpPost]
        public IActionResult Edit(Event @event,int i,int j,int count)
        {
            repository.UpdateEvent(@event);
            return RedirectToRoute(new { Controller = "Home", Action = "TimeTable", i = i, j = j, count = count });
        }
        [HttpPost]
        public IActionResult Create(Event @event,int i,int j,int count)
        {
            repository.CreateEvent(@event);
            return RedirectToRoute(new { Controller = "Home", Action = "TimeTable", i = i, j = j, count = count });
        }
        [HttpPost]
        public IActionResult Delete(int id,int i,int j,int count)
        {
            repository.DeleteEvent(id);
            return RedirectToRoute(new { Controller = "Home", Action = "TimeTable", i = i, j = j, count = count });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
