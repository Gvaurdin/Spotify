using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spotify.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteUrlImageFromSongAddUrlImageForGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Songs");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Groups");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
