using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication11.QueryTypes
{
    public class EventsItem
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public string Title { get; set; }
        public string Sport { get; set; }
    }
}
