using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCoreDemo.Migrations
{
    public partial class AddCascadeTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "children",
                columns: table => new
                {
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_children", x => new { x.ParentId, x.Id });
                    table.ForeignKey(
                        name: "FK_children_parent_ParentId",
                        column: x => x.ParentId,
                        principalTable: "parent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grand",
                columns: table => new
                {
                    ChildParentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grand", x => new { x.ChildParentId, x.ChildId, x.Id });
                    table.ForeignKey(
                        name: "FK_grand_children_ChildParentId_ChildId",
                        columns: x => new { x.ChildParentId, x.ChildId },
                        principalTable: "children",
                        principalColumns: new[] { "ParentId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grand");

            migrationBuilder.DropTable(
                name: "children");

            migrationBuilder.DropTable(
                name: "parent");
        }
    }
}
