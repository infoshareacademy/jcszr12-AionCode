using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class IngredientDetailsUserCookBookRenameAndDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientDetails_userCookBook_UserCookBookId",
                table: "IngredientDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDay_userCookBook_UserCookBookId",
                table: "MealDay");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeDetails_userCookBook_UserCookBookId",
                table: "RecipeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userCookBook",
                table: "userCookBook");

            migrationBuilder.RenameTable(
                name: "userCookBook",
                newName: "UserCookBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCookBook",
                table: "UserCookBook",
                column: "Id");

            migrationBuilder.InsertData(
                table: "UserCookBook",
                columns: new[] { "Id", "AddDate", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", "John Doe", new byte[] { 67, 30, 231, 90, 15, 153, 157, 24, 62, 102, 119 }, "Admin" },
                    { 2, new DateTime(2024, 4, 17, 11, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", "Alice Smith", new byte[] { 79, 154, 61, 35, 37, 60, 53, 207, 72, 193 }, "User" },
                    { 3, new DateTime(2024, 4, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), "bob@example.com", "Bob Johnson", new byte[] { 63, 217, 81, 155, 219, 251, 30, 30, 159, 33 }, "User" },
                    { 4, new DateTime(2024, 4, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), "emily@example.com", "Emily Brown", new byte[] { 71, 105, 73, 203, 169, 193, 181, 121, 187, 42 }, "User" }
                });

            migrationBuilder.InsertData(
                table: "IngredientDetails",
                columns: new[] { "Id", "AddDate", "Calories", "Carbohydrates", "Description", "Fats", "GI", "ImagePath", "Name", "Proteins", "Type", "UserCookBookId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 17, 10, 30, 0, 0, DateTimeKind.Unspecified), 23.0m, 3.63m, "Marchewka jest warzywem o pomarańczowym kolorze i słodkim smaku.", 0.39m, 35, "Marchewka.png", "Marchewka", 2.86m, "Warzywa", 1 },
                    { 2, new DateTime(2024, 4, 17, 11, 15, 0, 0, DateTimeKind.Unspecified), 18.0m, 3.9m, "Pomidory są czerwonymi owocami o świeżym smaku i soczystej konsystencji.", 0.2m, 15, "Pomidory.png", "Pomidory", 0.88m, "Warzywa", 2 },
                    { 3, new DateTime(2024, 4, 17, 9, 45, 0, 0, DateTimeKind.Unspecified), 23.0m, 3.63m, "Szpinak jest zielonym liściastym warzywem o charakterystycznym smaku.", 0.39m, 15, "Szpinak.png", "Szpinak", 2.86m, "Warzywa", 3 },
                    { 4, new DateTime(2024, 4, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), 40.0m, 9.34m, "Cebula to warzywo o ostrym smaku i charakterystycznym zapachu.", 0.1m, 10, "Cebula.png", "Cebula", 1.1m, "Warzywa", 4 },
                    { 5, new DateTime(2024, 4, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), 31.0m, 6.0m, "Papryka to warzywo o różnych kolorach i słodkim smaku.", 0.3m, 20, "Papryka.png", "Papryka", 1.0m, "Warzywa", 1 },
                    { 6, new DateTime(2024, 4, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), 27.0m, 4.8m, "Pietruszka to warzywo o intensywnym aromacie i lekko korzennym smaku.", 0.3m, 10, "Pietruszka.png", "Pietruszka", 1.2m, "Warzywa", 2 },
                    { 7, new DateTime(2024, 4, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), 43.0m, 9.6m, "Buraki to warzywa o intensywnym czerwonym kolorze i słodkim smaku.", 0.1m, 40, "Buraki.png", "Buraki", 1.6m, "Warzywa", 3 },
                    { 8, new DateTime(2024, 4, 17, 15, 0, 0, 0, DateTimeKind.Unspecified), 25.0m, 4.97m, "Kalafior to warzywo o delikatnym smaku i chrupiącej konsystencji.", 0.3m, 15, "Kalafior.png", "Kalafior", 1.9m, "Warzywa", 4 },
                    { 9, new DateTime(2024, 4, 17, 16, 0, 0, 0, DateTimeKind.Unspecified), 86.0m, 19.0m, "Kukurydza to warzywo o słodkim smaku i chrupiących ziarnach.", 1.2m, 50, "Kukurydza.png", "Kukurydza", 3.2m, "Warzywa", 1 },
                    { 10, new DateTime(2024, 4, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), 34.0m, 6.6m, "Brokuły to warzywa o intensywno-zielonym kolorze i chrupiących różyczkach.", 0.4m, 15, "Brokuły.png", "Brokuły", 2.8m, "Warzywa", 2 },
                    { 11, new DateTime(2024, 4, 17, 18, 0, 0, 0, DateTimeKind.Unspecified), 16.0m, 3.4m, "Rzodkiewka to warzywo o ostrym smaku i charakterystycznym czerwonym kolorze.", 0.1m, 15, "Rzodkiewka.png", "Rzodkiewka", 0.7m, "Warzywa", 3 },
                    { 12, new DateTime(2024, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), 26.0m, 6.5m, "Dynia to warzywo o intensywnym pomarańczowym kolorze i słodkim smaku.", 0.1m, 75, "Dynia.png", "Dynia", 1.0m, "Warzywa", 4 },
                    { 13, new DateTime(2024, 4, 17, 20, 0, 0, 0, DateTimeKind.Unspecified), 15.0m, 3.6m, "Ogórek to warzywo o charakterystycznym zielonym kolorze i świeżym smaku.", 0.1m, 10, "Ogórek.png", "Ogórek", 0.7m, "Warzywa", 1 },
                    { 14, new DateTime(2024, 4, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 20.0m, 3.4m, "Szparagi to warzywo o delikatnym smaku i charakterystycznym wyglądzie.", 0.1m, 15, "Szparagi.png", "Szparagi", 2.2m, "Warzywa", 2 },
                    { 15, new DateTime(2024, 4, 17, 22, 0, 0, 0, DateTimeKind.Unspecified), 149.0m, 33.06m, "Czosnek to warzywo o intensywnym smaku i aromacie.", 0.5m, 10, "Czosnek.png", "Czosnek", 6.36m, "Warzywa", 3 },
                    { 16, new DateTime(2024, 4, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 31.0m, 6.0m, "Fasola to warzywo o charakterystycznym smaku i konsystencji.", 0.5m, 30, "Fasola.png", "Fasola", 2.0m, "Warzywa", 4 },
                    { 17, new DateTime(2024, 4, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), 27.0m, 5.0m, "Kapusta to warzywo o charakterystycznym smaku i konsystencji.", 0.5m, 15, "Kapusta.png", "Kapusta", 1.3m, "Warzywa", 1 },
                    { 18, new DateTime(2024, 4, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), 16.0m, 3.4m, "Szczypiorek to warzywo o intensywnym smaku i aromacie.", 0.2m, 10, "Szczypiorek.png", "Szczypiorek", 1.0m, "Warzywa", 2 },
                    { 19, new DateTime(2024, 4, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), 31.0m, 7.3m, "Por to warzywo o delikatnym smaku i konsystencji.", 0.3m, 15, "Por.png", "Por", 1.5m, "Warzywa", 3 },
                    { 20, new DateTime(2024, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), 25.0m, 5.7m, "Bakłażan to warzywo o fioletowym kolorze i delikatnym smaku.", 0.2m, 10, "Bakłażan.png", "Bakłażan", 1.0m, "Warzywa", 4 },
                    { 21, new DateTime(2024, 4, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), 28.0m, 4.9m, "Rzepa to warzywo o intensywnym smaku i charakterystycznym zapachu.", 0.3m, 15, "Rzepa.png", "Rzepa", 1.1m, "Warzywa", 1 },
                    { 22, new DateTime(2024, 4, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), 17.0m, 3.1m, "Cukinia to warzywo o zielonym kolorze i delikatnym smaku.", 0.1m, 10, "Cukinia.png", "Cukinia", 1.2m, "Warzywa", 2 },
                    { 23, new DateTime(2024, 4, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), 30.0m, 6.8m, "Szalotka to warzywo o intensywnym smaku i aromacie.", 0.2m, 15, "Szalotka.png", "Szalotka", 1.3m, "Warzywa", 3 },
                    { 24, new DateTime(2024, 4, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 57.0m, 15.0m, "Gruszka to owoc o soczystym wnętrzu i słodkim smaku.", 0.1m, 35, "Gruszka.png", "Gruszka", 0.4m, "Owoce", 4 },
                    { 25, new DateTime(2024, 4, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), 50.0m, 12.0m, "Wiśnia to owoc o intensywnym smaku i kwaśnym posmaku.", 0.3m, 40, "Wiśnia.png", "Wiśnia", 1.0m, "Owoce", 1 },
                    { 26, new DateTime(2024, 4, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), 32.0m, 7.7m, "Truskawka to owoc o intensywnym czerwonym kolorze i słodkim smaku.", 0.4m, 25, "Truskawka.png", "Truskawka", 0.8m, "Owoce", 2 },
                    { 27, new DateTime(2024, 4, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), 30.0m, 8.0m, "Arbuz to owoc o soczystym wnętrzu i słodkim smaku.", 0.2m, 75, "Arbuz.png", "Arbuz", 0.6m, "Owoce", 3 },
                    { 28, new DateTime(2024, 4, 18, 14, 0, 0, 0, DateTimeKind.Unspecified), 52.0m, 5.4m, "Malina to owoc o intensywnym smaku i charakterystycznym czerwonym kolorze.", 0.7m, 25, "Malina.png", "Malina", 1.3m, "Owoce", 4 },
                    { 29, new DateTime(2024, 4, 18, 15, 0, 0, 0, DateTimeKind.Unspecified), 50.0m, 13.1m, "Ananas to egzotyczny owoc o soczystym wnętrzu i słodko-kwaśnym smaku.", 0.1m, 50, "Ananas.png", "Ananas", 0.5m, "Owoce", 1 },
                    { 30, new DateTime(2024, 4, 18, 16, 0, 0, 0, DateTimeKind.Unspecified), 39.0m, 9.5m, "Brzoskwinia to owoc o delikatnym smaku i soczystym wnętrzu.", 0.2m, 30, "Brzoskwinia.png", "Brzoskwinia", 0.9m, "Owoce", 2 },
                    { 31, new DateTime(2024, 4, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), 53.0m, 12.9m, "Mandarynka to owoc o delikatnym smaku i soczystym wnętrzu.", 0.2m, 40, "Mandarynka.png", "Mandarynka", 0.8m, "Owoce", 3 },
                    { 32, new DateTime(2024, 4, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 69.0m, 18.1m, "Winogrono to owoc o soczystym wnętrzu i słodkim smaku.", 0.2m, 45, "Winogrono.png", "Winogrono", 0.7m, "Owoce", 4 },
                    { 33, new DateTime(2024, 4, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 46.0m, 11.7m, "Śliwka to owoc o soczystym wnętrzu i słodkim smaku.", 0.2m, 30, "Śliwka.png", "Śliwka", 0.7m, "Owoce", 1 },
                    { 34, new DateTime(2024, 4, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), 89.0m, 22.8m, "Brązowy banan to owoc o intensywnym smaku i aromacie.", 0.3m, 60, "Brązowy Banan.png", "Brązowy Banan", 1.1m, "Owoce", 2 },
                    { 35, new DateTime(2024, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 71.0m, 15.9m, "Kumquat to owoc o intensywnym smaku i aromacie.", 0.9m, 40, "Kumquat.png", "Kumquat", 2.6m, "Owoce", 3 },
                    { 36, new DateTime(2024, 4, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), 66.0m, 16.5m, "Liczi to owoc o delikatnym smaku i soczystym wnętrzu.", 0.4m, 50, "Liczi.png", "Liczi", 0.8m, "Owoce", 4 },
                    { 37, new DateTime(2024, 4, 18, 23, 0, 0, 0, DateTimeKind.Unspecified), 83.0m, 18.7m, "Granat to owoc o soczystym wnętrzu i słodko-kwaśnym smaku.", 1.2m, 35, "Granat.png", "Granat", 1.7m, "Owoce", 1 },
                    { 38, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.0m, 14.7m, "Kiwi to owoc o intensywnym zielonym wnętrzu i słodkim smaku.", 0.5m, 50, "Kiwi.png", "Kiwi", 1.1m, "Owoce", 2 },
                    { 39, new DateTime(2024, 4, 19, 1, 0, 0, 0, DateTimeKind.Unspecified), 29.0m, 9.3m, "Cytryna to owoc o intensywnym kwaśnym smaku.", 0.3m, 20, "Cytryna.png", "Cytryna", 1.1m, "Owoce", 3 },
                    { 40, new DateTime(2024, 4, 19, 2, 0, 0, 0, DateTimeKind.Unspecified), 34.0m, 8.6m, "Melon to owoc o soczystym wnętrzu i słodkim smaku.", 0.2m, 65, "Melon.png", "Melon", 0.8m, "Owoce", 4 },
                    { 41, new DateTime(2024, 4, 19, 3, 0, 0, 0, DateTimeKind.Unspecified), 38.0m, 9.6m, "Pomelo to owoc o soczystym wnętrzu i słodko-kwaśnym smaku.", 0.1m, 30, "Pomelo.png", "Pomelo", 0.8m, "Owoce", 1 },
                    { 42, new DateTime(2024, 4, 19, 4, 0, 0, 0, DateTimeKind.Unspecified), 74.0m, 19.2m, "Figa to owoc o intensywnym smaku i soczystym wnętrzu.", 0.3m, 35, "Figa.png", "Figa", 0.8m, "Owoce", 2 },
                    { 43, new DateTime(2024, 4, 19, 5, 0, 0, 0, DateTimeKind.Unspecified), 68.0m, 14.3m, "Guawa to owoc o intensywnym smaku i aromacie.", 0.9m, 40, "Guawa.png", "Guawa", 2.6m, "Owoce", 3 },
                    { 44, new DateTime(2024, 4, 19, 6, 0, 0, 0, DateTimeKind.Unspecified), 60.0m, 14.8m, "Mango to owoc o soczystym wnętrzu i intensywnym słodkim smaku.", 0.4m, 55, "Mango.png", "Mango", 0.8m, "Owoce", 4 },
                    { 45, new DateTime(2024, 4, 19, 7, 0, 0, 0, DateTimeKind.Unspecified), 81.0m, 18.7m, "Pomarańczowy granat to owoc o soczystym wnętrzu i słodkim smaku.", 1.1m, 50, "omarańczowy Granat.png", "Pomarańczowy Granat", 1.6m, "Owoce", 1 },
                    { 46, new DateTime(2024, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), 47.0m, 12.3m, "Świeża figa to owoc o intensywnym smaku i aromacie.", 0.3m, 35, "Świeża Fig.png", "Świeża Fig", 0.8m, "Owoce", 2 },
                    { 47, new DateTime(2024, 4, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), 79.0m, 17.2m, "Malinowy granat to owoc o soczystym wnętrzu i intensywnym smaku.", 1.0m, 45, "Malinowy Granat.png", "Malinowy Granat", 1.5m, "Owoce", 3 },
                    { 48, new DateTime(2024, 4, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), 265.0m, 54.6m, "Bagietka to rodzaj pieczywa charakteryzującego się chrupiącą skórką i miękkim wnętrzem.", 0.9m, 60, "Bagietka.png", "Bagietka", 8.2m, "Pieczywo", 1 },
                    { 49, new DateTime(2024, 4, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), 211.0m, 42.4m, "Chleb żytni to pieczywo wytwarzane z mąki żytniej, charakteryzujące się intensywnym smakiem.", 1.2m, 45, "Chleb żytni.png", "Chleb żytni", 5.8m, "Pieczywo", 2 },
                    { 50, new DateTime(2024, 4, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), 265.0m, 52.0m, "Bułka to małe okrągłe bochenki pieczywa, zazwyczaj chrupiące na zewnątrz i miękkie wewnątrz.", 1.0m, 70, "Bułka.png", "Bułka", 9.0m, "Pieczywo", 3 },
                    { 51, new DateTime(2024, 4, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), 245.0m, 52.0m, "Bagel to rodzaj pierścienia pieczywa, zazwyczaj ugotowanego przed pieczeniem, charakteryzujący się gładką skórką i miękkim wnętrzem.", 1.0m, 70, "Bagel.png", "Bagel", 9.0m, "Pieczywo", 4 },
                    { 52, new DateTime(2024, 4, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), 406.0m, 51.0m, "Croissant to francuskie pieczywo w kształcie półksiężyca, charakteryzujące się chrupiącą skorupką i miękkim wnętrzem.", 20.0m, 45, "Croissant.png", "Croissant", 8.5m, "Pieczywo", 1 },
                    { 53, new DateTime(2024, 4, 19, 15, 0, 0, 0, DateTimeKind.Unspecified), 250.0m, 55.0m, "Pumpernikiel to ciemne, gęste pieczywo o intensywnym smaku, tradycyjne dla kuchni niemieckiej i polskiej.", 1.5m, 55, "Pumpernikiel.png", "Pumpernikiel", 6.0m, "Pieczywo", 2 },
                    { 54, new DateTime(2024, 4, 19, 16, 0, 0, 0, DateTimeKind.Unspecified), 250.0m, 30.0m, "Focaccia to włoskie pieczywo płaskie, charakteryzujące się obfitością oliwy z oliwek i aromatycznymi ziołami.", 12.0m, 70, "Focaccia.png", "Focaccia", 7.0m, "Pieczywo", 3 },
                    { 55, new DateTime(2024, 4, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), 275.0m, 55.0m, "Pita to spłaszczona bułka pieczona na bazie mąki pszennej, używana głównie w kuchni śródziemnomorskiej.", 1.0m, 70, "Pita.png", "Pita", 9.0m, "Pieczywo", 4 },
                    { 56, new DateTime(2024, 4, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 206.0m, 0.0m, "Łosoś to rodzaj ryby morskiej, bogaty w kwasy tłuszczowe omega-3 i białko.", 13.0m, 0, "Łosoś.png", "Łosoś", 20.0m, "Ryby", 1 },
                    { 57, new DateTime(2024, 4, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 144.0m, 0.0m, "Tuńczyk to duża, oceaniczna ryba charakteryzująca się cennym białkiem i niską zawartością tłuszczu.", 1.0m, 0, "Tuńczyk.png", "Tuńczyk", 29.0m, "Ryby", 2 },
                    { 58, new DateTime(2024, 4, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), 82.0m, 0.0m, "Dorsz to popularna ryba morska o białym mięsie, charakteryzująca się delikatnym smakiem.", 0.7m, 0, "Dorsz.png", "Dorsz", 18.0m, "Ryby", 3 },
                    { 59, new DateTime(2024, 4, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), 210.0m, 0.0m, "Śledź to mała, tłusta ryba morska popularna w kuchni skandynawskiej, charakteryzująca się intensywnym smakiem.", 14.0m, 0, "Śledź.png", "Śledź", 19.0m, "Ryby", 4 },
                    { 60, new DateTime(2024, 4, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), 210.0m, 0.0m, "Anchovies to małe, powszechne ryby słonowodne z rodziny Engraulidae, które są używane jako jedzenie dla ludzi i przynęty rybne.", 14.0m, 0, "Anchovies.png", "Anchovies", 19.0m, "Ryby", 1 },
                    { 61, new DateTime(2024, 4, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), 305.0m, 0.0m, "Makrela to rodzaj ryby morskiej, która jest bogata w witaminę D, białko i kwasy tłuszczowe omega-3.", 25.0m, 0, "Makrela.png", "Makrela", 18.0m, "Ryby", 2 },
                    { 62, new DateTime(2024, 4, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), 208.0m, 0.0m, "Sardynki to małe, tłuste ryby, które często są podawane w puszkach i są bogate w kwasy tłuszczowe omega-3.", 11.0m, 0, "Sardynki.png", "Sardynki", 25.0m, "Ryby", 3 },
                    { 63, new DateTime(2024, 4, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), 168.0m, 0.0m, "Pstrąg to gatunek ryby słodkowodnej o kolorowych rysunkach i delikatnym mięsie.", 8.0m, 0, "Pstrąg.png", "Pstrąg", 22.0m, "Ryby", 4 },
                    { 64, new DateTime(2024, 4, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), 337.0m, 0.0m, "Kaczka to mięso drobiowe pochodzące z kaczki, które jest bogate w białko i ma intensywny smak.", 28.0m, 0, "Kaczka.png", "Kaczka", 16.0m, "Mięsa", 2 },
                    { 65, new DateTime(2024, 4, 21, 16, 0, 0, 0, DateTimeKind.Unspecified), 242.0m, 0.0m, "Jagnięcina to mięso pochodzące z młodej owcy, charakteryzujące się delikatnym smakiem i soczystą konsystencją.", 17.0m, 0, "Jagnięcina.png", "Jagnięcina", 20.0m, "Mięsa", 3 },
                    { 66, new DateTime(2024, 4, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), 238.0m, 0.0m, "Gęś to mięso drobiowe pochodzące z gęsi, które charakteryzuje się intensywnym smakiem i bogatym zapachem.", 19.0m, 0, "Gęś.png", "Gęś", 16.0m, "Mięsa", 4 },
                    { 67, new DateTime(2024, 4, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), 301.0m, 0.0m, "Kiełbasa to wędliny mięsne charakteryzujące się różnymi smakami i konsystencjami.", 27.0m, 0, "Kiełbasa.png", "Kiełbasa", 13.0m, "Mięsa", 1 },
                    { 68, new DateTime(2024, 4, 21, 19, 0, 0, 0, DateTimeKind.Unspecified), 123.0m, 0.0m, "Schab to popularne mięso wieprzowe, które jest bogate w białko i niskotłuszczowe.", 3.1m, 0, "Schab.png", "Schab", 22.0m, "Mięsa", 2 },
                    { 69, new DateTime(2024, 4, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), 225.0m, 0.0m, "Żeberka to popularne mięso wieprzowe, które jest bogate w białko i niskotłuszczowe.", 17.0m, 0, "Żeberka.png", "Żeberka", 15.0m, "Mięsa", 3 },
                    { 70, new DateTime(2024, 4, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), 22.0m, 3.1m, "Pieczarki to popularne grzyby spożywcze o delikatnym smaku i mięsistej konsystencji.", 0.3m, 10, "Pieczarki.png", "Pieczarki", 3.1m, "Grzyby", 1 },
                    { 71, new DateTime(2024, 4, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 35.0m, 5.0m, "Kurki to grzyby leśne o intensywnym smaku i charakterystycznym żółtym kolorze.", 0.6m, 10, "Kurki.png", "Kurki", 3.6m, "Grzyby", 2 },
                    { 72, new DateTime(2024, 4, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), 27.0m, 3.9m, "Podgrzybki to popularne grzyby leśne o intensywnym smaku i aromacie.", 0.5m, 10, "Podgrzybki.png", "Podgrzybki", 2.8m, "Grzyby", 3 },
                    { 73, new DateTime(2024, 4, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), 30.0m, 4.1m, "Borowiki to popularne grzyby leśne o intensywnym smaku i mięsistej konsystencji.", 0.5m, 10, "Borowiki.png", "Borowiki", 3.1m, "Grzyby", 4 },
                    { 74, new DateTime(2024, 4, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 19.0m, 2.7m, "Kaniula to grzyb leśny o intensywnym smaku i chrupiącej konsystencji.", 0.2m, 10, "Kaniula.png", "Kaniula", 1.8m, "Grzyby", 1 },
                    { 75, new DateTime(2024, 4, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 0.0m, "Muchomor to grzyb leśny o intensywnym smaku i toksycznych właściwościach.", 0.0m, 0, "Muchomor.png", "Muchomor", 0.0m, "Grzyby", 2 },
                    { 76, new DateTime(2024, 4, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), 31.0m, 4.1m, "Kozaki to grzyby leśne o intensywnym smaku i mięsistej konsystencji.", 0.6m, 10, "Kozaki.png", "Kozaki", 3.3m, "Grzyby", 3 },
                    { 77, new DateTime(2024, 4, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 22.0m, 3.5m, "Pieszkot to grzyb leśny o intensywnym smaku i aromacie.", 0.4m, 10, "Pieszkot.png", "Pieszkot", 2.8m, "Grzyby", 4 },
                    { 78, new DateTime(2024, 4, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), 28.0m, 4.2m, "Maślak to grzyb leśny o intensywnym smaku i aromacie.", 0.5m, 10, "Maślak.png", "Maślak", 2.9m, "Grzyby", 1 },
                    { 79, new DateTime(2024, 4, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 24.0m, 3.8m, "Gołąbki to grzyb leśny o intensywnym smaku i charakterystycznym kształcie.", 0.4m, 10, "Gołąbki.png", "Gołąbki", 3.0m, "Grzyby", 2 },
                    { 80, new DateTime(2024, 4, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), 26.0m, 3.9m, "Opieńki to grzyby leśne o intensywnym smaku i aromacie.", 0.4m, 10, "Opieńki.png", "Opieńki", 3.1m, "Grzyby", 3 },
                    { 81, new DateTime(2024, 4, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 2.0m, 0.3m, "Kawa to popularny napój sporządzany z palonych i zmielonych ziaren kawowca.", 0.0m, 0, "Kawa.png", "Kawa", 0.1m, "Napoje", 1 },
                    { 82, new DateTime(2024, 4, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), 1.0m, 0.3m, "Herbata to napój wytwarzany z suszonych liści roślin.", 0.0m, 0, "Herbata.png", "Herbata", 0.0m, "Napoje", 2 },
                    { 83, new DateTime(2024, 4, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 0.0m, "Woda to bezbarwna ciecz, która stanowi podstawowy składnik organizmu ludzkiego.", 0.0m, 0, "Woda.png", "Woda", 0.0m, "Napoje", 3 },
                    { 84, new DateTime(2024, 4, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), 45.0m, 10.4m, "Sok pomarańczowy to napój otrzymywany z wyciśniętych owoców pomarańczy.", 0.2m, 50, "Sok pomarańczowy.png", "Sok pomarańczowy", 0.7m, "Napoje", 4 },
                    { 85, new DateTime(2024, 4, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), 42.0m, 10.6m, "Cola to gazowany napój o smaku karmelowym, zawierający kofeinę.", 0.0m, 65, "Cola.png", "Cola", 0.0m, "Napoje", 1 },
                    { 86, new DateTime(2024, 4, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), 29.0m, 7.8m, "Lemoniada to napój otrzymywany z wyciśniętego soku z cytryny wymieszanego z wodą i cukrem.", 0.1m, 24, "Lemoniada.png", "Lemoniada", 0.3m, "Napoje", 2 },
                    { 87, new DateTime(2024, 4, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), 42.0m, 5.0m, "Mleko to biały płyn produkowany przez ssaki, stanowiący podstawowy pokarm niemowląt.", 1.0m, 30, "Mleko.png", "Mleko", 3.4m, "Napoje", 3 },
                    { 88, new DateTime(2024, 4, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), 43.0m, 3.6m, "Piwo to alkoholowy napój fermentowany wytwarzany z jęczmienia lub innych zbóż.", 0.0m, 55, "Piwo.png", "Piwo", 0.5m, "Napoje", 4 },
                    { 89, new DateTime(2024, 4, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), 250.0m, 0.0m, "Whisky to alkoholowy napój destylowany wytwarzany z różnych zbożowych surowców.", 0.0m, 0, "Whisky.png", "Whisky", 0.0m, "Napoje", 1 },
                    { 90, new DateTime(2024, 4, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 45.0m, 10.5m, "Sok jabłkowy to napój otrzymywany z wyciśniętych owoców jabłka.", 0.0m, 40, "Sok jabłkowy.png", "Sok jabłkowy", 0.4m, "Napoje", 2 },
                    { 91, new DateTime(2024, 4, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), 120.0m, 26.0m, "Koktajl bananowy to napój mleczny o smaku bananowym, często dodawane są do niego inne owoce.", 0.5m, 40, "Koktajl bananowy.png", "Koktajl bananowy", 1.5m, "Napoje", 3 },
                    { 92, new DateTime(2024, 4, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 402.0m, 1.3m, "Ser żółty to rodzaj sera produkowanego z mleka krowiego, charakteryzujący się żółtym kolorem i specyficznym smakiem.", 33.0m, 0, "Ser żółty.png", "Ser żółty", 25.0m, "Nabiał", 1 },
                    { 93, new DateTime(2024, 4, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), 321.0m, 54.0m, "Mleko skondensowane to gęsta, słodka forma mleka, w której woda została usunięta i dodano cukru.", 8.8m, 0, "Mleko skondensowane.png", "Mleko skondensowane", 8.5m, "Nabiał", 2 },
                    { 94, new DateTime(2024, 4, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), 61.0m, 4.7m, "Jogurt naturalny to kwaśny produkt mleczny otrzymywany z fermentacji mleka.", 3.6m, 0, "Jogurt naturalny.png", "Jogurt naturalny", 4.0m, "Nabiał", 3 },
                    { 95, new DateTime(2024, 4, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), 717.0m, 0.1m, "Masło to tłuszcz jadalny otrzymywany z mleka, charakteryzujący się żółtawym kolorem i kremową konsystencją.", 81.0m, 0, "Masło.png", "Masło", 0.9m, "Nabiał", 4 },
                    { 96, new DateTime(2024, 4, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), 98.0m, 3.5m, "Ser biały to delikatny i łagodny ser produkowany z mleka krowiego, często wykorzystywany w diecie fitness.", 0.3m, 0, "Ser biały.png", "Ser biały", 11.0m, "Nabiał", 1 },
                    { 97, new DateTime(2024, 4, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), 56.0m, 4.7m, "Kefir to napój mleczny otrzymywany z fermentacji mleka krowiego lub koziego.", 3.0m, 0, "Kefir.png", "Kefir", 3.3m, "Nabiał", 2 },
                    { 98, new DateTime(2024, 4, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), 174.0m, 2.0m, "Twaróg to biały, miękki ser otrzymywany z kwasu cytrynowego lub innych kwasów.", 9.0m, 0, "Twaróg.png", "Twaróg", 18.0m, "Nabiał", 3 },
                    { 99, new DateTime(2024, 4, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), 322.0m, 1.0m, "Żółtko jaja to żółta część jaja, która zawiera dużo składników odżywczych, w tym witaminy A, D i E.", 27.0m, 0, "Żółtko jaja.png", "Żółtko jaja", 16.0m, "Nabiał", 4 },
                    { 100, new DateTime(2024, 4, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), 155.0m, 1.1m, "Jajko to produkowany przez kury produkt spożywczy, bogaty w białko i inne składniki odżywcze.", 10.6m, 0, "Jajko.png", "Jajko", 12.6m, "Nabiał", 1 },
                    { 101, new DateTime(2024, 4, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 255.0m, 64.8m, "Pieprz czarny to popularna przyprawa o ostrym smaku, pochodząca z ziaren pieprzu czarnego.", 3.3m, 0, "Pieprz czarny.png", "Pieprz czarny", 10.4m, "Przyprawy", 2 },
                    { 102, new DateTime(2024, 4, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), 0.0m, 0.0m, "Sól to niezwykle popularna przyprawa dodawana do potraw dla wzmocnienia smaku.", 0.0m, 0, "Sól.png", "Sól", 0.0m, "Przyprawy", 3 },
                    { 103, new DateTime(2024, 4, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 247.0m, 80.59m, "Cynamon to przyprawa o słodkim i korzennym smaku, często stosowana w deserach i napojach.", 1.24m, 0, "Cynamon.png", "Cynamon", 3.99m, "Przyprawy", 4 },
                    { 104, new DateTime(2024, 4, 23, 22, 0, 0, 0, DateTimeKind.Unspecified), 354.0m, 64.9m, "Kurkuma to przyprawa o intensywnym żółtym kolorze i lekko pikantnym smaku, popularna w kuchni indyjskiej.", 9.88m, 0, "Kurkuma.png", "Kurkuma", 7.83m, "Przyprawy", 1 },
                    { 105, new DateTime(2024, 4, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), 265.0m, 68.9m, "Oregano to zioło o intensywnym zapachu i lekko gorzkim smaku, często używane w kuchni włoskiej.", 4.3m, 0, "Oregano.png", "Oregano", 9.0m, "Przyprawy", 2 },
                    { 106, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0m, 4.2m, "Papryka słodka to przyprawa o delikatnym smaku i intensywnym czerwonym kolorze.", 0.3m, 0, "Papryka słodka.png", "Papryka słodka", 1.0m, "Przyprawy", 3 },
                    { 107, new DateTime(2024, 4, 24, 1, 0, 0, 0, DateTimeKind.Unspecified), 333.0m, 49.9m, "Kminek to przyprawa o intensywnym aromacie i charakterystycznym smaku, popularna w kuchni środkowoeuropejskiej.", 13.9m, 0, "Kminek.png", "Kminek", 19.8m, "Przyprawy", 4 },
                    { 108, new DateTime(2024, 4, 24, 2, 0, 0, 0, DateTimeKind.Unspecified), 43.0m, 6.7m, "Koper to zioło o delikatnym smaku i intensywnym zapachu, często stosowane w zupach i sałatkach.", 0.6m, 0, "Koper.png", "Koper", 2.1m, "Przyprawy", 1 },
                    { 109, new DateTime(2024, 4, 24, 3, 0, 0, 0, DateTimeKind.Unspecified), 298.0m, 38.0m, "Kolendra to zioło o intensywnym zapachu i lekko korzennym smaku, często stosowane w kuchni azjatyckiej.", 17.8m, 0, "Kolendra.png", "Kolendra", 12.0m, "Przyprawy", 2 },
                    { 110, new DateTime(2024, 4, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), 210.0m, 0.0m, "Śledź to mała, tłusta ryba morska popularna w kuchni skandynawskiej, charakteryzująca się intensywnym smakiem.", 14.0m, 0, "Śledź.png", "Śledź", 19.0m, "Ryby", 1 },
                    { 111, new DateTime(2024, 4, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), 82.0m, 0.0m, "Dorsz to popularna ryba morska o białym mięsie, charakteryzująca się delikatnym smakiem.", 0.7m, 0, "Dorsz.png", "Dorsz", 18.0m, "Ryby", 2 },
                    { 112, new DateTime(2024, 4, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), 82.0m, 0.0m, "Flądra to duża, płaska ryba o smacznym mięsie, często stosowana w zupach rybnych i potrawach smażonych.", 0.7m, 0, "Flądra.png", "Flądra", 18.0m, "Ryby", 3 },
                    { 113, new DateTime(2024, 4, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), 250.0m, 0.0m, "Wołowina to mięso pochodzące z krowy, charakteryzujące się bogatym smakiem i wysoką zawartością białka.", 17.0m, 0, "Wołowina.png", "Wołowina", 26.0m, "Mięsa", 1 },
                    { 114, new DateTime(2024, 4, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), 239.0m, 0.0m, "Kurczak to popularne mięso drobiowe, które jest bogate w białko i niskotłuszczowe.", 14.0m, 0, "Kurczak.png", "Kurczak", 27.0m, "Mięsa", 2 },
                    { 115, new DateTime(2024, 4, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), 242.0m, 0.0m, "Wieprzowina to mięso pochodzące z wieprza, charakteryzujące się intensywnym smakiem i różnorodnymi konsystencjami.", 15.0m, 0, "Wieprzowina.png", "Wieprzowina", 26.0m, "Mięsa", 3 },
                    { 116, new DateTime(2024, 4, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), 135.0m, 0.0m, "Indyk to mięso drobiowe pochodzące z indyka, które jest bogate w białko i niskotłuszczowe.", 4.6m, 0, "Indyk.png", "Indyk", 21.0m, "Mięsa", 4 },
                    { 117, new DateTime(2024, 4, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), 294.0m, 0.0m, "Baranina to mięso pochodzące z owcy, charakteryzujące się intensywnym smakiem i soczystą konsystencją.", 24.0m, 0, "Baranina.png", "Baranina", 20.0m, "Mięsa", 1 }
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCookBook",
                table: "UserCookBook");

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "IngredientDetails",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "UserCookBook",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserCookBook",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserCookBook",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserCookBook",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "UserCookBook",
                newName: "userCookBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCookBook",
                table: "userCookBook",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientDetails_userCookBook_UserCookBookId",
                table: "IngredientDetails",
                column: "UserCookBookId",
                principalTable: "userCookBook",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealDay_userCookBook_UserCookBookId",
                table: "MealDay",
                column: "UserCookBookId",
                principalTable: "userCookBook",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeDetails_userCookBook_UserCookBookId",
                table: "RecipeDetails",
                column: "UserCookBookId",
                principalTable: "userCookBook",
                principalColumn: "Id");
        }
    }
}
