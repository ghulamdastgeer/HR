using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_DATA.Migrations
{
    public partial class EmployeeImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Caption = table.Column<string>(maxLength: 50, nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Url = table.Column<string>(maxLength: 255, nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeImages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeImages_EmployeeId",
                table: "EmployeeImages",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeImages");

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
    }
}
