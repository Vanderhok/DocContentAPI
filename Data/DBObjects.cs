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

            if (!context.Comments.Any())
            {
                context.Comments.Add(new Commentary { DocId = 1, UserId = Guid.NewGuid() });
                context.Comments.Add(new Commentary { DocId = 2, UserId = Guid.NewGuid() });
                context.Comments.Add(new Commentary { DocId = 2, UserId = Guid.NewGuid() });
                context.Comments.Add(new Commentary { DocId = 4, UserId = Guid.NewGuid() });

                context.SaveChanges();

            }
        }
    }
}
