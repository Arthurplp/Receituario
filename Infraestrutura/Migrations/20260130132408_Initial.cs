using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnidadeDeMedida",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Identificador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeDeMedida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUnidadeMedida = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_UnidadeDeMedida_IdUnidadeMedida",
                        column: x => x.IdUnidadeMedida,
                        principalTable: "UnidadeDeMedida",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdReceitaPai = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdUnidadeMedida = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_Receita_IdReceitaPai",
                        column: x => x.IdReceitaPai,
                        principalTable: "Receita",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Receita_UnidadeDeMedida_IdUnidadeMedida",
                        column: x => x.IdUnidadeMedida,
                        principalTable: "UnidadeDeMedida",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VinculoReceitaMaterial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdReceita = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMaterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeMaterial = table.Column<double>(type: "float", nullable: false),
                    receitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    materialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculoReceitaMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculoReceitaMaterial_Material_materialId",
                        column: x => x.materialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculoReceitaMaterial_Receita_receitaId",
                        column: x => x.receitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_IdUnidadeMedida",
                table: "Material",
                column: "IdUnidadeMedida");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_IdReceitaPai",
                table: "Receita",
                column: "IdReceitaPai");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_IdUnidadeMedida",
                table: "Receita",
                column: "IdUnidadeMedida");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoReceitaMaterial_materialId",
                table: "VinculoReceitaMaterial",
                column: "materialId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoReceitaMaterial_receitaId",
                table: "VinculoReceitaMaterial",
                column: "receitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VinculoReceitaMaterial");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "UnidadeDeMedida");
        }
    }
}
