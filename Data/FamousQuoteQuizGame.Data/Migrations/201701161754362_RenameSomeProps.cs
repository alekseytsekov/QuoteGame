namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameSomeProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStatistics", "CorrectAnswer", c => c.Int());
            DropColumn("dbo.UserStatistics", "KnownQuotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserStatistics", "KnownQuotes", c => c.Int());
            DropColumn("dbo.UserStatistics", "CorrectAnswer");
        }
    }
}
