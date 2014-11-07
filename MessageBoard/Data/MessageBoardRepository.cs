using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard.Data
{
    public class MessageBoardRepository : IMessageBoardRepository
    {
        private MessageBoardContext _ctx;

        public MessageBoardRepository(MessageBoardContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Topic> GetTopics()
        {
            var topics = _ctx.Topics;

            return topics;
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            var replies = _ctx.Replies.Where(c => c.TopicId == topicId);

            return replies;
        }
    }
}