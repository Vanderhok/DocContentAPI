using DocContentAPI.Data;
using DocContentAPI.Models;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI
{
    public class Comments : IComments
    {
        private CommentaryContext commentaryContext;

        public Comments(CommentaryContext commentaryContext)
        {
            this.commentaryContext = commentaryContext;
        }

        public Guid AddComment(Commentary commentary)
        {
            commentary.Id = new Guid();
            commentaryContext.Comments.Add(commentary);
            commentaryContext.SaveChanges();
            return commentary.Id;
        }

     
        public IEnumerable<Commentary> GetComments(int docId) => commentaryContext.Comments.Where(x => x.DocId == docId);

        public IEnumerable<Commentary> GetComments(Guid userId) => commentaryContext.Comments.Where(x => x.UserId == userId);
       
    }
}
