using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("article_tags", Schema = "so")]
    public partial class ArticleTags
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("tag_id")]
        public int TagId { get; set; }
        [Column("article_id")]
        public int ArticleId { get; set; }

        [ForeignKey("ArticleId")]
        [InverseProperty("ArticleTags")]
        public Articles Article { get; set; }
        [ForeignKey("TagId")]
        [InverseProperty("ArticleTags")]
        public Tags Tag { get; set; }
    }
}
