﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.ViewModels
{
    public class EventsReportViewModel
    {
        public EventsListViewModel EventsList { get; set; }
        public SearchEventsViewModel Search { get; set; }
    }
}
