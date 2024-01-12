using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluentAPIModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "tb_Category");

            migrationBuilder.AddColumn<string>(
                name: "ISBN_Name",
                table: "tb_Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_Category",
                table: "tb_Category",
                column: "CategoryId");

            migrationBuilder.CreateTable(
                name: "Fluent_BookAuthorMap",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookAuthorMap", x => x.Book_Id);
                    table.ForeignKey(
                        name: "FK_Fluent_BookAuthorMap_Authors_Author_Id1",
                        column: x => x.Author_Id1,
                        principalTable: "Authors",
                        principalColumn: "Author_Id");
                });

            migrationBuilder.CreateTable(
                name: "Fluent_BookDetails",
                columns: table => new
                {
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookDetails", x => x.BookDetail_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookAuthorMap_Author_Id1",
                table: "Fluent_BookAuthorMap",
                column: "Author_Id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_BookAuthorMap");

            migrationBuilder.DropTable(
                name: "Fluent_BookDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_Category",
                table: "tb_Category");

            migrationBuilder.DropColumn(
                name: "ISBN_Name",
                table: "tb_Category");

            migrationBuilder.RenameTable(
                name: "tb_Category",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryId");
        }
    }
}
