using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StationeryWeek3.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stationeries_Brands_BrandId",
                table: "Stationeries");

            migrationBuilder.DropForeignKey(
                name: "FK_Stationeries_Categories_CategoryId",
                table: "Stationeries");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Stationeries");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Stationeries");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Stationeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Stationeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Thiên Long" },
                    { 2, "Hồng Hà" },
                    { 3, "FlexOffice" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bút" },
                    { 2, "Vở" },
                    { 3, "Dụng cụ" }
                });

            migrationBuilder.InsertData(
                table: "Stationeries",
                columns: new[] { "Id", "BrandId", "CategoryId", "Code", "LastUpdatedAt", "MinStock", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, "ST001", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Bút bi Thiên Long", 5000m, 50 },
                    { 2, 2, 2, "ST002", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Vở 200 trang", 18000m, 8 },
                    { 3, 3, 3, "ST003", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Thước kẻ 30cm", 12000m, 40 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Stationeries_Brands_BrandId",
                table: "Stationeries",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stationeries_Categories_CategoryId",
                table: "Stationeries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stationeries_Brands_BrandId",
                table: "Stationeries");

            migrationBuilder.DropForeignKey(
                name: "FK_Stationeries_Categories_CategoryId",
                table: "Stationeries");

            migrationBuilder.DeleteData(
                table: "Stationeries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stationeries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stationeries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Stationeries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Stationeries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Stationeries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Stationeries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Stationeries_Brands_BrandId",
                table: "Stationeries",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stationeries_Categories_CategoryId",
                table: "Stationeries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
