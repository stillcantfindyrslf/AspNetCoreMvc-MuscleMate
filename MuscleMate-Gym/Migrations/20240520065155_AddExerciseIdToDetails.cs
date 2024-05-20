using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuscleMate_Gym.Migrations
{
    public partial class AddExerciseIdToDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Details_DetailsId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_DetailsId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Details_ExerciseId",
                table: "Details",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Exercises_ExerciseId",
                table: "Details",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Exercises_ExerciseId",
                table: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Details_ExerciseId",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Details");

            migrationBuilder.AddColumn<int>(
                name: "DetailsId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_DetailsId",
                table: "Exercises",
                column: "DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Details_DetailsId",
                table: "Exercises",
                column: "DetailsId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
