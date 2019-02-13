using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNet_gram.Migrations
{
    public partial class seededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Caption", "Rating", "Title", "URL" },
                values: new object[,]
                {
                    { 1, "This is awesome!", 5, "awesome", "awesome.jpg" },
                    { 2, "This is cool!", 4, "cool", "cool.jpg" },
                    { 3, "This is fun!", 3, "fun", "fun.jpg" },
                    { 4, "This is amazing!", 5, "amazing", "amazing.jpg" },
                    { 5, "This is beautiful!", 5, "beautiful", "beautiful.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
