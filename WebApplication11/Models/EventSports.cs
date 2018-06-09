using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("event_sports", Schema = "so")]
    public partial class EventSports
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("event_id")]
        public int EventId { get; set; }
        [Column("sport_id")]
        public int SportId { get; set; }

        [ForeignKey("EventId")]
        [InverseProperty("EventSports")]
        public Events Event { get; set; }
        [ForeignKey("SportId")]
        [InverseProperty("EventSports")]
        public Sports Sport { get; set; }
    }
}
