using DocContentAPI.Data;
using DocContentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DocContentAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentaryController : ApiController, IComments
    {
        private readonly IComments comments;

        public CommentaryController(IComments comments)
        {
            this.comments = comments;
        }

        [HttpGet]
        [Route("GetCommentsByDocId")]
        public IEnumerable<Commentary> GetComments(int DocId)
        {
            return comments.GetComments(DocId);
        }

        [HttpGet]
        [Route("GetCommentsByUserId")]
        public IEnumerable<Commentary> GetComments(Guid UserId)
        {
            return comments.GetComments(UserId);
        }

      
    }


}
