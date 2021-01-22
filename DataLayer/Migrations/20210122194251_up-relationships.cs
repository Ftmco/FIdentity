using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class uprelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TokensTokenId",
                table: "LoginLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "LoginLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsersUserId",
                table: "LoginLogs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginLogs_TokensTokenId",
                table: "LoginLogs",
                column: "TokensTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginLogs_UsersUserId",
                table: "LoginLogs",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginLogs_Tokens_TokensTokenId",
                table: "LoginLogs",
                column: "TokensTokenId",
                principalTable: "Tokens",
                principalColumn: "TokenId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginLogs_Users_UsersUserId",
                table: "LoginLogs",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginLogs_Tokens_TokensTokenId",
                table: "LoginLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginLogs_Users_UsersUserId",
                table: "LoginLogs");

            migrationBuilder.DropIndex(
                name: "IX_LoginLogs_TokensTokenId",
                table: "LoginLogs");

            migrationBuilder.DropIndex(
                name: "IX_LoginLogs_UsersUserId",
                table: "LoginLogs");

            migrationBuilder.DropColumn(
                name: "TokensTokenId",
                table: "LoginLogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LoginLogs");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "LoginLogs");
        }
    }
}
