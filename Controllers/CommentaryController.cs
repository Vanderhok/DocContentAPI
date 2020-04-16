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
        public ActionResult Get()
        {
            return Ok();
        }

        //https://localhost:44308/api/Commentary/2
        [HttpGet("{id:int}")]
        public IEnumerable<Commentary> GetComments(int id)
        {
            return comments.GetComments(id);
        }

        //https://localhost:44308/api/Commentary/cb053101-6252-4bec-923e-dcf2fe6ecc7f
        [HttpGet("{id:guid}")]
        public IEnumerable<Commentary> GetComments(Guid id)
        {
            return comments.GetComments(id);
        }

        [HttpPost]
        public ActionResult Post(Commentary commentary)
        {
            commentary.Id = Guid.NewGuid();
            commentary.DocId = 55;

            comments.AddComment(commentary);
            return Ok();
        }

    }


}
