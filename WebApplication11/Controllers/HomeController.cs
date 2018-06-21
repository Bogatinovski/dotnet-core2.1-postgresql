using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Models;
using WebApplication11.QueryTypes;
using WebApplication11.ViewModels;

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        private postgresContext context;
        private const int pageSize = 10;

        public HomeController(postgresContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int page = 1)
        {
            EventsListViewModel result = new EventsListViewModel();
            IEnumerable<EventsItem> events = context.Query<EventsItem>().FromSql($"SELECT * FROM get_events({page}, {pageSize})").ToList();

            result.Events = events;
            result.TotalEvents = context.Events.Count();
            result.TotalPages = (result.TotalEvents / pageSize) + ((result.TotalEvents % pageSize != 0) ? 1 : 0);
            
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Events e = context.Events.Find(id);
            context.Events.Remove(e);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Sports> sports = context.Sports.ToList();
            CreateEventViewModel model = new CreateEventViewModel
            {
                StartsAt = DateTime.UtcNow.Subtract(TimeSpan.FromHours(20)),
                EndsAt = DateTime.UtcNow.AddHours(10),
                Sports = sports.Select(s => new SelectListItem
                {
                    Text = s.Title,
                    Value = s.Id.ToString()
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateEventViewModel model)
        {
            int sportId = int.Parse(model.SportId);

            // Edit
            if (model.Id > 0)
            {
                Events e = context.Events.Find(model.Id);
                e.Title = model.Name;
                e.StartsAt = model.StartsAt;
                e.EndsAt = model.EndsAt;
                e.SportId = int.Parse(model.SportId);

                context.Events.Update(e);
                context.SaveChanges();
            }
            else
            {
                Events e = new Events
                {
                    CreatedAt = DateTime.UtcNow,
                    EndsAt = model.EndsAt,
                    StartsAt = model.StartsAt,
                    Title = model.Name,
                    SportId = sportId
                };

                context.Events.Add(e);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Events e = context.Events.Find(id);

            IEnumerable<Sports> sports = context.Sports.ToList();
            CreateEventViewModel model = new CreateEventViewModel
            {
                Id = e.Id,
                Name = e.Title,
                SportId = e.SportId.ToString(),
                StartsAt = e.StartsAt,
                EndsAt = e.EndsAt,
                Sports = sports.Select(s => new SelectListItem
                {
                    Selected = s.Id == e.SportId,
                    Text = s.Title,
                    Value = s.Id.ToString()
                }).ToList()
            };

            return View("Create", model);
        }
    }
}
