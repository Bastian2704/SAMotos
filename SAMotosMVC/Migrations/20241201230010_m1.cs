using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAMotosMVC.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SAMoto",
                columns: table => new
                {
                    idSAMoto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAmodelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAmarca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAcilindraje = table.Column<int>(type: "int", nullable: false),
                    SAcolor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAMoto", x => x.idSAMoto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SAMoto");
        }
    }
}
