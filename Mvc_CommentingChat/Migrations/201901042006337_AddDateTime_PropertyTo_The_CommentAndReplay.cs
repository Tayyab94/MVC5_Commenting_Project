namespace Mvc_CommentingChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTime_PropertyTo_The_CommentAndReplay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "createdTime", c => c.DateTime());
            AddColumn("dbo.Replays", "createdTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Replays", "createdTime");
            DropColumn("dbo.Comments", "createdTime");
        }
    }
}
