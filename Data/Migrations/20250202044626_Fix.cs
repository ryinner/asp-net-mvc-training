using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspDotNetMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Infomation",
                table: "Companies",
                newName: "Information");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Information",
                table: "Companies",
                newName: "Infomation");
        }
    }
}
