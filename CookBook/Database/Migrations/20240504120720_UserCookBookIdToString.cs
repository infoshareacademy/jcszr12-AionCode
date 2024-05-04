using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UserCookBookIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientDetails_UserCookBook_UserCookBookId",
                table: "IngredientDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDay_UserCookBook_UserCookBookId",
                table: "MealDay");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDetails_UserCookBook_UserCookBookId",
                table: "RecipeDetails");

            migrationBuilder.DropTable(
                name: "UserCookBook");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "Users",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UserCookBookId",
                table: "RecipeDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCookBookId",
                table: "MealDay",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCookBookId",
                table: "IngredientDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 13,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 14,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 15,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 16,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 17,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 18,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 19,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 20,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 21,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 22,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 23,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 24,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 25,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 26,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 27,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 28,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 29,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 30,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 31,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 32,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 33,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 34,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 35,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 36,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 37,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 38,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 39,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 40,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 41,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 42,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 43,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 44,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 45,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 46,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 47,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 48,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 49,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 50,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 51,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 52,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 53,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 54,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 55,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 56,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 57,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 58,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 59,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 60,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 61,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 62,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 63,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 64,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 65,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 66,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 67,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 68,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 69,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 70,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 71,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 72,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 73,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 74,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 75,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 76,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 77,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 78,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 79,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 80,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 81,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 82,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 83,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 84,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 85,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 86,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 87,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 88,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 89,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 90,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 91,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 92,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 93,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 94,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 95,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 96,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 97,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 98,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 99,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 100,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 101,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 102,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 103,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 104,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 105,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 106,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 107,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 108,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 109,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 110,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 111,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 112,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 113,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 114,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 115,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 116,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 117,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserCookBookId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserCookBookId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 13,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 14,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 15,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 16,
                column: "UserCookBookId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 17,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 18,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 19,
                column: "UserCookBookId",
                value: "1");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientDetails_Users_UserCookBookId",
                table: "IngredientDetails",
                column: "UserCookBookId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealDay_Users_UserCookBookId",
                table: "MealDay",
                column: "UserCookBookId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDetails_Users_UserCookBookId",
                table: "RecipeDetails",
                column: "UserCookBookId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientDetails_Users_UserCookBookId",
                table: "IngredientDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDay_Users_UserCookBookId",
                table: "MealDay");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDetails_Users_UserCookBookId",
                table: "RecipeDetails");

            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserCookBookId",
                table: "RecipeDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserCookBookId",
                table: "MealDay",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserCookBookId",
                table: "IngredientDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserCookBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "binary(64)", maxLength: 64, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCookBook", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 13,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 14,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 15,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 16,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 17,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 18,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 19,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 20,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 21,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 22,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 23,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 24,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 25,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 26,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 27,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 28,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 29,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 30,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 31,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 32,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 33,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 34,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 35,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 36,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 37,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 38,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 39,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 40,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 41,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 42,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 43,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 44,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 45,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 46,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 47,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 48,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 49,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 50,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 51,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 52,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 53,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 54,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 55,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 56,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 57,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 58,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 59,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 60,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 61,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 62,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 63,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 64,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 65,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 66,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 67,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 68,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 69,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 70,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 71,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 72,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 73,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 74,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 75,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 76,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 77,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 78,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 79,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 80,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 81,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 82,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 83,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 84,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 85,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 86,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 87,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 88,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 89,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 90,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 91,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 92,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 93,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 94,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 95,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 96,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 97,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 98,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 99,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 100,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 101,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 102,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 103,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 104,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 105,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 106,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 107,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 108,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 109,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 110,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 111,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 112,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 113,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 114,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 115,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 116,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 117,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserCookBookId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 9,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 10,
                column: "UserCookBookId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 11,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 12,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 13,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 14,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 15,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 16,
                column: "UserCookBookId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 17,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 18,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 19,
                column: "UserCookBookId",
                value: 1);

            migrationBuilder.InsertData(
                table: "UserCookBook",
                columns: new[] { "Id", "AddDate", "Email", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", new byte[] { 67, 30, 231, 90, 15, 153, 157, 24, 62, 102, 119 }, "Admin", "John Doe" },
                    { 2, new DateTime(2024, 4, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", new byte[] { 79, 154, 61, 35, 37, 60, 53, 207, 72, 193 }, "User", "Alice Smith" },
                    { 3, new DateTime(2024, 4, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), "bob@example.com", new byte[] { 63, 217, 81, 155, 219, 251, 30, 30, 159, 33 }, "User", "Bob Johnson" },
                    { 4, new DateTime(2024, 4, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), "emily@example.com", new byte[] { 71, 105, 73, 203, 169, 193, 181, 121, 187, 42 }, "User", "Emily Brown" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientDetails_UserCookBook_UserCookBookId",
                table: "IngredientDetails",
                column: "UserCookBookId",
                principalTable: "UserCookBook",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealDay_UserCookBook_UserCookBookId",
                table: "MealDay",
                column: "UserCookBookId",
                principalTable: "UserCookBook",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDetails_UserCookBook_UserCookBookId",
                table: "RecipeDetails",
                column: "UserCookBookId",
                principalTable: "UserCookBook",
                principalColumn: "Id");
        }
    }
}
