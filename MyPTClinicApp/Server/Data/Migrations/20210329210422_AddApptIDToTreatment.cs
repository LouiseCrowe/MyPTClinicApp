using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPTClinicApp.Server.Data.Migrations
{
    public partial class AddApptIDToTreatment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchedulerAppointmentID",
                table: "Treatment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "SchedulerAppointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TherapistName",
                table: "SchedulerAppointment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchedulerAppointmentID",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "SchedulerAppointment");

            migrationBuilder.DropColumn(
                name: "TherapistName",
                table: "SchedulerAppointment");
        }
    }
}
