using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONSCIENTIZACAO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ValorApostado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PossivelInvestimento = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSCIENTIZACAO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QUESTIONARIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FrequenciaApostas = table.Column<int>(type: "int", nullable: false),
                    ValorMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTIONARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "REDE_APOIO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Nome = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REDE_APOIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS_SPRINT4",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Nome = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS_SPRINT4", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_SPRINT4_Email",
                table: "USUARIOS_SPRINT4",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONSCIENTIZACAO");

            migrationBuilder.DropTable(
                name: "QUESTIONARIO");

            migrationBuilder.DropTable(
                name: "REDE_APOIO");

            migrationBuilder.DropTable(
                name: "USUARIOS_SPRINT4");
        }
    }
}
