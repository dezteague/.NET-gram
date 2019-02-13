using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNet_gram.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Posts",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Username",
                value: "Deziree T.");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Username",
                value: "Elisha C.");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Username",
                value: "Quinton R.");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Username",
                value: "Zan J.");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Caption", "Username" },
                values: new object[] { "This is beautiful", "Lynette E." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Rating",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3,
                column: "Rating",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4,
                column: "Rating",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Caption", "Rating" },
                values: new object[] { "This is beautiful!", 5 });
        }
    }
}
