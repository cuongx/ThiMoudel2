using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLHV.Migrations
{
    public partial class CreateLopHocTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lop",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "LopHocId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    LopHocId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LopHocName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.LopHocId);
                });

            migrationBuilder.InsertData(
                table: "LopHoc",
                columns: new[] { "LopHocId", "LopHocName" },
                values: new object[] { 1, "12A4" });

            migrationBuilder.InsertData(
                table: "LopHoc",
                columns: new[] { "LopHocId", "LopHocName" },
                values: new object[] { 2, "12A4" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1,
                column: "LopHocId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "Email", "GioiTinh", "HoTen", "LopHocId", "NgaySinh" },
                values: new object[] { 2, "xuanc55@gmail.com", 0, "Nguyễn Đinh Tuấn", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Students_LopHocId",
                table: "Students",
                column: "LopHocId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_LopHoc_LopHocId",
                table: "Students",
                column: "LopHocId",
                principalTable: "LopHoc",
                principalColumn: "LopHocId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_LopHoc_LopHocId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropIndex(
                name: "IX_Students_LopHocId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "LopHocId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Lop",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1,
                column: "Lop",
                value: "12A4");
        }
    }
}
