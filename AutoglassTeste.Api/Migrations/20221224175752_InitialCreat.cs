using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoglassTeste.Api.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoProduto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SituacaoProduto = table.Column<int>(type: "int", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFabricacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoFornecedor = table.Column<int>(type: "int", nullable: false),
                    DescricaoFornecedor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CNPJFornecedor = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
