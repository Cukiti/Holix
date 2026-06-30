using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holix.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePortfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Excerpt",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Excerpt",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Projects");
        }
    }
}
