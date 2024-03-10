using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendOrkletti.Migrations
{
    /// <inheritdoc />
    public partial class profileMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ds_fistname = table.Column<string>(type: "text", nullable: true),
                    ds_lastname = table.Column<string>(type: "text", nullable: true),
                    bl_profileimage = table.Column<byte[]>(type: "bytea", nullable: true),
                    ds_bio = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profile");
        }
    }
}
