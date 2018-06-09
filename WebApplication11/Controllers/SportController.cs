using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Models;
using WebApplication11.ViewModels;

namespace WebApplication11.Controllers
{
    public class SportController : Controller
    {
        private postgresContext context;
        private const int pageSize = 10;

        public SportController(postgresContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int page = 1)
        {
            SportsListViewModel result = new SportsListViewModel();
            IEnumerable<SingleSportViewModel> sports = context.Sports.OrderBy(s => s.Id).Skip((page-1) * 10).Take(10).Select(s => new SingleSportViewModel
            {
                Sport = s,
                EventsCount = s.Events.Count()
            }).ToList();

            result.Sports = sports;
            result.TotalSports = context.Sports.Count();
            result.TotalPages = (result.TotalSports / pageSize) + ((result.TotalSports % pageSize != 0) ? 1 : 0);
            
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Sports sport = context.Sports.Find(id);
            
            context.Sports.Remove(sport);
            context.SaveChanges();

            return RedirectToAction("Index", "Sport");
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateSportViewModel model = new CreateSportViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateSportViewModel model)
        {
            // Edit
            if (model.Id > 0)
            {
                Sports sport = context.Sports.Find(model.Id);
                sport.Title = model.Title;

                context.Sports.Update(sport);
                context.SaveChanges();
            }
            else
            {
                Sports sport = new Sports
                {
                    Title = model.Title,
                };

                context.Sports.Add(sport);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Sport");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Sports sport = context.Sports.Find(id);

            CreateSportViewModel model = new CreateSportViewModel
            {
                Id = sport.Id,
                Title = sport.Title
            };

            return View("Create", model);
        }
    }
}
