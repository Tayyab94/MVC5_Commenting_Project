using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc_CommentingChat.Models.ViewModels
{
    public class PitcherVM
    {
        [Required]
        public HttpPostedFileWrapper Pitcher { get; set; }
    }
}