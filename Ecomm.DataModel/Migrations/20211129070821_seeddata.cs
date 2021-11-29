using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecomm.DataModel.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryId", "CategoryName" },
                values: new object[] { 1L, "Car" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryId", "CategoryName" },
                values: new object[] { 2L, "Mobile" });

            migrationBuilder.InsertData(
                table: "ProductAttributeLookups",
                columns: new[] { "AttributeId", "AttributeName", "ProductCategoryId" },
                values: new object[,]
                {
                    { 1L, "Color", 1L },
                    { 2L, "Make", 1L },
                    { 3L, "Model", 1L },
                    { 4L, "RAM", 2L },
                    { 5L, "Front Camera", 2L },
                    { 6L, "Rear Camera", 2L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductAttributeLookups",
                keyColumn: "AttributeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookups",
                keyColumn: "AttributeId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookups",
                keyColumn: "AttributeId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookups",
                keyColumn: "AttributeId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookups",
                keyColumn: "AttributeId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ProductAttributeLookups",
                keyColumn: "AttributeId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryId",
                keyValue: 2L);
        }
    }
}
