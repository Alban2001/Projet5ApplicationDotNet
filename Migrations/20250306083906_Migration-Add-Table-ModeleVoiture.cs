using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet5ApplicationDotNet.Migrations
{
    public partial class MigrationAddTableModeleVoiture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marque",
                table: "Voitures");

            migrationBuilder.DropColumn(
                name: "Modele",
                table: "Voitures");

            migrationBuilder.RenameColumn(
                name: "Annee",
                table: "Voitures",
                newName: "UnModeleVoitureId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Voitures_UnModeleVoitureId",
                table: "Voitures",
                column: "UnModeleVoitureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_ModelesVoiture_UnModeleVoitureId",
                table: "Voitures",
                column: "UnModeleVoitureId",
                principalTable: "ModelesVoiture",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_ModelesVoiture_UnModeleVoitureId",
                table: "Voitures");

            migrationBuilder.DropTable(
                name: "ModelesVoiture");

            migrationBuilder.DropIndex(
                name: "IX_Voitures_UnModeleVoitureId",
                table: "Voitures");

            migrationBuilder.RenameColumn(
                name: "UnModeleVoitureId",
                table: "Voitures",
                newName: "Annee");

            migrationBuilder.AddColumn<string>(
                name: "Marque",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modele",
                table: "Voitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
