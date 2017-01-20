namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring : DbMigration
    {
        public override void Up()
        {
            this.DropColumn("dbo.AspNetUsers", "IsDeleted");
            this.DropColumn("dbo.AspNetUsers", "DeletedOn");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.AspNetUsers", "DeletedOn", c => c.DateTime());
            this.AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
