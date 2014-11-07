using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;

namespace MessageBoard.Data
{
    public class MessageBoardMigrationsConfiguration : DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardMigrationsConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context)
        {
            base.Seed(context);

#if DEBUG
            if (context.Topics.Count() == 0)
            {
                var topic = new Topic()
                {
                    Body = "I Love MVC",
                    Created = DateTime.Now,
                    Flagged = false,
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "I love it too!",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Naaaaaa",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "It's awsome!!",
                            Created = DateTime.Now
                        }
                    },
                    Title = "This is why I love MVC!"
                };

                context.Topics.Add(topic);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
#endif
        }
    }
}