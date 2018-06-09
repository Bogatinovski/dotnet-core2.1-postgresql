using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("article_categories", Schema = "so")]
    public partial class ArticleCategories
    {
        public ArticleCategories()
        {
            Articles = new HashSet<Articles>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "character varying(40)")]
        public string Title { get; set; }

        [InverseProperty("Category")]
        public ICollection<Articles> Articles { get; set; }
    }
}
