using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Planners_PlannerId",
                table: "Speaker");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Planners",
                newName: "PlannerId");

            migrationBuilder.AlterColumn<int>(
                name: "PlannerId",
                table: "Speaker",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Planners_PlannerId",
                table: "Speaker",
                column: "PlannerId",
                principalTable: "Planners",
                principalColumn: "PlannerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Planners_PlannerId",
                table: "Speaker");

            migrationBuilder.RenameColumn(
                name: "PlannerId",
                table: "Planners",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "PlannerId",
                table: "Speaker",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Planners_PlannerId",
                table: "Speaker",
                column: "PlannerId",
                principalTable: "Planners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
