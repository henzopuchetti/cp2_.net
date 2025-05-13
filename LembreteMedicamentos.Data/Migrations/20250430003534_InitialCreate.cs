using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LembreteMedicamentos.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Idosos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Idade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idosos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Dosagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lembretes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Horario = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Observacoes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdosoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MedicamentoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lembretes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lembretes_Idosos_IdosoId",
                        column: x => x.IdosoId,
                        principalTable: "Idosos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lembretes_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lembretes_IdosoId",
                table: "Lembretes",
                column: "IdosoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lembretes_MedicamentoId",
                table: "Lembretes",
                column: "MedicamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lembretes");

            migrationBuilder.DropTable(
                name: "Idosos");

            migrationBuilder.DropTable(
                name: "Medicamentos");
        }
    }
}
