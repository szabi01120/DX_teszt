using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DX_teszt.Module.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartPriceDiscount",
                table: "OrderInRows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartPriceDiscount",
                table: "OrderInRows");
        }
    }
}
