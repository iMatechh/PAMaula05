using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CopaHAS.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoEstadios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ESTADIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Capacidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTADIOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_ESTADIOS",
                columns: new[] { "Id", "Capacidade", "Cidade", "Nome" },
                values: new object[,]
                {
                    { 1, 82500m, "East Rutherford (NY/NJ)", "MetLife Stadium" },
                    { 2, 70240m, "Los Angeles (CA)", "SoFi Stadium" },
                    { 3, 80000m, "Arlington (TX)", "AT&T Stadium" },
                    { 4, 71000m, "Atlanta (GA)", "Mercedes-Benz Stadium" },
                    { 5, 72220m, "Houston (TX)", "NRG Stadium" },
                    { 6, 68500m, "Santa Clara (CA)", "Levi's Stadium" },
                    { 7, 68740m, "Seattle (WA)", "Lumen Field" },
                    { 8, 69596m, "Philadelphia (PA)", "Lincoln Financial Field" },
                    { 9, 65326m, "Miami (FL)", "Hard Rock Stadium" },
                    { 10, 76416m, "Kansas City (MO)", "GEHA Field at Arrowhead Stadium" },
                    { 11, 65878m, "Foxborough (MA)", "Gillette Stadium" },
                    { 12, 54500m, "Vancouver", "BC Place" },
                    { 13, 30000m, "Toronto", "BMO Field" },
                    { 14, 87000m, "Cidade do México", "Estadio Azteca" },
                    { 15, 53500m, "Monterrey", "Estadio BBVA" },
                    { 16, 49850m, "Guadalajara", "Estadio Akron" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ESTADIOS");
        }
    }
}
