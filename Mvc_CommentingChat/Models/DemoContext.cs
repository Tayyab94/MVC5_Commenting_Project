using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc_CommentingChat.Models
{
    public class DemoContext:DbContext
    {
        public DemoContext():base("ABC")
        {

        }

        public DbSet<User>  Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Replay>  Replays { get; set; }
    }
}