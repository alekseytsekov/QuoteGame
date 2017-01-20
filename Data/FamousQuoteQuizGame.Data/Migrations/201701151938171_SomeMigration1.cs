namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SomeMigration1 : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes");
            this.DropIndex("dbo.Quotes", new[] { "UserGameInfoId" });
            this.AlterColumn("dbo.Quotes", "UserGameInfoId", c => c.Int(nullable:true));
            this.CreateIndex("dbo.Quotes", "UserGameInfoId");
            this.AddForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes", "Id");
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes");
            this.DropIndex("dbo.Quotes", new[] { "UserGameInfoId" });
            this.AlterColumn("dbo.Quotes", "UserGameInfoId", c => c.Int(nullable: false));
            this.CreateIndex("dbo.Quotes", "UserGameInfoId");
            this.AddForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes", "Id", cascadeDelete: true);
        }
    }
}
