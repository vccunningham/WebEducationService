using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEducationService.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrolled",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolled", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrolled_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolled_Students2_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrolled_ClassId",
                table: "Enrolled",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolled_StudentId",
                table: "Enrolled",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrolled");
        }
    }
}
