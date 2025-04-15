using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hero.API.Migrations
{
    /// <inheritdoc />
    public partial class AddOutcomeFeedBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeedBack",
                table: "Outcomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedBack",
                table: "Outcomes");
        }
    }
}
