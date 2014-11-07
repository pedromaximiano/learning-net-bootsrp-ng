using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard.Data
{
    public interface IMessageBoardRepository
    {
        IQueryable<Topic> GetTopics();
        IQueryable<Reply> GetRepliesByTopic(int topicId);
        IQueryable<Topic> GetTopicsIncludingReplies();
        bool Save();
        bool AddTopic(Topic topic);
        bool AddReply(Reply reply);
    }
}
