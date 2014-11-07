using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MessageBoard.Data
{
    public class MessageBoardContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public MessageBoardContext()
            : base("DefaultConnection")
        {
            // We want to have control over the data transmitted over the wire.
            // As an example, we don't need to show the replies when showing the topics
            Configuration.LazyLoadingEnabled = false;

            // Proxy objects may cause problem when serialized across the wire
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MessageBoardContext, MessageBoardMigrationsConfiguration>());
        }
    }
}