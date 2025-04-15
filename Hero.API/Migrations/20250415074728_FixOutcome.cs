using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hero.API.Migrations
{
    /// <inheritdoc />
    public partial class FixOutcome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionOutcomes_Conditions_ConditionId",
                table: "ConditionOutcomes");

            migrationBuilder.DropForeignKey(
                name: "FK_ConditionOutcomes_Scenes_NextSceneId",
                table: "ConditionOutcomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Conditions_Choices_ChoiceId",
                table: "Conditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Effects_Choices_ChoiceId",
                table: "Effects");

            migrationBuilder.DropForeignKey(
                name: "FK_Effects_ConditionOutcomes_ConditionOutcomeId",
                table: "Effects");

            migrationBuilder.DropIndex(
                name: "IX_Effects_ChoiceId",
                table: "Effects");

            migrationBuilder.DropIndex(
                name: "IX_ConditionOutcomes_ConditionId",
                table: "ConditionOutcomes");

            migrationBuilder.DropColumn(
                name: "ChoiceId",
                table: "Effects");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "ConditionOutcomes");

            migrationBuilder.RenameColumn(
                name: "ConditionOutcomeId",
                table: "Effects",
                newName: "OutcomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Effects_ConditionOutcomeId",
                table: "Effects",
                newName: "IX_Effects_OutcomeId");

            migrationBuilder.RenameColumn(
                name: "ChoiceId",
                table: "Conditions",
                newName: "OutcomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Conditions_ChoiceId",
                table: "Conditions",
                newName: "IX_Conditions_OutcomeId");

            migrationBuilder.RenameColumn(
                name: "NextSceneId",
                table: "ConditionOutcomes",
                newName: "ChoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ConditionOutcomes_NextSceneId",
                table: "ConditionOutcomes",
                newName: "IX_ConditionOutcomes_ChoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionOutcomes_Choices_ChoiceId",
                table: "ConditionOutcomes",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conditions_ConditionOutcomes_OutcomeId",
                table: "Conditions",
                column: "OutcomeId",
                principalTable: "ConditionOutcomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Effects_ConditionOutcomes_OutcomeId",
                table: "Effects",
                column: "OutcomeId",
                principalTable: "ConditionOutcomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionOutcomes_Choices_ChoiceId",
                table: "ConditionOutcomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Conditions_ConditionOutcomes_OutcomeId",
                table: "Conditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Effects_ConditionOutcomes_OutcomeId",
                table: "Effects");

            migrationBuilder.RenameColumn(
                name: "OutcomeId",
                table: "Effects",
                newName: "ConditionOutcomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Effects_OutcomeId",
                table: "Effects",
                newName: "IX_Effects_ConditionOutcomeId");

            migrationBuilder.RenameColumn(
                name: "OutcomeId",
                table: "Conditions",
                newName: "ChoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Conditions_OutcomeId",
                table: "Conditions",
                newName: "IX_Conditions_ChoiceId");

            migrationBuilder.RenameColumn(
                name: "ChoiceId",
                table: "ConditionOutcomes",
                newName: "NextSceneId");

            migrationBuilder.RenameIndex(
                name: "IX_ConditionOutcomes_ChoiceId",
                table: "ConditionOutcomes",
                newName: "IX_ConditionOutcomes_NextSceneId");

            migrationBuilder.AddColumn<int>(
                name: "ChoiceId",
                table: "Effects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConditionId",
                table: "ConditionOutcomes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Effects_ChoiceId",
                table: "Effects",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionOutcomes_ConditionId",
                table: "ConditionOutcomes",
                column: "ConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionOutcomes_Conditions_ConditionId",
                table: "ConditionOutcomes",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionOutcomes_Scenes_NextSceneId",
                table: "ConditionOutcomes",
                column: "NextSceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Conditions_Choices_ChoiceId",
                table: "Conditions",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
