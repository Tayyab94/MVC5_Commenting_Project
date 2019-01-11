using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc_CommentingChat.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50),Index(IsUnique =true),Column(TypeName ="varchar")]
        public string Name { get; set; }

        [MinLength(5),Required,DataType(DataType.Password)]
        public string Password { get; set; }

        [EmailAddress,Index(IsUnique =true),Column(TypeName ="varchar"),Required]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public string ImgUrl { get; set; }

        public DateTime? createdTime { get; set; }
    }
}