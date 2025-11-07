using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HW17.Infra.DataAccess.Db.SqlServer.Ef.Migrations
{
    /// <inheritdoc />
    public partial class changeArchituture : Migration
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
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UptatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "ImagePath", "Name", "UpdatedBy", "UptatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "معاصر، کلاسیک", "/images/Category/stack-of-books.png", "رمان و داستان", null, null },
                    { 2, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "غرب و شرق", "/images/Category/artificial-intelligence.png", "فلسفه و منطق", null, null },
                    { 3, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "فناوری و تاریخ", "/images/Category/microscope.png", "علمی و تاریخی", null, null },
                    { 4, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "داستان های مصور", "/images/Category/student.png", "کودک و نوجوان", null, null },
                    { 5, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "طراحی و نقاشی", "/images/Category/color-pallete.png", "هنر و معماری", null, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Auther", "CategoryId", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "ImagePath", "PageCount", "Price", "Title", "UpdatedBy", "UptatedAt" },
                values: new object[,]
                {
                    { 1, "آنتونیو مارکز", 1, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "/images/books/hezaroyekshab.jpg", 400, 490000m, "هزار و یک شب", null, null },
                    { 2, "دکتر جان اسمیت", 3, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "/images/books/rome.jpg", 310, 750000m, "اساطیر جهان", null, null },
                    { 3, "لورا هریس", 2, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "/images/books/ensan.jpg", 820, 620000m, "انسان خداگونه", null, null },
                    { 4, "مائوریسیو گاند ", 4, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "/images/books/ManoBabam-3.jpg", 550, 380000m, "قصه های من و بابام", null, null },
                    { 5, "دایان وایلد", 5, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "/images/books/honar.jpg", 940, 550000m, "هنر در گذر زمان", null, null },
                    { 6, "دایان وایلد", 5, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "/images/books/kherad.jpg", 940, 550000m, "انسان خردمند", null, null },
                    { 7, "دایان وایلد", 5, new DateTime(2025, 10, 11, 14, 30, 0, 0, DateTimeKind.Unspecified), null, null, null, "/images/books/napelon.jpg", 940, 550000m, "دایی جان ناپلئون", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
