using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Medallion_Theater.Migrations
{
    /// <inheritdoc />
    public partial class PerformanceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalRevenue",
                table: "Performances",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRevenue",
                table: "Performances");
        }
    }
}
