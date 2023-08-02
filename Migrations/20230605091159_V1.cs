using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskDay2.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentDeptId",
                table: "Trainee",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TraId",
                table: "CrsResult",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CrsResultDegree",
                table: "CrsResult",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CrsId",
                table: "CrsResult",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_DepartmentDeptId",
                table: "Trainee",
                column: "DepartmentDeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_CrsId",
                table: "Instructor",
                column: "CrsId");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResult_CrsId",
                table: "CrsResult",
                column: "CrsId");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResult_TraId",
                table: "CrsResult",
                column: "TraId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DeptId",
                table: "Course",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_DeptId",
                table: "Course",
                column: "DeptId",
                principalTable: "Department",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResult_Course_CrsId",
                table: "CrsResult",
                column: "CrsId",
                principalTable: "Course",
                principalColumn: "CrsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResult_Trainee_TraId",
                table: "CrsResult",
                column: "TraId",
                principalTable: "Trainee",
                principalColumn: "TraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Course_CrsId",
                table: "Instructor",
                column: "CrsId",
                principalTable: "Course",
                principalColumn: "CrsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Department_DepartmentDeptId",
                table: "Trainee",
                column: "DepartmentDeptId",
                principalTable: "Department",
                principalColumn: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_DeptId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CrsResult_Course_CrsId",
                table: "CrsResult");

            migrationBuilder.DropForeignKey(
                name: "FK_CrsResult_Trainee_TraId",
                table: "CrsResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Course_CrsId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Department_DepartmentDeptId",
                table: "Trainee");

            migrationBuilder.DropIndex(
                name: "IX_Trainee_DepartmentDeptId",
                table: "Trainee");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_CrsId",
                table: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_CrsResult_CrsId",
                table: "CrsResult");

            migrationBuilder.DropIndex(
                name: "IX_CrsResult_TraId",
                table: "CrsResult");

            migrationBuilder.DropIndex(
                name: "IX_Course_DeptId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptId",
                table: "Trainee");

            migrationBuilder.AlterColumn<string>(
                name: "TraId",
                table: "CrsResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CrsResultDegree",
                table: "CrsResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CrsId",
                table: "CrsResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
