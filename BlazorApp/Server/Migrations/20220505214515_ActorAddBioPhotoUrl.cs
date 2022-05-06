using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.Server.Migrations
{
    public partial class ActorAddBioPhotoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Actors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Actors");
        }
    }
}
