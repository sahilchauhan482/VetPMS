using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetPMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedClinicIdInAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Breeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ClinicId",
                table: "Patients",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_ClinicId",
                table: "Owners",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_ClinicId",
                table: "Medicines",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_ClinicId",
                table: "Breeds",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Clinics_ClinicId",
                table: "Breeds",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Clinics_ClinicId",
                table: "Medicines",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Clinics_ClinicId",
                table: "Owners",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Clinics_ClinicId",
                table: "Patients",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Clinics_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Clinics_ClinicId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Clinics_ClinicId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Clinics_ClinicId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Clinics_ClinicId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ClinicId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Owners_ClinicId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_ClinicId",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_ClinicId",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClinicId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "AspNetUsers");
        }
    }
}
