using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("sports", Schema = "so")]
    public partial class Sports
    {
        public Sports()
        {
            EventSports = new HashSet<EventSports>();
            Events = new HashSet<Events>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "character varying(120)")]
        public string Title { get; set; }

        [InverseProperty("Sport")]
        public ICollection<EventSports> EventSports { get; set; }
        [InverseProperty("Sport")]
        public ICollection<Events> Events { get; set; }
    }
}
