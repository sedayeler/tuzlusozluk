using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Domain.Entities;
using TuzluSozluk.Domain.Entities.Common;

namespace TuzluSozluk.Persistence.Contexts
{
    public class TuzluSozlukContext : DbContext
    {
        public TuzluSozlukContext()
        {

        }

        public TuzluSozlukContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Entry> entries { get; set; }
        public DbSet<EntryVote> entry_votes { get; set; }
        public DbSet<EntryFavorite> entry_favorites { get; set; }
        public DbSet<EntryComment> entry_comments { get; set; }
        public DbSet<EntryCommentVote> entry_comment_votes { get; set; }
        public DbSet<EntryCommentFavorite> entry_comment_favorites { get; set; }
        public DbSet<EmailConfirmation> email_confirmations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedAt = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
