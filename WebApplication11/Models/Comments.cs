using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("comments", Schema = "so")]
    public partial class Comments
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("article_id")]
        public int ArticleId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Required]
        [Column("content")]
        public string Content { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("ArticleId")]
        [InverseProperty("Comments")]
        public Articles Article { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Comments")]
        public Users User { get; set; }
    }
}
