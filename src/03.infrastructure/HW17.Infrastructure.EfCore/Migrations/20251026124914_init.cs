using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HW17.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UptatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Auther = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UptatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Name", "UpdatedBy", "UptatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "معاصر، کلاسیک", "رمان و داستان", null, null },
                    { 2, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "غرب و شرق", "فلسفه و منطق", null, null },
                    { 3, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "فناوری و تاریخ", "علمی و تاریخی", null, null },
                    { 4, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "داستان های مصور", "کودک و نوجوان", null, null },
                    { 5, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "طراحی و نقاشی", "هنر و معماری", null, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Auther", "CategoryId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "PageCount", "Price", "Title", "UpdatedBy", "UptatedAt" },
                values: new object[,]
                {
                    { 1, "آنتونیو مارکز", 1, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, 400, 490000m, "آخرین نفس", null, null },
                    { 2, "لورا هریس", 3, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, 820, 620000m, "سفر به مریخ", null, null },
                    { 3, "دکتر جان اسمیت", 2, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, 310, 750000m, "اصول رهبری مدرن", null, null },
                    { 4, "مائوریسیو گاند ", 4, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, 550, 380000m, "حکمت های کهن", null, null },
                    { 5, "دایان وایلد", 5, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, 940, 550000m, "تغییرات قرن بیستم", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
