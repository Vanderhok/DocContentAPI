using DocContentAPI.Data;
using DocContentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentaryController : ControllerBase
    {
        private readonly IComments comments;

        public CommentaryController(IComments comments)
        {
            this.comments = comments;
        }


        //http://localhost:2233/api/Commentary/GetCommentsData/
        [HttpGet("GetCommentsData/{id:guid}")]
        public CommentsData Get(Guid id)
        {
            return comments.GetCommentsData(id);
        }

        //http://localhost:2233/api/Commentary/GetComments/2
        [HttpGet("GetComments/{id:int}")]
        public IEnumerable<Commentary> GetComments(int id)
        {
            return comments.GetComments(id);
        }

        //http://localhost:2233/api/Commentary/GetComments/
        [HttpGet("GetComments/{id:guid}")]
        public IEnumerable<Commentary> GetComments(Guid id)
        {
            return comments.GetComments(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody]Commentary comment)
        {
            comments.AddComment(comment);

            return Ok();
        }

    }


}
