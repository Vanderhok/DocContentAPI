using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocContentAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DocId = table.Column<int>(nullable: false),
                    DateAdd = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    TopicName = table.Column<string>(nullable: true),
                    Pos = table.Column<int>(nullable: false),
                    Cid = table.Column<int>(nullable: false),
                    Changed = table.Column<int>(nullable: false),
                    Notificated = table.Column<int>(nullable: false),
                    Noactive = table.Column<bool>(nullable: false),
                    Preactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
