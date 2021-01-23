using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class addowners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppId",
                table: "UserApps");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Apps",
                newName: "OwnerId");

            migrationBuilder.AddColumn<string>(
                name: "AppToken",
                table: "UserApps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "AppToken",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Apps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apps_OwnerId",
                table: "Apps",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Owner_OwnerId",
                table: "Apps",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Owner_OwnerId",
                table: "Apps");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Apps_OwnerId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "AppToken",
                table: "UserApps");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Apps");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Apps",
                newName: "Owner");

            migrationBuilder.AddColumn<Guid>(
                name: "AppId",
                table: "UserApps",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "AppToken",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
