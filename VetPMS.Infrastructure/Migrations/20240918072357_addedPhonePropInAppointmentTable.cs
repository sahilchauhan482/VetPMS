using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetPMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedPhonePropInAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Appointments");
        }
    }
}
