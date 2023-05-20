using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCoreDemo.Migrations
{
    public partial class ModifyRelationshipFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_NumberProviders_ProviderId",
                table: "Numbers");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_NumberProviders_ProviderId",
                table: "Numbers",
                column: "ProviderId",
                principalTable: "NumberProviders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_NumberProviders_ProviderId",
                table: "Numbers");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_NumberProviders_ProviderId",
                table: "Numbers",
                column: "ProviderId",
                principalTable: "NumberProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
