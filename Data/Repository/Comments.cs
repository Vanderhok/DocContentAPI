﻿using DocContentAPI.Data;
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
        private readonly CommentaryContext commentaryContext;

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

        public Commentary ExampleTreeByDictionary(int docId)
        {
            var context = commentaryContext.Commentaries.Where(x => x.DocId == docId).ToList();
            foreach (var item in context)
            {
                item.Answers = new List<Commentary>();
            }

            var dict = context.ToDictionary(e => e.Id, e => e);
            foreach (var elem in context)
            {
                if (elem.ParentCommentary != null)
                    dict[elem.ParentCommentary.Id].Answers.Add(elem);
            }
            return dict.Values.First(elem => elem.ParentCommentary == null);
        }

        public IEnumerable<RequestCommentMdl> GetComments(int docId)
        {
            //ExampleTreeByDictionary(docId);
            var context = commentaryContext.Commentaries.Where(x => x.DocId == docId).ToList();
            context = context.Where(x => x.ParentCommentary == null).ToList();

            if (context != null && context.Any())
            {
                List<RequestCommentMdl> requestList = new List<RequestCommentMdl> { };
                foreach (Commentary commentary in context)
                {
                    requestList.Add(GetChilds(commentary));
                }

                return requestList;
            }
            else
                return null;
        }

        public IEnumerable<Commentary> GetComments(Guid userId) => commentaryContext.Commentaries.Where(x => x.UserId == userId);

        public Commentary GetCommentData(Guid id)
        {

            return commentaryContext.Commentaries.Include(x => x.Answers).FirstOrDefault(x => x.Id == id);
        }

        public RequestCommentMdl GetCommentWithAnswers(Guid id)
        {
            #region Example
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
            }
            #endregion

            var context = commentaryContext.Commentaries.Include(x => x.Answers).FirstOrDefault(x => x.Id == id);

            #region Добавление вложенного для проверки
            //List<Commentary> com = new List<Commentary>
            //{
            //    new Commentary 
            //    { 
            //        Id = Guid.Parse("be112f7b-6c79-4d44-7045-08d7e6b1c333"),
            //        ParentCommentary = context.Answers[0],
            //        Text="333"
            //    }
            //};
            //context.Answers[0].Answers = com;
            #endregion

            return GetChilds(context);
        }

        private RequestCommentMdl GetChilds(Commentary a)
        {
            var b = new RequestCommentMdl
            {
                Id = a.Id,
                Text = a.Text
            };

            if (a.Answers != null && a.Answers.Any())
            {
                b.Child = a.Answers.Select(x => GetChilds(x)).ToList();
            }

            return b;
        }
    }
}
