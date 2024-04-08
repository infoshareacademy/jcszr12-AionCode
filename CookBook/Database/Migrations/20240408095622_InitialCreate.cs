using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userCookBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "binary(64)", maxLength: 64, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCookBook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngridientDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Proteins = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fats = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Carbohydrates = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddDate = table.Column<DateTime>(type: "date", nullable: false),
                    GI = table.Column<int>(type: "int", nullable: false),
                    UserCookBookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngridientDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngridientDetails_userCookBook_UserCookBookId",
                        column: x => x.UserCookBookId,
                        principalTable: "userCookBook",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MealDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "date", nullable: false),
                    AddDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserCookBookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealDay_userCookBook_UserCookBookId",
                        column: x => x.UserCookBookId,
                        principalTable: "userCookBook",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserCookBookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeDetails_userCookBook_UserCookBookId",
                        column: x => x.UserCookBookId,
                        principalTable: "userCookBook",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngridientUsed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(type: "date", nullable: false),
                    RecipeDetailsId = table.Column<int>(type: "int", nullable: true),
                    IngridientDetailsId = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngridientUsed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngridientUsed_IngridientDetails_IngridientDetailsId",
                        column: x => x.IngridientDetailsId,
                        principalTable: "IngridientDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IngridientUsed_RecipeDetails_RecipeDetailsId",
                        column: x => x.RecipeDetailsId,
                        principalTable: "RecipeDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeUsed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeDetailsId = table.Column<int>(type: "int", nullable: true),
                    AddDate = table.Column<DateTime>(type: "date", nullable: false),
                    PartOfDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealDayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeUsed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeUsed_MealDay_MealDayId",
                        column: x => x.MealDayId,
                        principalTable: "MealDay",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeUsed_RecipeDetails_RecipeDetailsId",
                        column: x => x.RecipeDetailsId,
                        principalTable: "RecipeDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngridientDetails_UserCookBookId",
                table: "IngridientDetails",
                column: "UserCookBookId");

            migrationBuilder.CreateIndex(
                name: "IX_IngridientUsed_IngridientDetailsId",
                table: "IngridientUsed",
                column: "IngridientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_IngridientUsed_RecipeDetailsId",
                table: "IngridientUsed",
                column: "RecipeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MealDay_UserCookBookId",
                table: "MealDay",
                column: "UserCookBookId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDetails_UserCookBookId",
                table: "RecipeDetails",
                column: "UserCookBookId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUsed_MealDayId",
                table: "RecipeUsed",
                column: "MealDayId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeUsed_RecipeDetailsId",
                table: "RecipeUsed",
                column: "RecipeDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngridientUsed");

            migrationBuilder.DropTable(
                name: "RecipeUsed");

            migrationBuilder.DropTable(
                name: "IngridientDetails");

            migrationBuilder.DropTable(
                name: "MealDay");

            migrationBuilder.DropTable(
                name: "RecipeDetails");

            migrationBuilder.DropTable(
                name: "userCookBook");
        }
    }
}
