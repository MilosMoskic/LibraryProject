using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryProject.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescritpion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BookReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$kRwpdzQcK.YUj4H3ZDiL6.oDyONhAOX6kGtqly9kS0GlsDwsTgbly");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BookReviews");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$LbhKR0kFIrVhMP9mzJWdseCnfNBZMMlYau18v.PwEE58ZkoEQge12");
        }
    }
}
