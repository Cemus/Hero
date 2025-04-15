using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hero.API.Migrations
{
    /// <inheritdoc />
    public partial class FixOutcomesName2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConditionOutcomes",
                table: "ConditionOutcomes");

            migrationBuilder.RenameTable(
                name: "ConditionOutcomes",
                newName: "Outcomes");

            migrationBuilder.RenameIndex(
                name: "IX_ConditionOutcomes_ChoiceId",
                table: "Outcomes",
                newName: "IX_Outcomes_ChoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Outcomes",
                table: "Outcomes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conditions_Outcomes_OutcomeId",
                table: "Conditions",
                column: "OutcomeId",
                principalTable: "Outcomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Effects_Outcomes_OutcomeId",
                table: "Effects",
                column: "OutcomeId",
                principalTable: "Outcomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Outcomes_Choices_ChoiceId",
                table: "Outcomes",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conditions_Outcomes_OutcomeId",
                table: "Conditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Effects_Outcomes_OutcomeId",
                table: "Effects");

            migrationBuilder.DropForeignKey(
                name: "FK_Outcomes_Choices_ChoiceId",
                table: "Outcomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Outcomes",
                table: "Outcomes");

            migrationBuilder.RenameTable(
                name: "Outcomes",
                newName: "ConditionOutcomes");

            migrationBuilder.RenameIndex(
                name: "IX_Outcomes_ChoiceId",
                table: "ConditionOutcomes",
                newName: "IX_ConditionOutcomes_ChoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConditionOutcomes",
                table: "ConditionOutcomes",
                column: "Id");

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
    }
}
