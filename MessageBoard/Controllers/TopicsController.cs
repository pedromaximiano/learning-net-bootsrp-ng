using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessageBoard.Data;

namespace MessageBoard.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository _repo;

        public TopicsController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Topic> Get(bool includeReplies = false)
        {
            IQueryable<Topic> results;

            results = includeReplies ? _repo.GetTopicsIncludingReplies() : _repo.GetTopics();

            return results.OrderByDescending(c => c.Created).Take(50).ToList();
        }

        public HttpResponseMessage Post([FromBody]Topic topic)
        {
            if (topic == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty object");
            }
            
            if (topic.Created == default(DateTime))
            {
                topic.Created = DateTime.Now;
            }
            
            if (_repo.AddTopic(topic) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, topic);
            }
            
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Could not save the new topic to the database");
        }
    }
}
