using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class LectureName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Lectures");

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "Lectures");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
