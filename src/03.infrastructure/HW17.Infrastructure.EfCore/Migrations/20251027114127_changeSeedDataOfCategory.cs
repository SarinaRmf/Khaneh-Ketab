using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW17.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class changeSeedDataOfCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Auther", "CategoryId", "ImagePath", "PageCount", "Price", "Title" },
                values: new object[] { "دکتر جان اسمیت", 3, "/images/books/rome.jpg", 310, 750000m, "اساطیر جهان" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Auther", "CategoryId", "ImagePath", "PageCount", "Price", "Title" },
                values: new object[] { "لورا هریس", 2, "/images/books/ensan.jpg", 820, 620000m, "انسان خداگونه" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImagePath", "Title" },
                values: new object[] { "/images/books/ManoBabam-3.jpg", "قصه های من و بابام" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Auther", "CategoryId", "ImagePath", "PageCount", "Price", "Title" },
                values: new object[] { "لورا هریس", 2, "/images/books/ensan.jpg", 820, 620000m, "انسان خداگونه" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Auther", "CategoryId", "ImagePath", "PageCount", "Price", "Title" },
                values: new object[] { "دکتر جان اسمیت", 3, "/images/books/rome.jpg", 310, 750000m, "اسطوره های یونان و روم" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImagePath", "Title" },
                values: new object[] { "/images/books/henry.jpg", "هنری زلزله" });
        }
    }
}
