using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Medallion_Theater.Migrations
{
    /// <inheritdoc />
    public partial class production : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Productions_ProductionId",
                table: "Performances");

            migrationBuilder.DropIndex(
                name: "IX_Performances_ProductionId",
                table: "Performances");

            migrationBuilder.DropColumn(
                name: "ProductionId",
                table: "Performances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductionId",
                table: "Performances",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_ProductionId",
                table: "Performances",
                column: "ProductionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Productions_ProductionId",
                table: "Performances",
                column: "ProductionId",
                principalTable: "Productions",
                principalColumn: "ProductionId");
        }
    }
}
