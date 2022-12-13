using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVetAppointment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabinets_Shops_ShopId",
                table: "Cabinets");

            migrationBuilder.DropIndex(
                name: "IX_Cabinets_ShopId",
                table: "Cabinets");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Cabinets");

            migrationBuilder.AddColumn<Guid>(
                name: "CabinetId",
                table: "Shops",
                type: "TEXT",
                nullable: false,
                defaultValue: Guid.NewGuid());

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CabinetId",
                table: "Shops",
                column: "CabinetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Cabinets_CabinetId",
                table: "Shops",
                column: "CabinetId",
                principalTable: "Cabinets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Cabinets_CabinetId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_CabinetId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "Shops");

            migrationBuilder.AddColumn<Guid>(
                name: "ShopId",
                table: "Cabinets",
                type: "TEXT",
                nullable: false,
                defaultValue: Guid.NewGuid());

            migrationBuilder.CreateIndex(
                name: "IX_Cabinets_ShopId",
                table: "Cabinets",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabinets_Shops_ShopId",
                table: "Cabinets",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
