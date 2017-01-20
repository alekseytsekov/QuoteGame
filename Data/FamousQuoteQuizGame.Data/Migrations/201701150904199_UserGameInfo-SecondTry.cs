namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UserGameInfoSecondTry : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.UserGameInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        GameMode = c.Int(nullable: false, defaultValue: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            this.AddColumn("dbo.Quotes", "UserGameInfo_Id", c => c.Int());
            this.CreateIndex("dbo.Quotes", "UserGameInfo_Id");
            this.AddForeignKey("dbo.Quotes", "UserGameInfo_Id", "dbo.UserGameInfoes", "Id");
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.UserGameInfoes", "UserId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Quotes", "UserGameInfo_Id", "dbo.UserGameInfoes");
            this.DropIndex("dbo.UserGameInfoes", new[] { "UserId" });
            this.DropIndex("dbo.Quotes", new[] { "UserGameInfo_Id" });
            this.DropColumn("dbo.Quotes", "UserGameInfo_Id");
            this.DropTable("dbo.UserGameInfoes");
        }
    }
}
