using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryProject.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "BookReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$LbhKR0kFIrVhMP9mzJWdseCnfNBZMMlYau18v.PwEE58ZkoEQge12");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "BookReviews");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$btpk9oIN5hn9HVi4fkMfiu6t4QG3Dtg.uaX/A1Yzco8Txz9QfIil.");
        }
    }
}
