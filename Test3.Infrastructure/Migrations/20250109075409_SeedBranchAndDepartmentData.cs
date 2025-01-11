using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test3.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedBranchAndDepartmentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e128eaf9-e48e-4a31-b7e5-686732a89c8a", "AQAAAAIAAYagAAAAENAR2xTDwG+0Ipw+PqFBV+zgU+tiyQEl5dzDb9iS1W4YGeM8Lg/KbAkhLEbCKQkhpg==", "31c0debe-5bc3-4491-85c4-2109a1b72c6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "218b8978-06c9-4a49-a236-c2cf7d66658b", "AQAAAAIAAYagAAAAEMDJOaWqahKsp8drYkQiRD11XrvePRdNTo37xSa99KfBzGR5rQJle76lJK4xY9IaOg==", "9190ae08-19d6-47be-b607-b076a270a1f3" });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 9, 7, 54, 6, 602, DateTimeKind.Utc).AddTicks(8977), "Head Office", null },
                    { 2, new DateTime(2025, 1, 9, 7, 54, 6, 602, DateTimeKind.Utc).AddTicks(8988), "Branch 1", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 9, 7, 54, 6, 602, DateTimeKind.Utc).AddTicks(9271), "HR", null },
                    { 2, new DateTime(2025, 1, 9, 7, 54, 6, 602, DateTimeKind.Utc).AddTicks(9274), "IT", null }
                });

            migrationBuilder.InsertData(
                table: "BranchDepartments",
                columns: new[] { "Id", "BranchId", "DepartmentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BranchDepartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BranchDepartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BranchDepartments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3742b6ac-27bd-4ee4-bbac-f106ab276f37", "AQAAAAIAAYagAAAAECxdYpvCrG+yWrTZOc8Sgq0b3ZdVrmhfoSAXoyfNwW1HHcG61EZS32WJTBrYqAej/A==", "ead5288f-1cd4-416d-bee7-f484e8a771c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f28c1a28-e079-43dc-81b5-0e9fbacb384a", "AQAAAAIAAYagAAAAENSHqkCmj+E32oaUV2MIfPs2FjcuOti1rOGwW1ZysWVcCHrYR0QgGSkjFTGRCeIqPQ==", "5f2cd567-4e11-402e-966d-c2608e304d57" });
        }
    }
}
