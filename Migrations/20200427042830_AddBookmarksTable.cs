using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocContentAPI.Migrations
{
    public partial class AddBookmarksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FolderId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DocId = table.Column<int>(nullable: false),
                    DateAdd = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TopicName = table.Column<string>(nullable: true),
                    View = table.Column<int>(nullable: false),
                    Page = table.Column<int>(nullable: false),
                    ScrollPos = table.Column<int>(nullable: false),
                    Cid = table.Column<int>(nullable: false),
                    Changed = table.Column<int>(nullable: false),
                    Notificated = table.Column<int>(nullable: false),
                    Noactive = table.Column<bool>(nullable: false),
                    Preactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookmarks");
        }
    }
}
