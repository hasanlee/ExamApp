using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExamDate" },
                values: new object[] { new DateTime(2023, 4, 15, 20, 54, 57, 613, DateTimeKind.Local).AddTicks(1031), new DateTime(2023, 4, 15, 20, 54, 57, 613, DateTimeKind.Local).AddTicks(1032) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 15, 20, 54, 57, 613, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 15, 20, 54, 57, 613, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentNo",
                table: "Students",
                column: "StudentNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LessonNo",
                table: "Lessons",
                column: "LessonNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_StudentNo",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_LessonNo",
                table: "Lessons");

            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExamDate" },
                values: new object[] { new DateTime(2023, 4, 15, 19, 38, 25, 585, DateTimeKind.Local).AddTicks(1775), new DateTime(2023, 4, 15, 19, 38, 25, 585, DateTimeKind.Local).AddTicks(1777) });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 15, 19, 38, 25, 585, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 4, 15, 19, 38, 25, 585, DateTimeKind.Local).AddTicks(3960));
        }
    }
}
