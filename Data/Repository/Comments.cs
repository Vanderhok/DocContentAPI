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
            commentaryContext.Comments.Add(comment);
            commentaryContext.SaveChanges();
            return comment.Id;
        }


        public IEnumerable<Commentary> GetComments(int docId) => commentaryContext.Comments.Where(x => x.DocId == docId);

        public IEnumerable<Commentary> GetComments(Guid userId) => commentaryContext.Comments.Where(x => x.UserId == userId);

        public CommentsData GetCommentsData(Commentary commentary)
        {
            CommentsData commentsList = new CommentsData
            {
                Id = commentary.Id,
                DocId = commentary.DocId,
                //...
                Answers = commentaryContext.Comments.Where(x => x.ParentId == commentary.Id).ToList()
            };
            return commentsList;
        }


    }
}
