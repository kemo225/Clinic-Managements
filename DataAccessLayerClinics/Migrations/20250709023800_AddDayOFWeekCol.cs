using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3_DataAccessLayerClinics.Migrations
{
    /// <inheritdoc />
    public partial class AddDayOFWeekCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "DoctorSchedule",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "DoctorSchedule");
        }
    }
}
