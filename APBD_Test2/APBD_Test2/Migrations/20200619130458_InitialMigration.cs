using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_Test2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedTypes",
                columns: table => new
                {
                    IdBreedType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedTypes", x => x.IdBreedType);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    IdVolounteer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSupervisor = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    StartingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.IdVolounteer);
                    table.ForeignKey(
                        name: "FK_Volunteers_Volunteers_IdSupervisor",
                        column: x => x.IdSupervisor,
                        principalTable: "Volunteers",
                        principalColumn: "IdVolounteer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    IdPet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBreedType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    IsMale = table.Column<int>(nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    ApproximateDateOfBirth = table.Column<DateTime>(nullable: false),
                    DateAdopted = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.IdPet);
                    table.ForeignKey(
                        name: "FK_Pets_BreedTypes_IdBreedType",
                        column: x => x.IdBreedType,
                        principalTable: "BreedTypes",
                        principalColumn: "IdBreedType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer_Pets",
                columns: table => new
                {
                    IdPet = table.Column<int>(nullable: false),
                    IdVolunteer = table.Column<int>(nullable: false),
                    DateAccepted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer_Pets", x => x.IdPet);
                    table.ForeignKey(
                        name: "FK_Volunteer_Pets_Pets_IdPet",
                        column: x => x.IdPet,
                        principalTable: "Pets",
                        principalColumn: "IdPet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Volunteer_Pets_Volunteers_IdVolunteer",
                        column: x => x.IdVolunteer,
                        principalTable: "Volunteers",
                        principalColumn: "IdVolounteer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_IdBreedType",
                table: "Pets",
                column: "IdBreedType");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_Pets_IdVolunteer",
                table: "Volunteer_Pets",
                column: "IdVolunteer");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_IdSupervisor",
                table: "Volunteers",
                column: "IdSupervisor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteer_Pets");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "BreedTypes");
        }
    }
}
