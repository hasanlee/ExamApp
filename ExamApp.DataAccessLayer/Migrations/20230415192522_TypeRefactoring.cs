using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamApp.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class TypeRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "StudentNo",
                table: "Students",
                type: "bigint",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,0)");

            migrationBuilder.AlterColumn<byte>(
                name: "ClassNo",
                table: "Students",
                type: "tinyint",
                maxLength: 2,
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,0)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<byte>(
                name: "ClassNo",
                table: "Lessons",
                type: "tinyint",
                maxLength: 2,
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,0)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<byte>(
                name: "Mark",
                table: "Exams",
                type: "tinyint",
                maxLength: 1,
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(decimal),
                oldType: "decimal(1,0)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExamDate",
                table: "Exams",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExamDate", "Mark" },
                values: new object[] { new DateTime(2023, 4, 15, 23, 25, 22, 589, DateTimeKind.Local).AddTicks(3254), new DateTime(2023, 4, 15, 23, 25, 22, 589, DateTimeKind.Local).AddTicks(3255), (byte)5 });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClassNo", "CreatedAt" },
                values: new object[] { (byte)1, new DateTime(2023, 4, 15, 23, 25, 22, 589, DateTimeKind.Local).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClassNo", "CreatedAt", "StudentNo" },
                values: new object[] { (byte)1, new DateTime(2023, 4, 15, 23, 25, 22, 590, DateTimeKind.Local).AddTicks(3342), 12L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "StudentNo",
                table: "Students",
                type: "decimal(5,0)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<decimal>(
                name: "ClassNo",
                table: "Students",
                type: "decimal(2,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 2,
                oldDefaultValue: (byte)0);

            migrationBuilder.AlterColumn<decimal>(
                name: "ClassNo",
                table: "Lessons",
                type: "decimal(2,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 2,
                oldDefaultValue: (byte)0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Mark",
                table: "Exams",
                type: "decimal(1,0)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldMaxLength: 1,
                oldDefaultValue: (byte)0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExamDate",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Exams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExamDate", "Mark" },
                values: new object[] { new DateTime(2023, 4, 15, 20, 54, 57, 613, DateTimeKind.Local).AddTicks(1031), new DateTime(2023, 4, 15, 20, 54, 57, 613, DateTimeKind.Local).AddTicks(1032), 5m });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClassNo", "CreatedAt" },
                values: new object[] { 1m, new DateTime(2023, 4, 15, 20, 54, 57, 613, DateTimeKind.Local).AddTicks(2644) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClassNo", "CreatedAt", "StudentNo" },
                values: new object[] { 1m, new DateTime(2023, 4, 15, 20, 54, 57, 613, DateTimeKind.Local).AddTicks(4311), 12m });
        }
    }
}
