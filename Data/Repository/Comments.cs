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
        private readonly LawyerContext context;

        public Comments(LawyerContext commentaryContext)
        {
            this.context = commentaryContext;
        }

        public Guid AddComment(CommentaryModel comment)
        {
            comment.Id = Guid.NewGuid();
            comment.UserId = Guid.NewGuid();

            context.Commentaries.Add(comment);
            context.SaveChanges();

            return comment.Id;
        }

        public CommentaryModel ExampleTreeByDictionary(int docId)
        {
            var result = context.Commentaries.Where(x => x.DocId == docId).ToList();
            foreach (var item in result)
            {
                item.Answers = new List<CommentaryModel>();
            }

            var dict = result.ToDictionary(e => e.Id, e => e);
            foreach (var elem in result)
            {
                if (elem.ParentCommentary != null)
                    dict[elem.ParentCommentary.Id].Answers.Add(elem);
            }
            return dict.Values.First(elem => elem.ParentCommentary == null);
        }

        public IEnumerable<RequestComment> GetComments(int docId)
        {
            //ExampleTreeByDictionary(docId);
            var result = context.Commentaries.Where(x => x.DocId == docId).ToList();
            result = result.Where(x => x.ParentCommentary == null).ToList();

            if (result != null && result.Any())
            {
                List<RequestComment> requestList = new List<RequestComment> { };
                foreach (CommentaryModel commentary in result)
                {
                    requestList.Add(GetChilds(commentary));
                }

                return requestList;
            }
            else
                return null;
        }

        public IEnumerable<CommentaryModel> GetComments(Guid userId) => context.Commentaries.Where(x => x.UserId == userId);

        public CommentaryModel GetCommentData(Guid id)
        {

            return context.Commentaries.Include(x => x.Answers).FirstOrDefault(x => x.Id == id);
        }

        public RequestComment GetCommentWithAnswers(Guid id)
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

            var result = context.Commentaries.Include(x => x.Answers).FirstOrDefault(x => x.Id == id);

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

            return GetChilds(result);
        }

        private RequestComment GetChilds(CommentaryModel a)
        {
            var b = new RequestComment
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
