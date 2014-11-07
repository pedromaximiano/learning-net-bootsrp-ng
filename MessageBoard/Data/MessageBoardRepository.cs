using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {
            var topics = _ctx.Topics.Include("Replies");

            return topics;
        }

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool AddTopic(Topic topic)
        {
            try
            {
                _ctx.Topics.Add(topic);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return false;
            }
        }

        public bool AddReply(Reply reply)
        {
            try
            {
                _ctx.Replies.Add(reply);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return false;
            }
        }
    }
}