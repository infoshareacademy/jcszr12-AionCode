using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class IngridienttoIngredientrename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngridientUsed_IngridientDetails_IngridientDetailsId",
                table: "IngridientUsed");

            migrationBuilder.RenameColumn(
                name: "IngridientDetailsId",
                table: "IngridientUsed",
                newName: "IngredientDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngridientUsed_IngridientDetailsId",
                table: "IngridientUsed",
                newName: "IX_IngridientUsed_IngredientDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngridientUsed_IngridientDetails_IngredientDetailsId",
                table: "IngridientUsed",
                column: "IngredientDetailsId",
                principalTable: "IngridientDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngridientUsed_IngridientDetails_IngredientDetailsId",
                table: "IngridientUsed");

            migrationBuilder.RenameColumn(
                name: "IngredientDetailsId",
                table: "IngridientUsed",
                newName: "IngridientDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngridientUsed_IngredientDetailsId",
                table: "IngridientUsed",
                newName: "IX_IngridientUsed_IngridientDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngridientUsed_IngridientDetails_IngridientDetailsId",
                table: "IngridientUsed",
                column: "IngridientDetailsId",
                principalTable: "IngridientDetails",
                principalColumn: "Id");
        }
    }
}
