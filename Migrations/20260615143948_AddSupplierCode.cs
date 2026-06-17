using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationeryWeek3.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddSupplierCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                table: "Stationeries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Stationeries",
                keyColumn: "Id",
                keyValue: 1,
                column: "SupplierCode",
                value: "SUP001");

            migrationBuilder.UpdateData(
                table: "Stationeries",
                keyColumn: "Id",
                keyValue: 2,
                column: "SupplierCode",
                value: "SUP002");

            migrationBuilder.UpdateData(
                table: "Stationeries",
                keyColumn: "Id",
                keyValue: 3,
                column: "SupplierCode",
                value: "SUP003");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierCode",
                table: "Stationeries");
        }
    }
}
