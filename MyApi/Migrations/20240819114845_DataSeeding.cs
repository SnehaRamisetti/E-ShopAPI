using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductName" },
                values: new object[,]
                {
                    { new Guid("569bec51-0f89-4467-a2b9-3137e01847cb"), 49m, "Bluetooth Speaker" },
                    { new Guid("80f440ee-4cec-4c2f-adfa-0fe91e680e59"), 29m, "Wireless Earbuds" },
                    { new Guid("81d9a2d1-b6e0-4813-8f1b-beff2fada320"), 35m, "Smart watch" },
                    { new Guid("a0978012-8349-43aa-ac8a-79fc5731551d"), 16m, "Laptop stand" },
                    { new Guid("a6830687-d41d-486f-8e48-6ff52e757892"), 20m, "Gaming Stand" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("569bec51-0f89-4467-a2b9-3137e01847cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("80f440ee-4cec-4c2f-adfa-0fe91e680e59"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("81d9a2d1-b6e0-4813-8f1b-beff2fada320"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a0978012-8349-43aa-ac8a-79fc5731551d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a6830687-d41d-486f-8e48-6ff52e757892"));
        }
    }
}
