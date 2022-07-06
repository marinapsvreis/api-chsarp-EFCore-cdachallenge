using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_DOTNET.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_criminal_code",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Penalty = table.Column<decimal>(type: "numeric", nullable: false),
                    PrisionTime = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateUserId = table.Column<int>(type: "integer", nullable: false),
                    UpdateUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_criminal_code", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_criminal_code_tb_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tb_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_criminal_code_tb_user_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_criminal_code_tb_user_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_criminal_code_CreateUserId",
                table: "tb_criminal_code",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_criminal_code_StatusId",
                table: "tb_criminal_code",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_criminal_code_UpdateUserId",
                table: "tb_criminal_code",
                column: "UpdateUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_criminal_code");

            migrationBuilder.DropTable(
                name: "tb_status");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}
