using DocContentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data
{
    public class CommentaryContext: DbContext
    {
        public CommentaryContext(DbContextOptions<CommentaryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Commentary> Comments { get; set; }
    }
}
