namespace FamousQuoteQuizGame.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class addInterfaceToUserInfoAndUserStatistic : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.UserGameInfoes", "CreatedOn", c => c.DateTime(nullable: false));
            this.AddColumn("dbo.UserGameInfoes", "ModifiedOn", c => c.DateTime());
            this.AddColumn("dbo.UserGameInfoes", "IsDeleted", c => c.Boolean(nullable: false));
            this.AddColumn("dbo.UserGameInfoes", "DeletedOn", c => c.DateTime());
            this.AddColumn("dbo.UserStatistics", "CreatedOn", c => c.DateTime(nullable: false));
            this.AddColumn("dbo.UserStatistics", "ModifiedOn", c => c.DateTime());
            this.AddColumn("dbo.UserStatistics", "IsDeleted", c => c.Boolean(nullable: false));
            this.AddColumn("dbo.UserStatistics", "DeletedOn", c => c.DateTime());
            this.CreateIndex("dbo.UserGameInfoes", "IsDeleted");
            this.CreateIndex("dbo.UserStatistics", "IsDeleted");
        }
        
        public override void Down()
        {
            this.DropIndex("dbo.UserStatistics", new[] { "IsDeleted" });
            this.DropIndex("dbo.UserGameInfoes", new[] { "IsDeleted" });
            this.DropColumn("dbo.UserStatistics", "DeletedOn");
            this.DropColumn("dbo.UserStatistics", "IsDeleted");
            this.DropColumn("dbo.UserStatistics", "ModifiedOn");
            this.DropColumn("dbo.UserStatistics", "CreatedOn");
            this.DropColumn("dbo.UserGameInfoes", "DeletedOn");
            this.DropColumn("dbo.UserGameInfoes", "IsDeleted");
            this.DropColumn("dbo.UserGameInfoes", "ModifiedOn");
            this.DropColumn("dbo.UserGameInfoes", "CreatedOn");
        }
    }
}
