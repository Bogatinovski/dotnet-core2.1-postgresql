using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("articles", Schema = "so")]
    public partial class Articles
    {
        public Articles()
        {
            ArticleTags = new HashSet<ArticleTags>();
            Comments = new HashSet<Comments>();
            EventsAnnouncement = new HashSet<Events>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("album_id")]
        public int? AlbumId { get; set; }
        [Required]
        [Column("title", TypeName = "character varying(80)")]
        public string Title { get; set; }
        [Required]
        [Column("content")]
        public string Content { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Required]
        [Column("cover_content", TypeName = "character varying(255)")]
        public string CoverContent { get; set; }
        [Required]
        [Column("cover_media", TypeName = "character varying(255)")]
        public string CoverMedia { get; set; }
        [Column("cover_media_thumbnail", TypeName = "character varying(255)")]
        public string CoverMediaThumbnail { get; set; }

        [ForeignKey("AlbumId")]
        [InverseProperty("Articles")]
        public Albums Album { get; set; }
        [ForeignKey("CategoryId")]
        [InverseProperty("Articles")]
        public ArticleCategories Category { get; set; }
        [InverseProperty("Report")]
        public Events EventsReport { get; set; }
        [InverseProperty("Article")]
        public ICollection<ArticleTags> ArticleTags { get; set; }
        [InverseProperty("Article")]
        public ICollection<Comments> Comments { get; set; }
        [InverseProperty("Announcement")]
        public ICollection<Events> EventsAnnouncement { get; set; }
    }
}
