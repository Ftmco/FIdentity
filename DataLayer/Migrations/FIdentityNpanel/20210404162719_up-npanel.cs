using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.FIdentityNpanel
{
    public partial class upnpanel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "UsersSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "UsersSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UsersSessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsersUserId",
                table: "UsersSessions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActiveCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActiveDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RolesRoleId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsersUserId",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "UserApplications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationsApplicationId",
                table: "UserApplications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserApplications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsersUserId",
                table: "UserApplications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoleTitle",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PageId",
                table: "RoleAccessPages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PagesPageId",
                table: "RoleAccessPages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "RoleAccessPages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RolesRoleId",
                table: "RoleAccessPages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PageName",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSessions_UsersUserId",
                table: "UsersSessions",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RolesRoleId",
                table: "UserRoles",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UsersUserId",
                table: "UserRoles",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserApplications_ApplicationsApplicationId",
                table: "UserApplications",
                column: "ApplicationsApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserApplications_UsersUserId",
                table: "UserApplications",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccessPages_PagesPageId",
                table: "RoleAccessPages",
                column: "PagesPageId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccessPages_RolesRoleId",
                table: "RoleAccessPages",
                column: "RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccessPages_Pages_PagesPageId",
                table: "RoleAccessPages",
                column: "PagesPageId",
                principalTable: "Pages",
                principalColumn: "PageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAccessPages_Roles_RolesRoleId",
                table: "RoleAccessPages",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserApplications_Applications_ApplicationsApplicationId",
                table: "UserApplications",
                column: "ApplicationsApplicationId",
                principalTable: "Applications",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserApplications_Users_UsersUserId",
                table: "UserApplications",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RolesRoleId",
                table: "UserRoles",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UsersUserId",
                table: "UserRoles",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSessions_Users_UsersUserId",
                table: "UsersSessions",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccessPages_Pages_PagesPageId",
                table: "RoleAccessPages");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAccessPages_Roles_RolesRoleId",
                table: "RoleAccessPages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserApplications_Applications_ApplicationsApplicationId",
                table: "UserApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserApplications_Users_UsersUserId",
                table: "UserApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RolesRoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UsersUserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersSessions_Users_UsersUserId",
                table: "UsersSessions");

            migrationBuilder.DropIndex(
                name: "IX_UsersSessions_UsersUserId",
                table: "UsersSessions");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_RolesRoleId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UsersUserId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserApplications_ApplicationsApplicationId",
                table: "UserApplications");

            migrationBuilder.DropIndex(
                name: "IX_UserApplications_UsersUserId",
                table: "UserApplications");

            migrationBuilder.DropIndex(
                name: "IX_RoleAccessPages_PagesPageId",
                table: "RoleAccessPages");

            migrationBuilder.DropIndex(
                name: "IX_RoleAccessPages_RolesRoleId",
                table: "RoleAccessPages");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "UsersSessions");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "UsersSessions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersSessions");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "UsersSessions");

            migrationBuilder.DropColumn(
                name: "ActiveCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ActiveDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "UserApplications");

            migrationBuilder.DropColumn(
                name: "ApplicationsApplicationId",
                table: "UserApplications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserApplications");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "UserApplications");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleTitle",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "RoleAccessPages");

            migrationBuilder.DropColumn(
                name: "PagesPageId",
                table: "RoleAccessPages");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "RoleAccessPages");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                table: "RoleAccessPages");

            migrationBuilder.DropColumn(
                name: "PageName",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Pages");
        }
    }
}
