using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hero.API.Migrations
{
    /// <inheritdoc />
    public partial class ConditionOutcome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Scenes_SceneId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Conditions_Scenes_NextSceneId",
                table: "Conditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Effects_Choices_ChoiceId",
                table: "Effects");

            migrationBuilder.DropIndex(
                name: "IX_Conditions_NextSceneId",
                table: "Conditions");

            migrationBuilder.DropColumn(
                name: "NextSceneId",
                table: "Conditions");

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Effects",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceId",
                table: "Effects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConditionOutcomeId",
                table: "Effects",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceId",
                table: "Conditions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Conditions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SceneId",
                table: "Choices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ConditionOutcomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    NextSceneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionOutcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionOutcomes_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConditionOutcomes_Scenes_NextSceneId",
                        column: x => x.NextSceneId,
                        principalTable: "Scenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Effects_ConditionOutcomeId",
                table: "Effects",
                column: "ConditionOutcomeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionOutcomes_ConditionId",
                table: "ConditionOutcomes",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionOutcomes_NextSceneId",
                table: "ConditionOutcomes",
                column: "NextSceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Scenes_SceneId",
                table: "Choices",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Effects_Choices_ChoiceId",
                table: "Effects",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Effects_ConditionOutcomes_ConditionOutcomeId",
                table: "Effects",
                column: "ConditionOutcomeId",
                principalTable: "ConditionOutcomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Scenes_SceneId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Effects_Choices_ChoiceId",
                table: "Effects");

            migrationBuilder.DropForeignKey(
                name: "FK_Effects_ConditionOutcomes_ConditionOutcomeId",
                table: "Effects");

            migrationBuilder.DropTable(
                name: "ConditionOutcomes");

            migrationBuilder.DropIndex(
                name: "IX_Effects_ConditionOutcomeId",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "ConditionOutcomeId",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Conditions");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Effects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceId",
                table: "Effects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceId",
                table: "Conditions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextSceneId",
                table: "Conditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SceneId",
                table: "Choices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_NextSceneId",
                table: "Conditions",
                column: "NextSceneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Scenes_SceneId",
                table: "Choices",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conditions_Scenes_NextSceneId",
                table: "Conditions",
                column: "NextSceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Effects_Choices_ChoiceId",
                table: "Effects",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
