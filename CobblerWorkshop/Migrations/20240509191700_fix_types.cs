using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CobblerWorkshop.Migrations
{
    /// <inheritdoc />
    public partial class fix_types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepairTaskId",
                table: "RepairTaskPositions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairTaskPositions_RepairTaskId",
                table: "RepairTaskPositions",
                column: "RepairTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTaskPositions_RepairTasks_RepairTaskId",
                table: "RepairTaskPositions",
                column: "RepairTaskId",
                principalTable: "RepairTasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairTaskPositions_RepairTasks_RepairTaskId",
                table: "RepairTaskPositions");

            migrationBuilder.DropIndex(
                name: "IX_RepairTaskPositions_RepairTaskId",
                table: "RepairTaskPositions");

            migrationBuilder.DropColumn(
                name: "RepairTaskId",
                table: "RepairTaskPositions");
        }
    }
}
