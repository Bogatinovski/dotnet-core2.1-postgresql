using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication11.Models;

namespace WebApplication11.ViewModels
{
    public class CreateSportViewModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
    }
}
