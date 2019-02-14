using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotNet_gram.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Caption", "Title", "URL", "Username" },
                values: new object[,]
                {
                    { 1, "This is awesome!", "awesome", "awesome.jpg", "Deziree T." },
                    { 2, "This is cool!", "cool", "cool.jpg", "Elisha C." },
                    { 3, "This is fun!", "fun", "fun.jpg", "Quinton R." },
                    { 4, "This is amazing!", "amazing", "amazing.jpg", "Zan J." },
                    { 5, "This is beautiful", "beautiful", "beautiful.jpg", "Lynette E." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
