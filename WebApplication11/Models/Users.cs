using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    [Table("users", Schema = "so")]
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            EventUsers = new HashSet<EventUsers>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("first_name", TypeName = "character varying(120)")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name", TypeName = "character varying(120)")]
        public string LastName { get; set; }
        [Column("birthday", TypeName = "date")]
        public DateTime Birthday { get; set; }

        [InverseProperty("User")]
        public ICollection<Comments> Comments { get; set; }
        [InverseProperty("User")]
        public ICollection<EventUsers> EventUsers { get; set; }
    }
}
