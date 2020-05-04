﻿// <auto-generated />
using System;
using DocContentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocContentAPI.Migrations
{
    [DbContext(typeof(LawyerContext))]
    [Migration("20200429043229_AddFoldersTable")]
    partial class AddFoldersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.2.20159.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DocContentAPI.Data.Models.BookmarkModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Changed")
                        .HasColumnType("int");

                    b.Property<int>("Cid")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocId")
                        .HasColumnType("int");

                    b.Property<Guid>("FolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Noactive")
                        .HasColumnType("bit");

                    b.Property<int>("Notificated")
                        .HasColumnType("int");

                    b.Property<int>("Page")
                        .HasColumnType("int");

                    b.Property<bool>("Preactive")
                        .HasColumnType("bit");

                    b.Property<int>("ScrollPos")
                        .HasColumnType("int");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("View")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("DocContentAPI.Data.Models.FoldersModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentFolderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("DocContentAPI.Models.CommentaryModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Changed")
                        .HasColumnType("int");

                    b.Property<int>("Cid")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdd")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocId")
                        .HasColumnType("int");

                    b.Property<bool>("Noactive")
                        .HasColumnType("bit");

                    b.Property<int>("Notificated")
                        .HasColumnType("int");

                    b.Property<Guid?>("ParentCommentaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Pos")
                        .HasColumnType("int");

                    b.Property<bool>("Preactive")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParentCommentaryId");

                    b.ToTable("Commentaries");
                });

            modelBuilder.Entity("DocContentAPI.Data.Models.FoldersModel", b =>
                {
                    b.HasOne("DocContentAPI.Data.Models.FoldersModel", "ParentFolder")
                        .WithMany("SubFolders")
                        .HasForeignKey("ParentFolderId");
                });

            modelBuilder.Entity("DocContentAPI.Models.CommentaryModel", b =>
                {
                    b.HasOne("DocContentAPI.Models.CommentaryModel", "ParentCommentary")
                        .WithMany("Answers")
                        .HasForeignKey("ParentCommentaryId");
                });
#pragma warning restore 612, 618
        }
    }
}