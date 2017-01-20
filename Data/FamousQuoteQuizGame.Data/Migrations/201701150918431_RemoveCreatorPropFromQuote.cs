namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCreatorPropFromQuote : DbMigration
    {
        public override void Up()
        {
            this.DropForeignKey("dbo.Quotes", "CreatorId", "dbo.AspNetUsers");
            this.DropIndex("dbo.Quotes", new[] { "CreatorId" });
            this.DropColumn("dbo.Quotes", "CreatorId");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.Quotes", "CreatorId", c => c.String(maxLength: 128));
            this.CreateIndex("dbo.Quotes", "CreatorId");
            this.AddForeignKey("dbo.Quotes", "CreatorId", "dbo.AspNetUsers", "Id");
        }
    }
}
