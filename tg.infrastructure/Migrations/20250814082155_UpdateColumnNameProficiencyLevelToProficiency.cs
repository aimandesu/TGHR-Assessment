using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tg.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnNameProficiencyLevelToProficiency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProficiencyLevel",
                table: "Skills",
                newName: "Proficiency");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Proficiency",
                table: "Skills",
                newName: "ProficiencyLevel");
        }
    }
}
