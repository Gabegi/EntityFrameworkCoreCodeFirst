using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FluentOneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Fluent_Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fluent_Publishers",
                columns: table => new
                {
                    Publisher_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Publishers", x => x.Publisher_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_Publishers_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id",
                principalTable: "Fluent_Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_Publishers_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropTable(
                name: "Fluent_Publishers");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Fluent_Book");
        }
    }
}
