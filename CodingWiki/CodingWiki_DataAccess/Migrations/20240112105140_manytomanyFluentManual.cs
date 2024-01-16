using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class manytomanyFluentManual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Authors_Author_Id1",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookAuthorMap_Author_Id1",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropColumn(
                name: "Author_Id1",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.AlterColumn<int>(
                name: "Book_Id",
                table: "Fluent_BookAuthorMap",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap",
                columns: new[] { "Book_Id", "Author_Id" });

            migrationBuilder.CreateTable(
                name: "Fluent_Authors",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Authors", x => x.Author_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookAuthorMap_Author_Id",
                table: "Fluent_BookAuthorMap",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Authors_Author_Id",
                table: "Fluent_BookAuthorMap",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Authors_Author_Id",
                table: "Fluent_BookAuthorMap",
                column: "Author_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Book_Book_Id",
                table: "Fluent_BookAuthorMap",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Authors_Author_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Authors_Author_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Book_Book_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropTable(
                name: "Fluent_Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookAuthorMap_Author_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.AlterColumn<int>(
                name: "Book_Id",
                table: "Fluent_BookAuthorMap",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Author_Id1",
                table: "Fluent_BookAuthorMap",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookAuthorMap_Author_Id1",
                table: "Fluent_BookAuthorMap",
                column: "Author_Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Authors_Author_Id1",
                table: "Fluent_BookAuthorMap",
                column: "Author_Id1",
                principalTable: "Authors",
                principalColumn: "Author_Id");
        }
    }
}
