using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication11.Models;

namespace WebApplication11.ViewModels
{
    public class EventsListViewModel
    {
        public IEnumerable<Events> Events { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalEvents { get; set; }
    }
}
