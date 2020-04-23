using DocContentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data
{
    public class CommentaryContext : DbContext
    {
        public CommentaryContext(DbContextOptions<CommentaryContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Commentary> Commentaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commentary>()
                .HasOne(o => o.ParentCommentary)
                .WithMany(m => m.Answers);
        }
    }
}
