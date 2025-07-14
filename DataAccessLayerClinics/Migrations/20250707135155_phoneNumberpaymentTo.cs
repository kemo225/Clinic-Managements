using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3_DataAccessLayerClinics.Migrations
{
    /// <inheritdoc />
    public partial class phoneNumberpaymentTo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phoneNumberpaymentTo",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phoneNumberpaymentTo",
                table: "Payments");
        }
    }
}
