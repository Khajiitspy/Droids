using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Droids.Migrations
{
    /// <inheritdoc />
    public partial class UserTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "tbl_task",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_task_UserId",
                table: "tbl_task",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_task_AspNetUsers_UserId",
                table: "tbl_task",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_task_AspNetUsers_UserId",
                table: "tbl_task");

            migrationBuilder.DropIndex(
                name: "IX_tbl_task_UserId",
                table: "tbl_task");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tbl_task");
        }
    }
}
