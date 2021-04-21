using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseList_Demo.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeegreeLists",
                columns: table => new
                {
                    DeegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeegreeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeegreeLists", x => x.DeegreeId);
                });

            migrationBuilder.CreateTable(
                name: "CourseLists",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeegreeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLists", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_CourseLists_DeegreeLists_DeegreeId",
                        column: x => x.DeegreeId,
                        principalTable: "DeegreeLists",
                        principalColumn: "DeegreeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseLists_DeegreeId",
                table: "CourseLists",
                column: "DeegreeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseLists");

            migrationBuilder.DropTable(
                name: "DeegreeLists");
        }
    }
}
