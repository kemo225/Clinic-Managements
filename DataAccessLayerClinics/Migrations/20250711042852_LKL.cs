using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3_DataAccessLayerClinics.Migrations
{
    /// <inheritdoc />
    public partial class LKL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fine",
                table: "BookingsDeletes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fines",
                table: "BookingsDeletes");
        }
    }
}
