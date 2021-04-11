using Microsoft.EntityFrameworkCore.Migrations;

namespace Malacar.Migrations
{
    public partial class SecondMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarStation_Station_StationId",
                table: "CarStation");

            migrationBuilder.DropForeignKey(
                name: "FK_StationAddress_Station_StationId",
                table: "StationAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Station",
                table: "Station");

            migrationBuilder.RenameTable(
                name: "Station",
                newName: "Stations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stations",
                table: "Stations",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarStation_Stations_StationId",
                table: "CarStation",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationAddress_Stations_StationId",
                table: "StationAddress",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarStation_Stations_StationId",
                table: "CarStation");

            migrationBuilder.DropForeignKey(
                name: "FK_StationAddress_Stations_StationId",
                table: "StationAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stations",
                table: "Stations");

            migrationBuilder.RenameTable(
                name: "Stations",
                newName: "Station");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Station",
                table: "Station",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarStation_Station_StationId",
                table: "CarStation",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StationAddress_Station_StationId",
                table: "StationAddress",
                column: "StationId",
                principalTable: "Station",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
