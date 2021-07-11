using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Migrations.ApplicationDb
{
    public partial class DaerahNStesen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Daerah",
                columns: table => new
                {
                    IdDaerah = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daerah", x => x.IdDaerah);
                });

            migrationBuilder.CreateTable(
                name: "Stesen",
                columns: table => new
                {
                    IdStesen = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDaerah = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stesen", x => x.IdStesen);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daerah");

            migrationBuilder.DropTable(
                name: "Stesen");
        }
    }
}
