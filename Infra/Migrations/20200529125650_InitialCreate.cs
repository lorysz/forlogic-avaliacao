using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "tb_avaliacao",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Nota = table.Column<float>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_avaliacao", x => x.IdAvaliacao);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_tb_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tb_usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(nullable: false),
                    NomeResponsavel = table.Column<string>(nullable: false),
                    Cnpj = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_tb_cliente_tb_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "tb_usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_avaliacao_cliente",
                columns: table => new
                {
                    IdAvaliacaoCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    IdAvaliacao = table.Column<int>(nullable: false),
                    ResultadoAvaliacao = table.Column<string>(nullable: true),
                    Nota = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_avaliacao_cliente", x => x.IdAvaliacaoCliente);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_cliente_tb_avaliacao_IdAvaliacao",
                        column: x => x.IdAvaliacao,
                        principalTable: "tb_avaliacao",
                        principalColumn: "IdAvaliacao",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_avaliacao_cliente_tb_cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "tb_cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tb_usuario",
                columns: new[] { "IdUsuario", "Email", "Nome", "Senha" },
                values: new object[] { 1, "adm@adm.com.br", "Administrador", "123" });

            migrationBuilder.InsertData(
                table: "tb_cliente",
                columns: new[] { "IdCliente", "Cnpj", "DataCadastro", "IdUsuario", "NomeResponsavel", "RazaoSocial" },
                values: new object[,]
                {
                    { 1, "24.573.802/0001-59", new DateTime(2020, 5, 29, 9, 56, 50, 341, DateTimeKind.Local).AddTicks(1156), 1, "Arthur", "Arthur e Geraldo Eletrônica ME" },
                    { 2, "21.062.238/0001-11", new DateTime(2020, 5, 29, 9, 56, 50, 341, DateTimeKind.Local).AddTicks(1795), 1, "Roberto", "Roberto e Tânia Assessoria Jurídica Ltda" },
                    { 3, "34.202.824/0001-66", new DateTime(2020, 5, 29, 9, 56, 50, 341, DateTimeKind.Local).AddTicks(1803), 1, "Allana", "Allana e Diogo Transportes Ltda" },
                    { 4, "84.234.045/0001-10", new DateTime(2020, 5, 29, 9, 56, 50, 341, DateTimeKind.Local).AddTicks(1806), 1, "Igor", "Igor e Fernando Consultoria Financeira ME" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_IdUsuario",
                table: "tb_avaliacao",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_cliente_IdAvaliacao",
                table: "tb_avaliacao_cliente",
                column: "IdAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_tb_avaliacao_cliente_IdCliente",
                table: "tb_avaliacao_cliente",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cliente_IdUsuario",
                table: "tb_cliente",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_avaliacao_cliente");

            migrationBuilder.DropTable(
                name: "tb_avaliacao");

            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropTable(
                name: "tb_usuario");
        }
    }
}
