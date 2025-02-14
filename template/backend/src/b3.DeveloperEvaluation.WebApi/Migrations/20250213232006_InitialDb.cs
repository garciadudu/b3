using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace b3.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    DtFinal = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NomeTitulo = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Empresa = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Rentabilidade = table.Column<double>(type: "numeric(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    DtInicial = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VI = table.Column<double>(type: "double precision", nullable: false),
                    VF = table.Column<double>(type: "double precision", nullable: false),
                    CDI = table.Column<double>(type: "double precision", nullable: false),
                    TB = table.Column<double>(type: "double precision", nullable: false),
                    IR = table.Column<double>(type: "double precision", nullable: false),
                    TituloId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CDBs_Titulos_TituloId",
                        column: x => x.TituloId,
                        principalTable: "Titulos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CDBs_TituloId",
                table: "CDBs",
                column: "TituloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDBs");

            migrationBuilder.DropTable(
                name: "Titulos");
        }
    }
}
