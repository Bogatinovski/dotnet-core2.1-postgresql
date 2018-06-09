using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.ViewModels
{
    public class SearchEventsViewModel
    {
        public DateTime? StartBefore { get; set; }
        public DateTime? StartAfter { get; set; }
        public DateTime? EndBefore { get; set; }
        public DateTime? EndAfter { get; set; }
        public int? Page { get; set; }
    }
}
