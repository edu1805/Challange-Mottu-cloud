using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cp2WebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalizacaoAtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_LOCALIZACAO_ATUAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MotoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CoordenadaX = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CoordenadaY = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DataHoraAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_LOCALIZACAO_ATUAL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_LOCALIZACAO_ATUAL_T_MOTOS_MotoId",
                        column: x => x.MotoId,
                        principalTable: "T_MOTOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_LOCALIZACAO_ATUAL_MotoId",
                table: "T_LOCALIZACAO_ATUAL",
                column: "MotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_LOCALIZACAO_ATUAL");
        }
    }
}
