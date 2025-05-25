using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuChallenge.Migrations
{
    /// <inheritdoc />
    public partial class AddVagaAndConfigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VagaId",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Ocupada = table.Column<short>(type: "NUMBER(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocupacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MotoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VagaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataOcupacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocupacoes_Motos_MotoId",
                        column: x => x.MotoId,
                        principalTable: "Motos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocupacoes_Vagas_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vagas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_VagaId",
                table: "Motos",
                column: "VagaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocupacoes_MotoId",
                table: "Ocupacoes",
                column: "MotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocupacoes_VagaId",
                table: "Ocupacoes",
                column: "VagaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motos_Vagas_VagaId",
                table: "Motos",
                column: "VagaId",
                principalTable: "Vagas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motos_Vagas_VagaId",
                table: "Motos");

            migrationBuilder.DropTable(
                name: "Ocupacoes");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropIndex(
                name: "IX_Motos_VagaId",
                table: "Motos");

            migrationBuilder.DropColumn(
                name: "VagaId",
                table: "Motos");
        }
    }
}
