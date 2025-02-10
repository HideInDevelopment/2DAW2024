using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actividad3.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DWES");

            migrationBuilder.CreateTable(
                name: "Colonies",
                schema: "DWES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TelephoneNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    MobileNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colonies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                schema: "DWES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Age = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    TelephoneNumber = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                schema: "DWES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Age = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<double>(type: "float", maxLength: 5, nullable: false),
                    HealthState = table.Column<int>(type: "int", nullable: false),
                    ColonyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cats_Colonies_ColonyId",
                        column: x => x.ColonyId,
                        principalSchema: "DWES",
                        principalTable: "Colonies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColonyPartners",
                schema: "DWES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColonyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColonyPartners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColonyPartners_Colonies_ColonyId",
                        column: x => x.ColonyId,
                        principalSchema: "DWES",
                        principalTable: "Colonies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColonyPartners_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalSchema: "DWES",
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Id",
                schema: "DWES",
                table: "Cats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Name",
                schema: "DWES",
                table: "Cats",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Cat_Race",
                schema: "DWES",
                table: "Cats",
                column: "Race");

            migrationBuilder.CreateIndex(
                name: "IX_Cats_ColonyId",
                schema: "DWES",
                table: "Cats",
                column: "ColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_Colony_Id",
                schema: "DWES",
                table: "Colonies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Colony_Name",
                schema: "DWES",
                table: "Colonies",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyPartners_ColonyId",
                schema: "DWES",
                table: "ColonyPartners",
                column: "ColonyId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonyPartners_PartnerId",
                schema: "DWES",
                table: "ColonyPartners",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_Id",
                schema: "DWES",
                table: "Partners",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_Name",
                schema: "DWES",
                table: "Partners",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats",
                schema: "DWES");

            migrationBuilder.DropTable(
                name: "ColonyPartners",
                schema: "DWES");

            migrationBuilder.DropTable(
                name: "Colonies",
                schema: "DWES");

            migrationBuilder.DropTable(
                name: "Partners",
                schema: "DWES");
        }
    }
}
