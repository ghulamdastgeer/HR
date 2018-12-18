using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_DATA.Migrations
{
    public partial class removeuniqueconstrainattendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attendance_Day_EmployeeId",
                table: "Attendance");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2018, 12, 6, 13, 46, 40, 940, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2018, 12, 6, 13, 46, 40, 940, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2018, 12, 6, 13, 46, 40, 940, DateTimeKind.Local), new DateTime(2018, 12, 6, 13, 46, 40, 940, DateTimeKind.Local), new byte[] { 156, 103, 233, 215, 154, 5, 145, 179, 69, 241, 16, 115, 43, 206, 161, 93, 196, 136, 167, 156, 216, 18, 241, 107, 77, 209, 92, 234, 101, 17, 164, 89, 255, 51, 164, 202, 36, 70, 4, 171, 19, 38, 251, 61, 38, 184, 21, 114, 218, 66, 124, 123, 248, 121, 134, 47, 101, 79, 40, 71, 32, 242, 210, 97 }, new byte[] { 50, 166, 94, 182, 76, 121, 151, 149, 231, 31, 83, 2, 170, 78, 215, 72, 78, 105, 70, 93, 3, 2, 4, 129, 57, 60, 59, 180, 193, 228, 162, 117, 91, 145, 4, 169, 66, 238, 79, 134, 118, 189, 12, 240, 199, 21, 230, 240, 120, 68, 151, 246, 33, 239, 126, 162, 220, 100, 251, 192, 140, 20, 177, 39, 249, 39, 119, 194, 121, 210, 125, 244, 27, 12, 8, 109, 155, 44, 55, 83, 113, 91, 85, 167, 168, 19, 175, 223, 68, 243, 246, 223, 173, 38, 46, 203, 244, 32, 34, 168, 208, 148, 73, 184, 42, 78, 166, 255, 202, 154, 11, 56, 53, 226, 158, 243, 164, 79, 24, 56, 246, 208, 190, 171, 127, 160, 36, 163 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2018, 12, 6, 12, 34, 45, 482, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2018, 12, 6, 12, 34, 45, 482, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2018, 12, 6, 12, 34, 45, 483, DateTimeKind.Local), new DateTime(2018, 12, 6, 12, 34, 45, 483, DateTimeKind.Local), new byte[] { 91, 172, 184, 86, 49, 187, 31, 147, 19, 2, 89, 161, 169, 105, 81, 35, 103, 79, 2, 228, 49, 164, 172, 36, 100, 17, 216, 198, 184, 141, 59, 52, 68, 239, 127, 8, 0, 108, 153, 164, 232, 96, 130, 173, 49, 37, 201, 165, 112, 251, 91, 89, 248, 75, 115, 44, 71, 243, 81, 222, 172, 116, 75, 41 }, new byte[] { 240, 10, 222, 113, 152, 200, 36, 75, 129, 100, 85, 87, 151, 218, 193, 9, 34, 114, 224, 91, 227, 241, 97, 147, 56, 170, 4, 50, 51, 205, 190, 40, 55, 17, 82, 181, 171, 99, 153, 159, 15, 172, 117, 1, 32, 37, 184, 204, 245, 180, 144, 75, 62, 148, 139, 3, 3, 250, 108, 173, 148, 212, 253, 2, 19, 134, 108, 63, 80, 236, 213, 162, 173, 29, 144, 72, 231, 197, 95, 175, 223, 174, 196, 135, 63, 151, 42, 220, 50, 153, 66, 246, 52, 219, 232, 246, 101, 60, 88, 62, 102, 173, 211, 66, 223, 119, 180, 104, 151, 100, 155, 233, 81, 240, 216, 108, 1, 34, 14, 220, 122, 56, 109, 145, 202, 224, 64, 175 } });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Day_EmployeeId",
                table: "Attendance",
                columns: new[] { "Day", "EmployeeId" },
                unique: true);
        }
    }
}
