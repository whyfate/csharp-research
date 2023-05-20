using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkCoreDemo.Migrations
{
    public partial class AlterChangeTypeAndRelationship2String : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_NumberProviders_ProviderId",
                table: "Numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberProviders",
                table: "NumberProviders");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderId",
                table: "Numbers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "NumberProviders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberProvider_To_String",
                table: "NumberProviders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_NumberProviders_ProviderId",
                table: "Numbers",
                column: "ProviderId",
                principalTable: "NumberProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_NumberProviders_ProviderId",
                table: "Numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NumberProvider_To_String",
                table: "NumberProviders");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProviderId",
                table: "Numbers",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "NumberProviders",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumberProviders",
                table: "NumberProviders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_NumberProviders_ProviderId",
                table: "Numbers",
                column: "ProviderId",
                principalTable: "NumberProviders",
                principalColumn: "Id");
        }
    }
}
