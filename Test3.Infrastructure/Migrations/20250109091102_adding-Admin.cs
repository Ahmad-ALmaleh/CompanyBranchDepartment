using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test3.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "63daeb90-38fb-4f56-ade4-0ad0865ce008" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c460ade-9c45-4753-afc8-a13541414d00", "AQAAAAIAAYagAAAAECV9ah9V2HQtJm9vuLL+u2/PWYr66Xh864Lo38gONvChLBRnB8mBbmg09sOGHPJiXg==", "2b260a72-0a2f-4ee1-8b2f-8ab799c6e54a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "369f6148-340a-4534-80cc-91c39deaacec", "AQAAAAIAAYagAAAAEFE5pnMWtwc1FWaZJJDisoawjkvivESfKf+QuRN4s+fTv0ViAEyulRCj9G8dzklKcw==", "1ee52169-083f-45a4-a821-1102ac19d864" });

            migrationBuilder.UpdateData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 9, 11, 1, 16, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 9, 11, 1, 16, DateTimeKind.Utc).AddTicks(3507));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 9, 11, 1, 16, DateTimeKind.Utc).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 9, 11, 1, 16, DateTimeKind.Utc).AddTicks(4072));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbc43a8e-f7bb-4445-baaf-1add431ffbbf", "63daeb90-38fb-4f56-ade4-0ad0865ce008" });

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

            migrationBuilder.UpdateData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 7, 54, 6, 602, DateTimeKind.Utc).AddTicks(8977));

            migrationBuilder.UpdateData(
                table: "Branchs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 7, 54, 6, 602, DateTimeKind.Utc).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 7, 54, 6, 602, DateTimeKind.Utc).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 7, 54, 6, 602, DateTimeKind.Utc).AddTicks(9274));
        }
    }
}
