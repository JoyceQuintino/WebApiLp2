using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Laislp2.Migrations
{
    public partial class createDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Gravidez = table.Column<string>(nullable: true),
                    TempoGestacao = table.Column<string>(nullable: true),
                    TipoParto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Criancas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Apgar1 = table.Column<string>(nullable: true),
                    Apgar2 = table.Column<string>(nullable: true),
                    IdMae = table.Column<int>(nullable: false),
                    IdParto = table.Column<int>(nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    Sexo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criancas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaeConcultas",
                columns: table => new
                {
                    IdMae = table.Column<int>(nullable: false),
                    IdConsulta = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaeConcultas", x => new { x.IdMae, x.IdConsulta });
                });

            migrationBuilder.CreateTable(
                name: "Maes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstadoCivil = table.Column<string>(nullable: true),
                    IdadeMae = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    QuantFilhosMortos = table.Column<int>(nullable: false),
                    QuantFilhosVivos = table.Column<int>(nullable: false),
                    escolaridade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Horario = table.Column<string>(nullable: true),
                    IdMae = table.Column<int>(nullable: false),
                    LocalNasci = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Criancas");

            migrationBuilder.DropTable(
                name: "MaeConcultas");

            migrationBuilder.DropTable(
                name: "Maes");

            migrationBuilder.DropTable(
                name: "Partos");
        }
    }
}
