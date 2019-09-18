using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _05_Fiap.Web.AspNet.Migrations
{
    public partial class CampeonatoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreinadorId",
                table: "Times",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    CampeonatoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Preciacao = table.Column<decimal>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    TipoCampeonato = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonato", x => x.CampeonatoId);
                });

            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    JogadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<int>(nullable: false),
                    Altura = table.Column<float>(nullable: false),
                    TimeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.JogadorId);
                    table.ForeignKey(
                        name: "FK_Jogador_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "TimeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treinador",
                columns: table => new
                {
                    TreinadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Salario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinador", x => x.TreinadorId);
                });

            migrationBuilder.CreateTable(
                name: "CampeonatoTime",
                columns: table => new
                {
                    TimeId = table.Column<int>(nullable: false),
                    CampeonatoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampeonatoTime", x => new { x.CampeonatoId, x.TimeId });
                    table.ForeignKey(
                        name: "FK_CampeonatoTime_Times_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Times",
                        principalColumn: "TimeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampeonatoTime_Campeonato_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Campeonato",
                        principalColumn: "CampeonatoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Times_TreinadorId",
                table: "Times",
                column: "TreinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_CampeonatoTime_TimeId",
                table: "CampeonatoTime",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogador_TimeId",
                table: "Jogador",
                column: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Times_Treinador_TreinadorId",
                table: "Times",
                column: "TreinadorId",
                principalTable: "Treinador",
                principalColumn: "TreinadorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Times_Treinador_TreinadorId",
                table: "Times");

            migrationBuilder.DropTable(
                name: "CampeonatoTime");

            migrationBuilder.DropTable(
                name: "Jogador");

            migrationBuilder.DropTable(
                name: "Treinador");

            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropIndex(
                name: "IX_Times_TreinadorId",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "TreinadorId",
                table: "Times");
        }
    }
}
