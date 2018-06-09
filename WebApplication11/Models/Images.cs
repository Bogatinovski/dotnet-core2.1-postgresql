using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("images", Schema = "so")]
    public partial class Images
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("album_id")]
        public int AlbumId { get; set; }
        [Required]
        [Column("url", TypeName = "character varying(255)")]
        public string Url { get; set; }
        [Required]
        [Column("thumbnail_url", TypeName = "character varying(255)")]
        public string ThumbnailUrl { get; set; }
        [Column("caption", TypeName = "character varying(80)")]
        public string Caption { get; set; }

        [ForeignKey("AlbumId")]
        [InverseProperty("Images")]
        public Albums Album { get; set; }
    }
}
