namespace Mvc_CommentingChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserFID_IntoReplayTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Replays", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Replays", "UserId");
            AddForeignKey("dbo.Replays", "UserId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replays", "UserId", "dbo.Users");
            DropIndex("dbo.Replays", new[] { "UserId" });
            DropColumn("dbo.Replays", "UserId");
        }
    }
}
