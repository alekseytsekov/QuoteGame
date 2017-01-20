namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesInTheDbStructure : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.Quotes", "UserGameInfo_Id", "dbo.UserGameInfoes");
            this.DropIndex("dbo.Quotes", new[] { "UserGameInfo_Id" });
            this.RenameColumn(table: "dbo.Quotes", name: "UserGameInfo_Id", newName: "UserGameInfoId");
            this.AlterColumn("dbo.Quotes", "UserGameInfoId", c => c.Int(nullable: true));
            this.CreateIndex("dbo.Quotes", "UserGameInfoId");
            this.AddForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Quotes", "UserGameInfoId", "dbo.UserGameInfoes");
            this.DropIndex("dbo.Quotes", new[] { "UserGameInfoId" });
            this.AlterColumn("dbo.Quotes", "UserGameInfoId", c => c.Int());
            this.RenameColumn(table: "dbo.Quotes", name: "UserGameInfoId", newName: "UserGameInfo_Id");
            this.CreateIndex("dbo.Quotes", "UserGameInfo_Id");
            this.AddForeignKey("dbo.Quotes", "UserGameInfo_Id", "dbo.UserGameInfoes", "Id");
        }
    }
}
