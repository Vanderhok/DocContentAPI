using DocContentAPI.Data;
using DocContentAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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

        public Guid AddComment(Commentary comment)
        {
            comment.Id = Guid.NewGuid();
            comment.UserId = Guid.NewGuid();

            commentaryContext.Commentaries.Add(comment);
            commentaryContext.SaveChanges();

            return comment.Id;
        }


        public IEnumerable<Commentary> GetComments(int docId) => commentaryContext.Commentaries.Where(x => x.DocId == docId);

        public IEnumerable<Commentary> GetComments(Guid userId) => commentaryContext.Commentaries.Where(x => x.UserId == userId);

        public Commentary GetCommentData(Guid id)
        {
            //var query = from comment in commentaryContext.Commentaries
            //            join comment2 in commentaryContext.Commentaries
            //            on comment.Id equals comment2.ParentId
            //            where comment.Id == id
            //            select new { comment = comment, comment2 = comment2 };
            //var result = query.ToList();
            //var parrent = new Commentary();
            //parrent.Id = result[0].comment.Id;
            //parrent.Answers = result.Select(e => e.comment2).ToList();

            return commentaryContext.Commentaries.Include(x => x.Answers).FirstOrDefault(x => x.Id == id);
        }


    }
}
