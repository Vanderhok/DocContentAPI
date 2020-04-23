using DocContentAPI.Data;
using DocContentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
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
       
        //http://localhost:2233/api/Commentary/GetCommentData/cfc77d77-4d4c-4514-b632-a80aa7411152
        [HttpGet("GetCommentData/{id:guid}")]
        public Commentary GetCommentData(Guid id)
        {
            //var options = new System.Text.Json.JsonSerializerOptions
            //{
            //    ReferenceHandling= ReferenceHandling.Preserve
            //};

            //var result = comments.GetCommentData(id);
            //string json = JsonSerializer.Serialize(result, options);

            return comments.GetCommentData(id);
        }

        //http://localhost:2233/api/Commentary/GetComments/2
        [HttpGet("GetComments/{id:int}")]
        public IEnumerable<Commentary> GetComments(int id)
        {
            return comments.GetComments(id);
        }

        //http://localhost:2233/api/Commentary/GetComments/217717ba-b416-4b80-6d76-08d7e683b72c
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
