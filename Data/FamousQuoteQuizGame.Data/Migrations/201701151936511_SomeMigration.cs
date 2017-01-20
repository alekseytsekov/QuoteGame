namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SomeMigration : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes");
            this.DropIndex("dbo.Quotes", new[] { "UserGameInfoId" });
            this.AlterColumn("dbo.Quotes", "UserGameInfoId", c => c.Int(nullable: true));
            this.CreateIndex("dbo.Quotes", "UserGameInfoId");
            this.AddForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes");
            this.DropIndex("dbo.Quotes", new[] { "UserGameInfoId" });
            this.AlterColumn("dbo.Quotes", "UserGameInfoId", c => c.Int());
            this.CreateIndex("dbo.Quotes", "UserGameInfoId");
            this.AddForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes", "Id");
        }
    }
}
