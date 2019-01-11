using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_CommentingChat.Models.ViewModels
{
    public class RegisterVM
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [MinLength(5), Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password"),Display(Name ="Cofirm Password")]
        public string ConfirmPassword { get; set; }

        [EmailAddress,Required]
        public string Email { get; set; }
    }
}