using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCoreDemo.Migrations
{
    public partial class ChangeKeyTypeGuid2String : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GuidToStringEntities",
                table: "GuidToStringEntities");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "GuidToStringEntities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "NewId",
                table: "GuidToStringEntities",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "NewId",
                table: "GuidToStringEntities");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GuidToStringEntities",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GuidToStringEntities",
                table: "GuidToStringEntities",
                column: "Id");
        }
    }
}
