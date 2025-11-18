using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_SchoolClasses_SchoolClassId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses");

            migrationBuilder.RenameTable(
                name: "SchoolClasses",
                newName: "Classrooms");

            migrationBuilder.RenameColumn(
                name: "SchoolClassId",
                table: "Students",
                newName: "ClassroomId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SchoolClassId",
                table: "Students",
                newName: "IX_Students_ClassroomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classrooms",
                table: "Classrooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classrooms_ClassroomId",
                table: "Students",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classrooms_ClassroomId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classrooms",
                table: "Classrooms");

            migrationBuilder.RenameTable(
                name: "Classrooms",
                newName: "SchoolClasses");

            migrationBuilder.RenameColumn(
                name: "ClassroomId",
                table: "Students",
                newName: "SchoolClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassroomId",
                table: "Students",
                newName: "IX_Students_SchoolClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_SchoolClasses_SchoolClassId",
                table: "Students",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id");
        }
    }
}
