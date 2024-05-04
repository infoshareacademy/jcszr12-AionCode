using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class UserCookBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserCookBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCookBook",
                table: "UserCookBook",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_UserCookBook_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "UserCookBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_UserCookBook_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "UserCookBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_UserCookBook_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "UserCookBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_UserCookBook_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "UserCookBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_UserCookBook_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_UserCookBook_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_UserCookBook_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_UserCookBook_UserId",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCookBook",
                table: "UserCookBook");

            migrationBuilder.RenameTable(
                name: "UserCookBook",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
