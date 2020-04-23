using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocContentAPI.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commentaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    Preactive = table.Column<bool>(nullable: false),
                    ParentCommentaryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentaries_Commentaries_ParentCommentaryId",
                        column: x => x.ParentCommentaryId,
                        principalTable: "Commentaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaries_ParentCommentaryId",
                table: "Commentaries",
                column: "ParentCommentaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaries");
        }
    }
}
