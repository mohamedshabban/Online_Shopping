using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.Migrations
{
    public partial class SeedDataOfModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Clothes", "Clothes" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "Food", "Food" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "Electronics", "Electronics" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AllergyInformation", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsProductOfTheWeek", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[] { 1, "", 1, "", "https://images-na.ssl-images-amazon.com/images/I/61fTX5TjAEL._UL1001_.jpg", true, true, "Jacket is the base of Winter", "Jacket", 400m, "Jacket" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AllergyInformation", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsProductOfTheWeek", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[] { 2, "", 2, "", "https://www.supermarketperimeter.com/ext/resources/0722-mangoes.jpg?1595428736", true, true, "Mango is the base of Fruits", "Mango", 10m, "Mango" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AllergyInformation", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsProductOfTheWeek", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[] { 3, "", 3, "", "https://images-na.ssl-images-amazon.com/images/I/619cPmKZsKL._AC_SL1500_.jpg", true, true, "Freezer is the base of Electronics", "Freezer", 1500m, "Freezer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
