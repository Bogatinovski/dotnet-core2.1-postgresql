using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("events", Schema = "so")]
    public partial class Events
    {
        public Events()
        {
            EventSports = new HashSet<EventSports>();
            EventUsers = new HashSet<EventUsers>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("announcement_id")]
        public int? AnnouncementId { get; set; }
        [Column("report_id")]
        public int? ReportId { get; set; }
        [Column("sport_id")]
        public int SportId { get; set; }
        [Column("starts_at")]
        public DateTime StartsAt { get; set; }
        [Column("ends_at")]
        public DateTime EndsAt { get; set; }
        [Required]
        [Column("title", TypeName = "character varying(255)")]
        public string Title { get; set; }

        [ForeignKey("AnnouncementId")]
        [InverseProperty("EventsAnnouncement")]
        public Articles Announcement { get; set; }
        [ForeignKey("ReportId")]
        [InverseProperty("EventsReport")]
        public Articles Report { get; set; }
        [ForeignKey("SportId")]
        [InverseProperty("Events")]
        public Sports Sport { get; set; }
        [InverseProperty("Event")]
        public ICollection<EventSports> EventSports { get; set; }
        [InverseProperty("Event")]
        public ICollection<EventUsers> EventUsers { get; set; }
    }
}
