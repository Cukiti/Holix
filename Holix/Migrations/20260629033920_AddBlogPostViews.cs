using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holix.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogPostViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "BlogPosts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "BlogPosts");
        }
    }
}
