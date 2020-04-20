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
                Guid[] newGuids = { Guid.NewGuid(), Guid.NewGuid() };
                context.Comments.Add(new Commentary { DocId = 1, UserId = Guid.NewGuid(), ParentId = Guid.Empty, Id= newGuids[0]});
                context.Comments.Add(new Commentary { DocId = 1, UserId = Guid.NewGuid(), ParentId = newGuids[0] });
                context.Comments.Add(new Commentary { DocId = 2, UserId = Guid.NewGuid(), ParentId = newGuids[0] , Id= newGuids[1]});
                context.Comments.Add(new Commentary { DocId = 2, UserId = Guid.NewGuid(), ParentId = newGuids[1] });
                context.Comments.Add(new Commentary { DocId = 2, UserId = Guid.NewGuid(), ParentId = newGuids[1] });

                context.SaveChanges();

            }
        }
    }
}
