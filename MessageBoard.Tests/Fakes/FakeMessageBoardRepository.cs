using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageBoard.Data;

namespace MessageBoard.Tests.Fakes
{
    public class FakeMessageBoardRepository : IMessageBoardRepository
    {
        private Collection<Topic> _topics = new Collection<Topic>();
        
        public FakeMessageBoardRepository()
        {
            var topic = new Topic()
            {
                Body = "Topic 1",
                Created = new DateTime(2014, 01, 01),
                Flagged = false,
                Id = 1,
                Replies = new Collection<Reply>(),
                Title = "Topic 1"
            };

            var reply = new Reply()
            {
                Body = "Reply #1 to topic 1",
                Created = new DateTime(2014, 01, 01),
                Id = 1,
                TopicId = 1
            };

            reply = new Reply()
            {
                Body = "Reply #2 to topic 1",
                Created = new DateTime(2014, 01, 01),
                Id = 2,
                TopicId = 1
            };

            topic.Replies.Add(reply);
            _topics.Add(topic);
        }
        
        public IQueryable<Topic> GetTopics()
        {
            return _topics.AsQueryable();
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            foreach (var topic in _topics)
            {
                if (topic.Id == topicId)
                {
                    return topic.Replies.AsQueryable();
                }
            }

            return null;
        }

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {
            return GetTopics();
        }

        public bool Save()
        {
            return true;
        }

        public bool AddTopic(Topic topic)
        {
            try
            {
                topic.Id = 1;
                _topics.Add(topic);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddReply(Reply reply)
        {
            throw new NotImplementedException();
        }
    }
}
