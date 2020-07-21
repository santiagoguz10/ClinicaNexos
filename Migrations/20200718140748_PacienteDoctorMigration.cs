using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Migrations
{
    public partial class PacienteDoctorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PacienteDoctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteDoctors", x => new { x.PacienteId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_PacienteDoctors_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacienteDoctors_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PacienteDoctors_DoctorId",
                table: "PacienteDoctors",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacienteDoctors");
        }
    }
}
