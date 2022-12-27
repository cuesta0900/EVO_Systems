using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVOWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    sigla = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    rg = table.Column<int>(type: "INTEGER", nullable: false),
                    Departamentoid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_Departamentoid",
                        column: x => x.Departamentoid,
                        principalTable: "Departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "id", "nome", "sigla" },
                values: new object[,]
                {
                    { 1, "Informática", "TI" },
                    { 2, "Segurança", "SEG" },
                    { 3, "Recursos Humanos", "RH" },
                    { 4, "Marketing", "MK" },
                    { 5, "Administrativo", "ADM" }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "id", "Departamentoid", "nome", "rg" },
                values: new object[,]
                {
                    { 1, 2, "Marta Kent", 33225555 },
                    { 2, 1, "Paula Isabela", 3354288 },
                    { 3, 3, "Laura Antonia", 566889 },
                    { 4, 4, "Luiza Maria", 656559 },
                    { 5, 5, "Lucas Machado", 6568541 },
                    { 6, 2, "Pedro Alvares", 45645445 },
                    { 7, 4, "Paulo José", 9874512 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Departamentoid",
                table: "Funcionarios",
                column: "Departamentoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
