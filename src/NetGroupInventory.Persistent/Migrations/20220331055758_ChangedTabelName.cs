using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetGroupInventory.Persistent.Migrations
{
    public partial class ChangedTabelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_StoargeLevel_StorageLevelId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "StoargeLevel");

            migrationBuilder.CreateTable(
                name: "StorageLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLevel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StorageLevel_CreatedBy",
                table: "StorageLevel",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_StorageLevel_StorageLevelId",
                table: "Inventory",
                column: "StorageLevelId",
                principalTable: "StorageLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_StorageLevel_StorageLevelId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "StorageLevel");

            migrationBuilder.CreateTable(
                name: "StoargeLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Level = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ModifiedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoargeLevel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoargeLevel_CreatedBy",
                table: "StoargeLevel",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_StoargeLevel_StorageLevelId",
                table: "Inventory",
                column: "StorageLevelId",
                principalTable: "StoargeLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
