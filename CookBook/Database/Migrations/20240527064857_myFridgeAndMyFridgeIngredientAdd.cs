using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class myFridgeAndMyFridgeIngredientAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "UserCookBook",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "RecipeUsed",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "RecipeDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "MealDay",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "MealDay",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "IngredientUsed",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "IngredientDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.CreateTable(
                name: "IngredientComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IngredientDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientComment_IngredientDetails_IngredientDetailsId",
                        column: x => x.IngredientDetailsId,
                        principalTable: "IngredientDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyFridge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCookBookId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFridge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyFridge_UserCookBook_UserCookBookId",
                        column: x => x.UserCookBookId,
                        principalTable: "UserCookBook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyFridgeIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyFridgeId = table.Column<int>(type: "int", nullable: false),
                    IngredientDetailsId = table.Column<int>(type: "int", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFridgeIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyFridgeIngredient_IngredientDetails_IngredientDetailsId",
                        column: x => x.IngredientDetailsId,
                        principalTable: "IngredientDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyFridgeIngredient_MyFridge_MyFridgeId",
                        column: x => x.MyFridgeId,
                        principalTable: "MyFridge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientComment_IngredientDetailsId",
                table: "IngredientComment",
                column: "IngredientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MyFridge_UserCookBookId",
                table: "MyFridge",
                column: "UserCookBookId");

            migrationBuilder.CreateIndex(
                name: "IX_MyFridgeIngredient_IngredientDetailsId",
                table: "MyFridgeIngredient",
                column: "IngredientDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_MyFridgeIngredient_MyFridgeId",
                table: "MyFridgeIngredient",
                column: "MyFridgeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientComment");

            migrationBuilder.DropTable(
                name: "MyFridgeIngredient");

            migrationBuilder.DropTable(
                name: "MyFridge");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "UserCookBook",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "RecipeUsed",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "RecipeDetails",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Day",
                table: "MealDay",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "MealDay",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "IngredientUsed",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                table: "IngredientDetails",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
