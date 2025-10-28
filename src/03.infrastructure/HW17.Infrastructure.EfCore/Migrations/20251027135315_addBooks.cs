using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HW17.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class addBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Auther", "CategoryId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "ImagePath", "PageCount", "Price", "Title", "UpdatedBy", "UptatedAt" },
                values: new object[,]
                {
                    { 6, "دایان وایلد", 5, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "/images/books/kherad.jpg", 940, 550000m, "انسان خردمند", null, null },
                    { 7, "دایان وایلد", 5, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "/images/books/napel.jpg", 940, 550000m, "دایی جان ناپلئون", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
