using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendOrkletti.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    cd_profile_id = table.Column<string>(type: "text", nullable: false),
                    ds_fist_name = table.Column<string>(type: "text", nullable: true),
                    ds_last_name = table.Column<string>(type: "text", nullable: true),
                    bl_profile_image = table.Column<byte[]>(type: "bytea", nullable: true),
                    ds_bio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.cd_profile_id);
                });

            migrationBuilder.CreateTable(
                name: "community",
                columns: table => new
                {
                    cd_community = table.Column<Guid>(type: "uuid", nullable: false),
                    ds_title = table.Column<string>(type: "text", nullable: true),
                    bl_image = table.Column<byte[]>(type: "bytea", nullable: true),
                    ds_description = table.Column<string>(type: "text", nullable: true),
                    cd_profile_id = table.Column<string>(type: "text", nullable: true),
                    dt_createdAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_community", x => x.cd_community);
                    table.ForeignKey(
                        name: "FK_community_profile_cd_profile_id",
                        column: x => x.cd_profile_id,
                        principalTable: "profile",
                        principalColumn: "cd_profile_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_community_cd_profile_id",
                table: "community",
                column: "cd_profile_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "community");

            migrationBuilder.DropTable(
                name: "profile");
        }
    }
}
