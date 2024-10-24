using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationDatabase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBloodStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MinimumQuantity",
                table: "BloodStocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumQuantity",
                table: "BloodStocks");
        }
    }
}
