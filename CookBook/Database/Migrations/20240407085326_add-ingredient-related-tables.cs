using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class addingredientrelatedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdderId",
                table: "IngredientDetails",
                newName: "UserCookBookId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "IngredientDetails",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                    UserCookBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngridientUsed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(type: "date", nullable: false),
                    RecipeDetailsId = table.Column<int>(type: "int", nullable: false),
                    IngridientDetailsId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngridientUsed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngridientUsed_IngredientDetails_IngridientDetailsId",
                        column: x => x.IngridientDetailsId,
                        principalTable: "IngredientDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngridientUsed_RecipeDetails_RecipeDetailsId",
                        column: x => x.RecipeDetailsId,
                        principalTable: "RecipeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngridientUsed_IngridientDetailsId",
                table: "IngridientUsed",
                column: "IngridientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_IngridientUsed_RecipeDetailsId",
                table: "IngridientUsed",
                column: "RecipeDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngridientUsed");

            migrationBuilder.DropTable(
                name: "RecipeDetails");

            migrationBuilder.RenameColumn(
                name: "UserCookBookId",
                table: "IngredientDetails",
                newName: "AdderId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "IngredientDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
