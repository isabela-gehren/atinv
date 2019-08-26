using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATINV.Repository.Migrations
{
    public partial class Inicializacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fund",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    Name = table.Column<string>(nullable: false),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    MinInicialContribution = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fund", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moviment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    FundId = table.Column<Guid>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    MovimentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moviment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moviment_Fund_FundId",
                        column: x => x.FundId,
                        principalTable: "Fund",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Fund",
                columns: new[] { "Id", "Cnpj", "MinInicialContribution", "Name" },
                values: new object[] { new Guid("77c725c9-dc4f-49d0-ab59-d316cd500abe"), "78092564000199", 1000m, "Fundo ABC" });

            migrationBuilder.InsertData(
                table: "Fund",
                columns: new[] { "Id", "Cnpj", "MinInicialContribution", "Name" },
                values: new object[] { new Guid("e967dd84-d7b8-400f-988d-a645ec1adabd"), "37165877000142", 5000m, "Fundo XYZ" });

            migrationBuilder.InsertData(
                table: "Fund",
                columns: new[] { "Id", "Cnpj", "MinInicialContribution", "Name" },
                values: new object[] { new Guid("1eb19aa1-3097-4635-af32-be9de020947a"), "10289932000150", 100000m, "Fundo XPTO" });

            migrationBuilder.CreateIndex(
                name: "IX_Moviment_FundId",
                table: "Moviment",
                column: "FundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moviment");

            migrationBuilder.DropTable(
                name: "Fund");
        }
    }
}
