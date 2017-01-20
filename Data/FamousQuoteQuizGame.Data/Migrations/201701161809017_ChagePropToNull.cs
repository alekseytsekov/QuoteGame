namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChagePropToNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserStatistics", "CorrectAnswer", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserStatistics", "CorrectAnswer", c => c.Int(nullable: false));
        }
    }
}
