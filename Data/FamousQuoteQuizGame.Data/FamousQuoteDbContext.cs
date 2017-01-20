namespace FamousQuoteQuizGame.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using FamousQuoteQuizGame.Data.Models;
    using FamousQuoteQuizGame.Data.Models.Interfaces;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class FamousQuoteDbContext : IdentityDbContext<User>
    {
        public FamousQuoteDbContext()
            : base("FamousQuoteQuizGame", throwIfV1Schema: false)
        {
        }

        public static FamousQuoteDbContext Create()
        {
            return new FamousQuoteDbContext();
        }

        public virtual IDbSet<UserStatistic> UserStatistics { get; set; }

        public virtual IDbSet<Author> Authors { get; set; }

        public virtual IDbSet<Quote> Quotes { get; set; }

        public virtual IDbSet<UserGameInfo> UserGameInfos { get; set; }
        
        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
