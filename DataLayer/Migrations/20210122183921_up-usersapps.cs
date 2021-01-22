using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class upusersapps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "UserApps",
                columns: table => new
                {
                    UserAppsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoindeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppsAppId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApps", x => x.UserAppsId);
                    table.ForeignKey(
                        name: "FK_UserApps_Apps_AppsAppId",
                        column: x => x.AppsAppId,
                        principalTable: "Apps",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserApps_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserApps_AppsAppId",
                table: "UserApps",
                column: "AppsAppId");

            migrationBuilder.CreateIndex(
                name: "IX_UserApps_UsersUserId",
                table: "UserApps",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserApps");

            migrationBuilder.AddColumn<Guid>(
                name: "AppId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
