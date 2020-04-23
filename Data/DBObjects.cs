using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DocContentAPI.Models;

namespace DocContentAPI.Data
{
    public class DBObjects
    {
        public static void Initial(CommentaryContext context)
        {

            if (!context.Commentaries.Any())
            {
                Guid parentGuid = Guid.Parse("cfc77d77-4d4c-4514-b632-a80aa7411152");

                List<Commentary> childComments = new List<Commentary>();
                childComments.Add(new Commentary { });
                childComments.Add(new Commentary { });

                var comment = new Commentary { DocId = 1, UserId = Guid.NewGuid(), Id = parentGuid, Answers = childComments };
                context.Commentaries.Add(comment);

                context.SaveChanges();

            }
        }
    }
}
