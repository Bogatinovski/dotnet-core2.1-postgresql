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
            model.Page = model.Page.HasValue ? model.Page.Value : 1;

            EventsReportListViewModel result = new EventsReportListViewModel();
            IEnumerable<EventsItemReport> events = context.Query<EventsItemReport>().FromSql($"SELECT * FROM get_events_report({model.Page.Value}, {pageSize}, {model.StartAfter}, {model.StartBefore}, {model.EndAfter}, {model.EndBefore})").ToList();
            result.Events = events;

            result.TotalEvents = context.Query<EventsReportCount>().FromSql($"SELECT * FROM get_events_report_count({model.StartAfter}, {model.StartBefore}, {model.EndAfter}, {model.EndBefore})").FirstOrDefault().total;
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
