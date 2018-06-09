using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("tags", Schema = "so")]
    public partial class Tags
    {
        public Tags()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "character varying(40)")]
        public string Title { get; set; }

        [InverseProperty("Tag")]
        public ICollection<ArticleTags> ArticleTags { get; set; }
    }
}
