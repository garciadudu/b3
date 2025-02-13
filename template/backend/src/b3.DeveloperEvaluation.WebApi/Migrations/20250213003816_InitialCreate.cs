using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace b3.DeveloperEvaluation.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CDBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    VF = table.Column<double>(type: "double precision", nullable: false),
                    VI = table.Column<double>(type: "double precision", nullable: false),
                    CDI = table.Column<double>(type: "double precision", nullable: false),
                    TB = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDBs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CDBs");
        }
    }
}
