using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class upapps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppFeatures",
                columns: table => new
                {
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FeatureName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ShurtDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFeatures", x => x.FeatureId);
                });

            migrationBuilder.CreateTable(
                name: "AppSelectedFeatures",
                columns: table => new
                {
                    SelectedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppsAppId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppFeaturesFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSelectedFeatures", x => x.SelectedId);
                    table.ForeignKey(
                        name: "FK_AppSelectedFeatures_AppFeatures_AppFeaturesFeatureId",
                        column: x => x.AppFeaturesFeatureId,
                        principalTable: "AppFeatures",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppSelectedFeatures_Apps_AppsAppId",
                        column: x => x.AppsAppId,
                        principalTable: "Apps",
                        principalColumn: "AppId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppSelectedFeatures_AppFeaturesFeatureId",
                table: "AppSelectedFeatures",
                column: "AppFeaturesFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_AppSelectedFeatures_AppsAppId",
                table: "AppSelectedFeatures",
                column: "AppsAppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSelectedFeatures");

            migrationBuilder.DropTable(
                name: "AppFeatures");
        }
    }
}
