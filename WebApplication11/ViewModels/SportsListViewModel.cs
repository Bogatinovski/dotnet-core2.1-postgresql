using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication11.Models;
using WebApplication11.QueryTypes;

namespace WebApplication11.ViewModels
{
    public class SportsListViewModel
    {
        public IEnumerable<SportsItem> Sports { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalSports { get; set; }
    }
}
