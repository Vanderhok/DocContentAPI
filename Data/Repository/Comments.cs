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

            commentaryContext.Comments.Add(comment);
            commentaryContext.SaveChanges();

            return comment.Id;
        }


        public IEnumerable<Commentary> GetComments(int docId) => commentaryContext.Comments.Where(x => x.DocId == docId);

        public IEnumerable<Commentary> GetComments(Guid userId) => commentaryContext.Comments.Where(x => x.UserId == userId);

        public CommentsData GetCommentsData(Guid id)
        {
            Commentary commentary = new Commentary();

            commentary = commentaryContext.Comments.Where(x => x.Id == id).FirstOrDefault();

            // List<Commentary> commentaries = commentaryContext.Comments.Where(x => x.Id == id).Include(y => y.ParentId == id).ToList();

           CommentsData commentsList = new CommentsData
            {
                Id = commentary.Id,
                Text = commentary.Text,
                ParentId = commentary.ParentId,
                Answers = new List<CommentsData>(),
            };

            List<Commentary> childComments = commentaryContext.Comments.Where(x => x.ParentId == id).ToList();

            foreach (Commentary comment in childComments)
            {
                commentsList.Answers.Add(new CommentsData
                {
                    Id = comment.Id,
                    Text = comment.Text,
                    ParentId = comment.ParentId,
                });
            }

            return commentsList;
        }


    }
}
