using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryProject.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReview_Books_BookId",
                table: "BookReview");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReview_Users_UserId",
                table: "BookReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookReview",
                table: "BookReview");

            migrationBuilder.RenameTable(
                name: "BookReview",
                newName: "BookReviews");

            migrationBuilder.RenameIndex(
                name: "IX_BookReview_BookId",
                table: "BookReviews",
                newName: "IX_BookReviews_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookReviews",
                table: "BookReviews",
                columns: new[] { "UserId", "BookId" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$btpk9oIN5hn9HVi4fkMfiu6t4QG3Dtg.uaX/A1Yzco8Txz9QfIil.");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Books_BookId",
                table: "BookReviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Users_UserId",
                table: "BookReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Books_BookId",
                table: "BookReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Users_UserId",
                table: "BookReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookReviews",
                table: "BookReviews");

            migrationBuilder.RenameTable(
                name: "BookReviews",
                newName: "BookReview");

            migrationBuilder.RenameIndex(
                name: "IX_BookReviews_BookId",
                table: "BookReview",
                newName: "IX_BookReview_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookReview",
                table: "BookReview",
                columns: new[] { "UserId", "BookId" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$5jfAQ2TPUrh6YioA6Msv2eoC.lFirlBg9F5.QVxG470qDswnfF3D2");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReview_Books_BookId",
                table: "BookReview",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReview_Users_UserId",
                table: "BookReview",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
