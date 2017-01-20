namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SetNumericPropToDefaultZero : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserStatistics", "CorrectAnswer", c => c.Int(nullable: true, defaultValue: 0));
            AlterColumn("dbo.UserStatistics", "AttemptsGuess", c => c.Int(nullable: true, defaultValue: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserStatistics", "AttemptsGuess", c => c.Int());
            AlterColumn("dbo.UserStatistics", "CorrectAnswer", c => c.Int());
        }
    }
}
