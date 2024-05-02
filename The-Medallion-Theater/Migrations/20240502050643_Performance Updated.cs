using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Medallion_Theater.Migrations
{
    /// <inheritdoc />
    public partial class PerformanceUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductionID",
                table: "Performances",
                newName: "ProductionName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductionName",
                table: "Performances",
                newName: "ProductionID");
        }
    }
}
