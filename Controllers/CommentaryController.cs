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
            return comments.GetCommentData(id);     //S* Для использования раскоментить //S*527 (Startup)
        }

        //http://localhost:2233/api/Commentary/GetCommentWithAnswers/cfc77d77-4d4c-4514-b632-a80aa7411152
        [HttpGet("GetCommentWithAnswers/{id:guid}")]
        public  RequestCommentMdl GetCommentWithAnswers(Guid id)
        {
            return comments.GetCommentWithAnswers(id);
        }

        //http://localhost:2233/api/Commentary/GetComments/1
        [HttpGet("GetComments/{id:int}")]
        public IEnumerable<RequestCommentMdl> GetComments(int id)
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
