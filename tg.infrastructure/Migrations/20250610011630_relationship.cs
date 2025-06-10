using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tg.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_AspNetUsers_UserModelId",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_AspNetUsers_UserModelId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UserModelId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_UserModelId",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Hobbies");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Skills",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Hobbies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserId",
                table: "Skills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_UserId",
                table: "Hobbies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_AspNetUsers_UserId",
                table: "Hobbies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_AspNetUsers_UserId",
                table: "Skills",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_AspNetUsers_UserId",
                table: "Hobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_AspNetUsers_UserId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UserId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_UserId",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hobbies");

            migrationBuilder.AddColumn<string>(
                name: "UserModelId",
                table: "Skills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModelId",
                table: "Hobbies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserModelId",
                table: "Skills",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_UserModelId",
                table: "Hobbies",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_AspNetUsers_UserModelId",
                table: "Hobbies",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_AspNetUsers_UserModelId",
                table: "Skills",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
