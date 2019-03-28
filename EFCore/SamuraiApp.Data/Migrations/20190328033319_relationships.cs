using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Battles_BattleId",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_BattleId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Samurais");

            migrationBuilder.CreateTable(
                name: "SamuraiBattles",
                columns: table => new
                {
                    SamuraiId = table.Column<int>(nullable: false),
                    BattleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SamuraiBattles", x => new { x.SamuraiId, x.BattleId });
                    table.ForeignKey(
                        name: "FK_SamuraiBattles_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SamuraiBattles_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecretIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RealName = table.Column<string>(nullable: true),
                    SamuraiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretIdentities_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattles_BattleId",
                table: "SamuraiBattles",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_SamuraiId",
                table: "SecretIdentities",
                column: "SamuraiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SamuraiBattles");

            migrationBuilder.DropTable(
                name: "SecretIdentities");

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Samurais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_BattleId",
                table: "Samurais",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Battles_BattleId",
                table: "Samurais",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
