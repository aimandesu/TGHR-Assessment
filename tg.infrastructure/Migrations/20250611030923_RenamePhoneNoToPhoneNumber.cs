using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tg.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamePhoneNoToPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE AspNetUsers 
                SET PhoneNumber = PhoneNo 
                WHERE PhoneNo IS NOT NULL AND PhoneNo != '' AND (PhoneNumber IS NULL OR PhoneNumber = '')
            ");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"
                UPDATE AspNetUsers 
                SET PhoneNo = PhoneNumber 
                WHERE PhoneNumber IS NOT NULL AND PhoneNumber != ''
            ");
        }
    }
}
