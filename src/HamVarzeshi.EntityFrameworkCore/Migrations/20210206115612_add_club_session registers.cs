using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HamVarzeshi.Migrations
{
    public partial class add_club_sessionregisters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClubSessionRegisters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClubSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisteredUserId = table.Column<long>(type: "bigint", nullable: false),
                    TotalCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubSessionRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubSessionRegisters_ClubSessions_ClubSessionId",
                        column: x => x.ClubSessionId,
                        principalTable: "ClubSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubSessionRegisters_ClubSessionId",
                table: "ClubSessionRegisters",
                column: "ClubSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubSessionRegisters");
        }
    }
}
