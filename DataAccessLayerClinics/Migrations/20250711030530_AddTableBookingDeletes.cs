using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3_DataAccessLayerClinics.Migrations
{
    /// <inheritdoc />
    public partial class AddTableBookingDeletes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingsDeletes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BookingTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    DetectionCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: true),
                    CreatedByNurseID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    BookingCreateAt = table.Column<DateOnly>(type: "date", nullable: false),
                    DateDelete = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsDeletes", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingsDeletes");
        }
    }
}
