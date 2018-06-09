using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("event_users", Schema = "so")]
    public partial class EventUsers
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("event_id")]
        public int EventId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("EventId")]
        [InverseProperty("EventUsers")]
        public Events Event { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("EventUsers")]
        public Users User { get; set; }
    }
}
