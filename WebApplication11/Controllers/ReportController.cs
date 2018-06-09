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
    public class ReportController : Controller
    {
        private postgresContext context;
        private const int pageSize = 10;

        public ReportController(postgresContext context)
        {
            this.context = context;
        }

        public IActionResult Index(EventsReportViewModel request)
        {
            var model = request.Search;
            if(model == null)
            {
                model = new SearchEventsViewModel();
            }
            model.Page = model.Page.HasValue ? (model.Page.Value - 1) : 1;

            EventsListViewModel result = new EventsListViewModel();
            IQueryable<Events> query = context.Events.Include(e => e.Sport);

            if (model.StartAfter.HasValue)
            {
                query = query.Where(e => e.StartsAt >= model.StartAfter.Value);
            }
            if (model.StartBefore.HasValue)
            {
                query = query.Where(e => e.StartsAt <= model.StartBefore.Value);
            }
            if (model.EndAfter.HasValue)
            {
                query = query.Where(e => e.EndsAt >= model.EndAfter.Value);
            }
            if (model.EndBefore.HasValue)
            {
                query = query.Where(e => e.EndsAt <= model.EndBefore.Value);
            }

            result.TotalEvents = query.Count();

            IEnumerable<Events> events = query.OrderBy(e => e.Id).Skip(model.Page.Value * pageSize).Take(pageSize).ToList();

            result.Events = events;
            
            result.TotalPages = (result.TotalEvents / pageSize) + ((result.TotalEvents % pageSize != 0) ? 1 : 0);

            EventsReportViewModel response = new EventsReportViewModel
            {
                EventsList = result,
                Search = model
            };

            return View(response);
        }
    }
}
