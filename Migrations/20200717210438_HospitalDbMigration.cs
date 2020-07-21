using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Migrations
{
    public partial class HospitalDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(maxLength: 150, nullable: false),
                    Especialidad = table.Column<string>(maxLength: 50, nullable: false),
                    NumeroCredencial = table.Column<int>(nullable: false),
                    Hospital = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(maxLength: 150, nullable: false),
                    NumeroSeguroSocial = table.Column<int>(nullable: false),
                    CodigoPostal = table.Column<int>(nullable: false),
                    TelefonoContacto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.PacienteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
