using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hero.API.Migrations
{
    /// <inheritdoc />
    public partial class PlayerScene : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SceneId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_SceneId",
                table: "Players",
                column: "SceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Scenes_SceneId",
                table: "Players",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Scenes_SceneId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_SceneId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SceneId",
                table: "Players");
        }
    }
}
