using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class AddEstadoCitaToCitas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the EstadoCita column
            migrationBuilder.AddColumn<int>(
                name: "EstadoCita",
                table: "Citas",
                nullable: false,
                defaultValue: 0); // Provide a default value if necessary
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the EstadoCita column if the migration is rolled back
            migrationBuilder.DropColumn(
                name: "EstadoCita",
                table: "Citas");
        }
    }
}
