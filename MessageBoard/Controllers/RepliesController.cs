using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessageBoard.Data;

namespace MessageBoard.Controllers
{
    public class RepliesController : ApiController
    {
        private IMessageBoardRepository _repo;

        public RepliesController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Reply> Get(int topicId)
        {
            return _repo.GetRepliesByTopic(topicId); 
        }

        public HttpResponseMessage Post(int topicId, [FromBody] Reply reply)
        {
            if (reply == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Empty object");
            }

            if (reply.Created == default(DateTime))
            {
                reply.Created = DateTime.Now;
            }

            reply.TopicId = topicId;

            if (_repo.AddReply(reply) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, reply);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Could not save the new reply to the database");            
        }
    }
}
