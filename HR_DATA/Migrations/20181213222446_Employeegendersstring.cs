using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_DATA.Migrations
{
    public partial class Employeegendersstring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2018, 12, 14, 3, 24, 45, 324, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2018, 12, 14, 3, 24, 45, 325, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2018, 12, 14, 3, 24, 45, 325, DateTimeKind.Local), new DateTime(2018, 12, 14, 3, 24, 45, 325, DateTimeKind.Local), new byte[] { 146, 125, 132, 93, 185, 179, 133, 211, 168, 254, 235, 249, 249, 198, 149, 13, 79, 7, 24, 217, 99, 103, 73, 21, 179, 240, 39, 80, 250, 237, 143, 14, 91, 74, 30, 149, 236, 96, 57, 31, 90, 138, 24, 152, 44, 34, 213, 209, 158, 15, 30, 251, 54, 30, 191, 79, 41, 114, 242, 82, 23, 102, 177, 100 }, new byte[] { 70, 37, 97, 95, 115, 79, 112, 246, 176, 90, 249, 128, 56, 65, 5, 116, 246, 197, 69, 13, 59, 203, 220, 238, 46, 84, 226, 199, 90, 62, 67, 144, 8, 232, 27, 10, 93, 129, 93, 82, 89, 213, 103, 188, 48, 88, 168, 37, 29, 151, 67, 70, 81, 120, 114, 118, 203, 76, 20, 200, 97, 12, 154, 16, 228, 89, 203, 34, 238, 124, 174, 35, 30, 15, 68, 50, 46, 67, 22, 172, 223, 178, 77, 226, 201, 230, 100, 152, 192, 153, 117, 64, 245, 235, 28, 134, 189, 78, 88, 198, 95, 12, 28, 136, 193, 30, 140, 6, 125, 253, 181, 97, 4, 42, 123, 106, 91, 106, 237, 19, 14, 171, 81, 202, 1, 18, 5, 15 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2018, 12, 13, 22, 15, 47, 443, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2018, 12, 13, 22, 15, 47, 444, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2018, 12, 13, 22, 15, 47, 445, DateTimeKind.Local), new DateTime(2018, 12, 13, 22, 15, 47, 445, DateTimeKind.Local), new byte[] { 46, 98, 65, 227, 192, 16, 146, 2, 97, 193, 43, 85, 227, 73, 171, 151, 18, 220, 6, 225, 31, 0, 152, 200, 207, 160, 5, 130, 176, 211, 187, 229, 126, 213, 203, 48, 219, 92, 111, 125, 185, 69, 250, 19, 15, 91, 54, 130, 217, 155, 218, 179, 253, 147, 121, 69, 88, 99, 201, 123, 236, 160, 120, 152 }, new byte[] { 207, 150, 83, 240, 208, 228, 134, 88, 210, 219, 43, 242, 60, 206, 95, 150, 174, 150, 82, 217, 48, 190, 26, 18, 44, 87, 27, 228, 85, 220, 22, 180, 238, 233, 106, 92, 35, 173, 101, 73, 252, 141, 30, 130, 111, 18, 126, 239, 223, 36, 228, 208, 124, 55, 157, 40, 121, 190, 20, 251, 83, 227, 241, 108, 198, 236, 93, 114, 1, 157, 117, 115, 220, 7, 102, 131, 140, 115, 43, 176, 74, 184, 199, 45, 89, 81, 203, 207, 143, 92, 240, 195, 109, 255, 246, 67, 124, 52, 193, 175, 52, 9, 212, 62, 4, 247, 191, 128, 61, 231, 9, 26, 251, 22, 209, 109, 102, 11, 117, 191, 26, 216, 86, 54, 133, 178, 141, 79 } });
        }
    }
}
