using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations.ApplicationDb
{
    public partial class AddTableBarang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barang",
                columns: table => new
                {
                    IdBarang = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdStesen = table.Column<long>(type: "bigint", nullable: false),
                    IdDaerah = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    TarikhTerima = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarikhSerah = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TarikhTamat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barang", x => x.IdBarang);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barang");
        }
    }
}
