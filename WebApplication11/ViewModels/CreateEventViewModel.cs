using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication11.Models;

namespace WebApplication11.ViewModels
{
    public class CreateEventViewModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public string SportId { get; set; }
        public List<SelectListItem> Sports { get; set; }
    }
}
