using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication11.Models;
using WebApplication11.QueryTypes;

namespace WebApplication11.ViewModels
{
    public class EventsReportListViewModel
    {
        public IEnumerable<EventsItemReport> Events { get; set; }
        public long TotalPages { get; set; }
        public long CurrentPage { get; set; }
        public long TotalEvents { get; set; }
    }
}
