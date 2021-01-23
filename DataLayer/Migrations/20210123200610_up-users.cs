using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class upusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserProfileImageName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Owner",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsersUserId",
                table: "Owner",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owner_UsersUserId",
                table: "Owner",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owner_Users_UsersUserId",
                table: "Owner",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owner_Users_UsersUserId",
                table: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Owner_UsersUserId",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "UserProfileImageName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Owner");
        }
    }
}
