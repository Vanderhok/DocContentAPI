﻿using DocContentAPI.Data.Models;
using DocContentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocContentAPI.Data
{
    public class LawyerContext : DbContext
    {
        public LawyerContext(DbContextOptions<LawyerContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<CommentaryModel> Commentaries { get; set; }
        public DbSet<BookmarkModel> Bookmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentaryModel>()
                .HasOne(o => o.ParentCommentary)
                .WithMany(m => m.Answers);
        }
    }
}
