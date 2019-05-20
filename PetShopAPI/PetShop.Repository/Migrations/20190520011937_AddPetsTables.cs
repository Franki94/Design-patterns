using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop.Repository.Migrations
{
    public partial class AddPetsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    owner_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    first_name = table.Column<string>(maxLength: 100, nullable: false),
                    last_name = table.Column<string>(maxLength: 100, nullable: false),
                    middle_name = table.Column<string>(maxLength: 30, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    email = table.Column<string>(maxLength: 200, nullable: false),
                    address = table.Column<string>(maxLength: 250, nullable: false),
                    mobile_phone = table.Column<string>(maxLength: 10, nullable: false),
                    home_phone = table.Column<string>(maxLength: 10, nullable: true),
                    work_phone = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.owner_id);
                });

            migrationBuilder.CreateTable(
                name: "pet_types",
                columns: table => new
                {
                    pet_type = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_types", x => x.pet_type);
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    pet_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    family_last_name = table.Column<string>(maxLength: 100, nullable: false),
                    raise = table.Column<string>(maxLength: 70, nullable: false),
                    age = table.Column<int>(nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    pet_type = table.Column<int>(nullable: false),
                    size = table.Column<double>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.pet_id);
                    table.ForeignKey(
                        name: "fk_pets__pet_type",
                        column: x => x.pet_type,
                        principalTable: "pet_types",
                        principalColumn: "pet_type",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pet_owners",
                columns: table => new
                {
                    pet_id = table.Column<int>(nullable: false),
                    owner_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_owners", x => new { x.pet_id, x.owner_id });
                    table.ForeignKey(
                        name: "fk_pet_owner__owners",
                        column: x => x.owner_id,
                        principalTable: "owners",
                        principalColumn: "owner_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pet_owner__pets",
                        column: x => x.pet_id,
                        principalTable: "pets",
                        principalColumn: "pet_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pet_owners_owner_id",
                table: "pet_owners",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_pets_pet_type",
                table: "pets",
                column: "pet_type");

            migrationBuilder.InsertData("pet_types", new string[] { "pet_type", "description"}, new object[]{ 1, "cats" });
            migrationBuilder.InsertData("pet_types", new string[] { "pet_type", "description" }, new object[] { 2, "dogs" });
            migrationBuilder.InsertData("pet_types", new string[] { "pet_type", "description" }, new object[] { 3, "birds" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pet_owners");

            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "pet_types");
        }
    }
}
