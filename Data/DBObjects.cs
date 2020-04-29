using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DocContentAPI.Models;
using DocContentAPI.Data.Models;

namespace DocContentAPI.Data
{
    public class DBObjects
    {
        public static void Initial(LawyerContext context)
        {

            if (!context.Commentaries.Any())
            {
                Guid parentGuid = Guid.Parse("cfc77d77-4d4c-4514-b632-a80aa7411152");

                List<CommentaryModel> childComments = new List<CommentaryModel>();
                childComments.Add(new CommentaryModel { });
                childComments.Add(new CommentaryModel { });

                var comment = new CommentaryModel { DocId = 1, UserId = Guid.NewGuid(), Id = parentGuid, Answers = childComments };
                context.Commentaries.Add(comment);

                context.SaveChanges();

            }
            if (!context.Bookmarks.Any())
            {
                for (int i = 1; i < 4; i++)
                {
                    var bm = new BookmarkModel
                    {
                        DateAdd = DateTime.Now,
                        DocId = i,
                    };

                    context.Bookmarks.Add(bm);
                }

                context.SaveChanges();
            }
        }
    }
}
