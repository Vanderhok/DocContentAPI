using DocContentAPI.Data;
using DocContentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI
{
    public class Comments : IComments
    {
        private readonly CommentaryContext commentaryContext;

        public Comments(CommentaryContext commentaryContext)
        {
            this.commentaryContext = commentaryContext;
        }

        public int AddComment(Commentary commentary)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Commentary> GetComments(int DocId) => commentaryContext.Comments.Where(x => x.DocId == DocId);
      

        public IEnumerable<Commentary> GetComments(Guid UserId) => commentaryContext.Comments.Where(x => x.UserId == UserId);
       
    }
}
