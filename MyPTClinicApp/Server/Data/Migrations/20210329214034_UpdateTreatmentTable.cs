using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPTClinicApp.Server.Data.Migrations
{
    public partial class UpdateTreatmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SchedulerAppointmentID",
                table: "Treatment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SchedulerAppointmentID",
                table: "Treatment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
