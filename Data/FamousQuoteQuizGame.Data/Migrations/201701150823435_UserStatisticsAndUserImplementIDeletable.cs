namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UserStatisticsAndUserImplementIDeletable : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.UserStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        KnownQuotes = c.Int(),
                        AttemptsGuess = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            this.AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            this.AddColumn("dbo.AspNetUsers", "DeletedOn", c => c.DateTime());
            this.AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 30));
            this.AlterColumn("dbo.Quotes", "Content", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.UserStatistics", "UserId", "dbo.AspNetUsers");
            this.DropIndex("dbo.UserStatistics", new[] { "UserId" });
            this.AlterColumn("dbo.Quotes", "Content", c => c.String());
            this.AlterColumn("dbo.Authors", "Name", c => c.String());
            this.DropColumn("dbo.AspNetUsers", "DeletedOn");
            this.DropColumn("dbo.AspNetUsers", "IsDeleted");
            this.DropTable("dbo.UserStatistics");
        }
    }
}
