using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hero.API.Migrations
{
    /// <inheritdoc />
    public partial class RepeatableChoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRepeatable",
                table: "Choices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRepeatable",
                table: "Choices");
        }
    }
}
