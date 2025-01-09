using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test3.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4e2574c-31b5-4e8c-bf22-71228944ad02", "AQAAAAIAAYagAAAAEOt2cjoA42ahbmtGDNORc6ExoIMSX/Y7dLEPkDz41PYQepPNsDUrAeb0GjXtJ2GbeQ==", "7e313afc-2dfd-4cb6-b013-ea83cd232602" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "242c7fd6-8bc5-4e48-bbd9-f80da38ea2fa", "AQAAAAIAAYagAAAAENvpQLFQpGD3P2TzDvH81D53k5P3Sj6WX4sbuJXrMjRrXzJ120aYB7GEgG+2li77Mw==", "074e088b-10d7-48fe-9429-905b6e32c809" });
        }
    }
}
