using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class IngridienttoIngredientrenameagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngridientDetails_userCookBook_UserCookBookId",
                table: "IngridientDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_IngridientUsed_IngridientDetails_IngredientDetailsId",
                table: "IngridientUsed");

            migrationBuilder.DropForeignKey(
                name: "FK_IngridientUsed_RecipeDetails_RecipeDetailsId",
                table: "IngridientUsed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngridientUsed",
                table: "IngridientUsed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngridientDetails",
                table: "IngridientDetails");

            migrationBuilder.RenameTable(
                name: "IngridientUsed",
                newName: "IngredientUsed");

            migrationBuilder.RenameTable(
                name: "IngridientDetails",
                newName: "IngredientDetails");

            migrationBuilder.RenameIndex(
                name: "IX_IngridientUsed_RecipeDetailsId",
                table: "IngredientUsed",
                newName: "IX_IngredientUsed_RecipeDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngridientUsed_IngredientDetailsId",
                table: "IngredientUsed",
                newName: "IX_IngredientUsed_IngredientDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngridientDetails_UserCookBookId",
                table: "IngredientDetails",
                newName: "IX_IngredientDetails_UserCookBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientUsed",
                table: "IngredientUsed",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientDetails",
                table: "IngredientDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientDetails_userCookBook_UserCookBookId",
                table: "IngredientDetails",
                column: "UserCookBookId",
                principalTable: "userCookBook",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUsed_IngredientDetails_IngredientDetailsId",
                table: "IngredientUsed",
                column: "IngredientDetailsId",
                principalTable: "IngredientDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientUsed_RecipeDetails_RecipeDetailsId",
                table: "IngredientUsed",
                column: "RecipeDetailsId",
                principalTable: "RecipeDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientDetails_userCookBook_UserCookBookId",
                table: "IngredientDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUsed_IngredientDetails_IngredientDetailsId",
                table: "IngredientUsed");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientUsed_RecipeDetails_RecipeDetailsId",
                table: "IngredientUsed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientUsed",
                table: "IngredientUsed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientDetails",
                table: "IngredientDetails");

            migrationBuilder.RenameTable(
                name: "IngredientUsed",
                newName: "IngridientUsed");

            migrationBuilder.RenameTable(
                name: "IngredientDetails",
                newName: "IngridientDetails");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientUsed_RecipeDetailsId",
                table: "IngridientUsed",
                newName: "IX_IngridientUsed_RecipeDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientUsed_IngredientDetailsId",
                table: "IngridientUsed",
                newName: "IX_IngridientUsed_IngredientDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientDetails_UserCookBookId",
                table: "IngridientDetails",
                newName: "IX_IngridientDetails_UserCookBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngridientUsed",
                table: "IngridientUsed",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngridientDetails",
                table: "IngridientDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngridientDetails_userCookBook_UserCookBookId",
                table: "IngridientDetails",
                column: "UserCookBookId",
                principalTable: "userCookBook",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngridientUsed_IngridientDetails_IngredientDetailsId",
                table: "IngridientUsed",
                column: "IngredientDetailsId",
                principalTable: "IngridientDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngridientUsed_RecipeDetails_RecipeDetailsId",
                table: "IngridientUsed",
                column: "RecipeDetailsId",
                principalTable: "RecipeDetails",
                principalColumn: "Id");
        }
    }
}
