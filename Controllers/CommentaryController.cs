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

        [HttpGet]
        public Commentary Get([FromBody]Commentary comment)
        {
            return comments.GetCommentsData(comment);
        }

        //http://localhost:2233/api/Commentary/2
        [HttpGet("{id:int}")]
        public IEnumerable<Commentary> GetComments(int id)
        {
            return comments.GetComments(id);
        }

        //http://localhost:2233/api/Commentary/cb053101-6252-4bec-923e-dcf2fe6ecc7f
        [HttpGet("{id:guid}")]
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
