using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NewID()"),
                    ProjectName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NewID()"),
                    FullName = table.Column<string>(nullable: true),
                    Profil = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    AdressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_owner_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "Id", "AdressId", "Avatar", "FullName", "Profil" },
                values: new object[] { new Guid("29e0cf3d-6575-42c2-a6f4-8e350fbd40f5"), null, "Avater.jpg", "Ahmed Hassan Abou Zeid", "Junior Asp.net core Developer " });

            migrationBuilder.CreateIndex(
                name: "IX_owner_AdressId",
                table: "owner",
                column: "AdressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "owner");

            migrationBuilder.DropTable(
                name: "portfolioItems");

            migrationBuilder.DropTable(
                name: "Adress");
        }
    }
}
