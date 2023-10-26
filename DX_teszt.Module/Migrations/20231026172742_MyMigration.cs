using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DX_teszt.Module.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelDifference",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContextId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifference", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderInHeaders",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<string>(type: "varchar(255)", nullable: true),
                    NoteHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteFooter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInHeaders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModelDifferenceAspects",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferenceAspects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModelDifferenceAspects_ModelDifference_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "ModelDifference",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderInRows",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderInHeaderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    PartNumber = table.Column<string>(type: "varchar(100)", nullable: true),
                    PartName = table.Column<string>(type: "varchar(200)", nullable: true),
                    PartDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartPrice = table.Column<double>(type: "float", nullable: false),
                    QTT = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInRows", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderInRows_OrderInHeaders_OrderInHeaderID",
                        column: x => x.OrderInHeaderID,
                        principalTable: "OrderInHeaders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelDifferenceAspects_OwnerID",
                table: "ModelDifferenceAspects",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInRows_OrderInHeaderID",
                table: "OrderInRows",
                column: "OrderInHeaderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelDifferenceAspects");

            migrationBuilder.DropTable(
                name: "OrderInRows");

            migrationBuilder.DropTable(
                name: "ModelDifference");

            migrationBuilder.DropTable(
                name: "OrderInHeaders");
        }
    }
}
