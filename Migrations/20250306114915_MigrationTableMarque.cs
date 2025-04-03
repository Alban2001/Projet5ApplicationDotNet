using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet5ApplicationDotNet.Migrations
{
    public partial class MigrationTableMarque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_ModelesVoiture_UnModeleVoitureId",
                table: "Voitures");

            migrationBuilder.DropTable(
                name: "ModelesVoiture");

            migrationBuilder.RenameColumn(
                name: "UnModeleVoitureId",
                table: "Voitures",
                newName: "UnModeleId");

            migrationBuilder.RenameIndex(
                name: "IX_Voitures_UnModeleVoitureId",
                table: "Voitures",
                newName: "IX_Voitures_UnModeleId");

            migrationBuilder.CreateTable(
                name: "Marques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modeles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UneMarqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modeles_Marques_UneMarqueId",
                        column: x => x.UneMarqueId,
                        principalTable: "Marques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Modeles_UneMarqueId",
                table: "Modeles",
                column: "UneMarqueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Modeles_UnModeleId",
                table: "Voitures",
                column: "UnModeleId",
                principalTable: "Modeles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Modeles_UnModeleId",
                table: "Voitures");

            migrationBuilder.DropTable(
                name: "Modeles");

            migrationBuilder.DropTable(
                name: "Marques");

            migrationBuilder.RenameColumn(
                name: "UnModeleId",
                table: "Voitures",
                newName: "UnModeleVoitureId");

            migrationBuilder.RenameIndex(
                name: "IX_Voitures_UnModeleId",
                table: "Voitures",
                newName: "IX_Voitures_UnModeleVoitureId");

            migrationBuilder.CreateTable(
                name: "ModelesVoiture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Annee = table.Column<int>(type: "int", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelesVoiture", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_ModelesVoiture_UnModeleVoitureId",
                table: "Voitures",
                column: "UnModeleVoitureId",
                principalTable: "ModelesVoiture",
                principalColumn: "Id");
        }
    }
}
