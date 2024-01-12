using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluent_OneToOneRelationBookBookDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Fluent_BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fluent_Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Book", x => x.BookId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookDetails_BookId",
                table: "Fluent_BookDetails",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Book_BookId",
                table: "Fluent_BookDetails",
                column: "BookId",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Book_BookId",
                table: "Fluent_BookDetails");

            migrationBuilder.DropTable(
                name: "Fluent_Book");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookDetails_BookId",
                table: "Fluent_BookDetails");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Fluent_BookDetails");
        }
    }
}
