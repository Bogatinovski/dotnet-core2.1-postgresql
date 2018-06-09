using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("albums", Schema = "so")]
    public partial class Albums
    {
        public Albums()
        {
            Articles = new HashSet<Articles>();
            Images = new HashSet<Images>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "character varying(60)")]
        public string Title { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [InverseProperty("Album")]
        public ICollection<Articles> Articles { get; set; }
        [InverseProperty("Album")]
        public ICollection<Images> Images { get; set; }
    }
}
