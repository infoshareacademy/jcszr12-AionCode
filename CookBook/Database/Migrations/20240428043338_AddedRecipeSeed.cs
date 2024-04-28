using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedRecipeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RecipeDetails",
                columns: new[] { "Id", "AddDate", "Category", "Description", "ImagePath", "Name", "UserCookBookId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania obiadowe", "1. W garnku gotuj wodę i gotuj spaghetti według wskazówek na opakowaniu.\n2. W drugim garnku podsmaż cebulę i czosnek na oleju.\n3. Dodaj mieloną wołowinę i smaż, aż się zrumieni.\n4. Dodaj marchewkę pokrojoną w kostkę i smaż przez kilka minut.\n5. Dodaj passatę pomidorową, koncentrat pomidorowy, oregano, bazylię, sól i pieprz.\n6. Gotuj na małym ogniu przez około 20 minut.\n7. Podawaj sos pomidorowy razem ze spaghetti.", "http://127.0.0.1:10000/devstoreaccount1/book-files/spaghetti.jpg", "Spaghetti Bolognese", 1 },
                    { 2, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "sniadanie", "1. Filety z kurczaka pokrój na kawałki.\n2. Papryki i cukinię pokrój w paski, a cebulę w kostkę.\n3. W dużym rondlu rozgrzej olej i dodaj cebulę i czosnek. Smaż przez około 2 minutki.\n4. Dodaj kurczaka i smaż, aż będzie zrumieniony.\n5. Dodaj papryki i cukinię. Smaż na średnim ogniu przez około 5 minut.\n6. Dodaj sok z cytryny, curry, sól i pieprz. Mieszaj i smaż jeszcze przez kilka minut.\n7. Podawaj kurczaka z warzywami jako danie główne.", "http://127.0.0.1:10000/devstoreaccount1/book-files/Kurczak-z-cukinia-i-papryka-5338.jpg", "Kurczak z warzywami", 1 },
                    { 3, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "null", "1. Filety z kurczaka pokrój na kawałki.\n2. Papryki i cukinię pokrój w paski, a cebulę w kostkę.\n3. W dużym rondlu rozgrzej olej i dodaj cebulę i czosnek. Smaż przez około 2 minutki.\n4. Dodaj kurczaka i smaż, aż będzie zrumieniony.\n5. Dodaj papryki i cukinię. Smaż na średnim ogniu przez około 5 minut.\n6. Dodaj sok z cytryny, curry, sól i pieprz. Mieszaj i smaż jeszcze przez kilka minut.\n7. Podawaj kurczaka z warzywami jako danie główne.", "http://127.0.0.1:10000/devstoreaccount1/book-files/null.jpg", "Sałatka grecka", 1 },
                    { 4, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania obiadowe", "1. Na patelni podsmaż cebulę i paprykę pokrojoną w paski na oleju.\n2. Dodaj mieloną wieprzowinę i smaż, aż się zrumieni.\n3. Dodaj przyprawy: chili, paprykę słodką, kumin, czosnek w proszku, sól i pieprz.\n4. Podawaj mięso na tortilli, dodając sałatę, pomidory, kawałki awokado i skwarki tortilli.", "http://127.0.0.1:10000/devstoreaccount1/book-files/tacos.jpg", "Tacos", 1 },
                    { 5, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania obiadowe", "1. Na patelni podsmaż cebulę i czosnek na oleju.\n2. Dodaj pokrojonego kurczaka i smaż, aż się zrumieni.\n3. Dodaj pokrojoną marchewkę, paprykę i cukinię. Smaż przez kilka minut.\n4. Dodaj curry, kurkumę, sól i pieprz.\n5. Podlej wodą i dus przez około 15 minut.\n6. Podawaj z ugotowanym ryżem.", "http://127.0.0.1:10000/devstoreaccount1/book-files/curry.jpg", "Kurczak curry z warzywami", 1 },
                    { 6, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania obiadowe", "1. W rondlu podsmaż cebulę i czosnek na oleju.\n2. Dodaj pokrojonego kurczaka i smaż, aż się zrumieni.\n3. Dodaj mieszankę curry oraz mleczko kokosowe.\n4. Gotuj na małym ogniu przez około 15 minut.\n5. Podawaj kurczaka curry razem z ugotowanym ryżem.", "http://127.0.0.1:10000/devstoreaccount1/book-files/curry1.jpg", "Kurczak Curry z Ryżem", 1 },
                    { 7, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "sałatki", "1. Pokrój pomidory, ogórka, cebulę i paprykę.\n2. Dodaj pokrojoną sałatę, oliwki oraz ser feta.\n3. Skrop sałatkę oliwą z oliwek.\n4. Dopraw solą, pieprzem i oregano.\n5. Delikatnie wymieszaj składniki.\n6. Podawaj sałatkę z kawałkiem chleba czosnkowego.", "http://127.0.0.1:10000/devstoreaccount1/book-files/salatka.jpg", "Sałatka grecka", 1 },
                    { 8, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "desery", "1. W misce wymieszaj mascarpone, cukier i ekstrakt waniliowy. 2. W innym naczyniu wymieszaj espresso z likierem kawowym. 3. Namocz biszkopty w przygotowanym napoju kawowym. 4. Na dnie foremki ułóż warstwę biszkoptów, następnie warstwę kremu mascarpone. 5. Powtórz warstwy biszkoptów i kremu. 6. Posyp kakao na wierzch. 7. Schłódź tiramisu przez kilka godzin przed podaniem.", "http://127.0.0.1:10000/devstoreaccount1/book-files/tiramisu.jpg", "Tiramisu", 3 },
                    { 9, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania obiadowe", "1. W rondlu ugotuj makaron wg wskazówek na opakowaniu. 2. Na patelni rozgrzej masło i smaż posiekany czosnek. 3. Dodaj pokrojonego kurczaka i smaż aż będzie złocisty. 4. Wlej śmietanę kremówkę, dodaj starty parmezan i dopraw solą oraz pieprzem. 5. Gotuj sos na małym ogniu, aż zgęstnieje. 6. Na talerzu ułóż makaron, polej sosem i posyp natką pietruszki.", "http://127.0.0.1:10000/devstoreaccount1/book-files/null.jpg", "Chicken Alfredo", 1 },
                    { 10, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "desery", "1. Przygotuj ciasto naleśnikowe według ulubionego przepisu.\n2. Na rozgrzaną patelnię wlej cienką warstwę ciasta naleśnikowego i smaż z obu stron.\n3. Wyłóż na środek każdego naleśnika ser twarogowy i ulubiony dżem.\n4. Zwijaj naleśniki i podawaj posypane cukrem pudrem.", "http://127.0.0.1:10000/devstoreaccount1/book-files/naleśniki.jpg", "Naleśniki z serem i dżemem", 2 },
                    { 11, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "desery", "1. Upiecz biszkoptowy spód ciasta i ostudź.\n2. Ubij śmietanę kremówką z cukrem na sztywno.\n3. Rozłóż ubitą śmietanę na biszkopcie.\n4. Na wierzch ciasta ułóż ulubione owoce, takie jak truskawki, maliny i kiwi.\n5. Schłódź ciasto przed podaniem.", "http://127.0.0.1:10000/devstoreaccount1/book-files/ciasto.jpg", "Ciasto śmietanowe z owocami", 1 },
                    { 12, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania obiadowe", "1. Kurczaka pokrój na kawałki i obsmaż na patelni.\n2. W osobnym garnku podsmaż cebulę i czosnek na oliwie.\n3. Dodaj pokrojoną w kostkę marchew, pietruszkę i seler.\n4. Wrzuć kurczaka do garnka, dodaj bulion warzywny i dusz przez 30 minut.\n5. Dopraw solą, pieprzem i przyprawami do kurczaka.\n6. Podawaj danie po staropolsku z ziemniakami i surówką.", "http://127.0.0.1:10000/devstoreaccount1/book-files/chicken.jpg", "Kurczak po staropolsku", 1 },
                    { 13, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania obiadowe", "1. W garnku gotuj wodę i gotuj makaron według wskazówek na opakowaniu.\n2. Na patelni podsmaż czosnek i chilli na oliwie.\n3. Dodaj krewetki i smaż przez kilka minut.\n4. Do krewetek dodaj śmietanę, sok z cytryny i starty parmezan.\n5. Gotuj na małym ogniu, aż sos zgęstnieje.\n6. Dodaj ugotowany makaron i mieszaj.\n7. Podawaj danie posypane posiekaną natką pietruszki.", "http://127.0.0.1:10000/devstoreaccount1/book-files/pasta.jpg", "Czarny makaron z krewetkami", 1 },
                    { 14, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "śniadaniowe", "1. Na patelni rozgrzej masło i podsmaż cebulę, czosnek i pomidory.\n2. Dodaj jajka i smaż, aż białko się zetnie.\n3. Posyp jajka przyprawami i posiekaną natką pietruszki.\n4. Podawaj jajka na kawałku chleba lub razem z sałatką.", "http://127.0.0.1:10000/devstoreaccount1/book-files/null.jpg", "Jajka po turecku z masłem palonym", 1 },
                    { 15, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania główne", "1. Na dużym garnku podsmaż cebulę i czosnek na oleju.\n2. Dodaj kiełbasę pokrojoną w plastry i smaż, aż się zrumieni.\n3. Dodaj kapustę kiszoną, buraki, śliwki, koncentrat pomidorowy, przyprawy i wodę.\n4. Gotuj bigos na małym ogniu przez 2-3 godziny.\n5. Podawaj bigos z ziemniakami lub chlebem.", "http://127.0.0.1:10000/devstoreaccount1/book-files/bigos.jpg", "Bigos", 1 },
                    { 16, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania główne", "1. Kaczkę umyj, oczyść i pokrój na porcje.\n2. Na dużym garnku rozgrzej olej i delikatnie podsmaż kaczkę z każdej strony.\n3. Dodaj posiekaną cebulę i marchewkę, smaż aż warzywa zmiękną.\n4. Wlej bulion i doprowadź do wrzenia.\n5. Dodaj suszone śliwki i rodzynki.\n6. Przypraw solą, pieprzem, goździkami i majerankiem.\n7. Dusić na małym ogniu przez około 2 godziny.\n8. Podawaj z kluskami śląskimi i czerwonym winem.", "http://127.0.0.1:10000/devstoreaccount1/book-files/kaczka.jpg", "Kaczka po staropolsku", 4 },
                    { 17, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "dania główne", "1. Steki oczyść z nadmiaru tłuszczu i oprósź solą oraz pieprzem.\n2. Rozgrzej patelnię z olejem na bardzo wysoką temperaturę.\n3. Wrzuć steki na patelnię i smaż przez około 2-3 minuty z każdej strony, aby uzyskać soczyste wnętrze.\n4. Obniż ogień i kontynuuj smażenie steków, aż będą odpowiednio wypieczone.\n5. Podawaj natychmiast ze smażonymi ziemniakami i sałatką z pomidorów.", "http://127.0.0.1:10000/devstoreaccount1/book-files/steak.jpg", "Stek wołowy", 1 },
                    { 18, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "śniadaniowe", "1. Pokrój awokado oraz łososia w cienkie plasterki.\n2. Rozgrzej piekarnik i przygotuj dwie kromki chleba do opieczenia.\n3. Na każdą kromkę chleba połóż plasterki avocado i łososia.\n4. Dopraw kanapki solą i pieprzem według własnego uznania.\n5. Podawaj kanapki z ulubionym sosem lub marynatą.", "http://127.0.0.1:10000/devstoreaccount1/book-files/kanapka.jpg", "Kanapka z avocado i łososiem", 1 },
                    { 19, new DateTime(2024, 4, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "obiadowe", "1. W rondlu rozgrzej śmietanę.\n2. Dodaj pokrojony w plastry łosoś i dus przez kilka minut.\n3. Dopraw do smaku solą i pieprzem.\n4. Podawaj danie z ulubionymi dodatkami, np. ryżem oraz sałatką.", "http://127.0.0.1:10000/devstoreaccount1/book-files/losos.jpg", "Łosoś w sosie śmietanowym", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RecipeDetails",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
