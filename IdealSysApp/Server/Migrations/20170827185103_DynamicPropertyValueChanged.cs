using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdealSysApp.Migrations
{
    public partial class DynamicPropertyValueChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DynamicPropertyValues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "DynamicPropertyValues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntegrationKey",
                table: "DynamicPropertyValues",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "DynamicPropertyValues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_DynamicPropertyValues_IdentityId",
                table: "DynamicPropertyValues",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicPropertyValues_AspNetUsers_IdentityId",
                table: "DynamicPropertyValues",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicPropertyValues_AspNetUsers_IdentityId",
                table: "DynamicPropertyValues");

            migrationBuilder.DropIndex(
                name: "IX_DynamicPropertyValues_IdentityId",
                table: "DynamicPropertyValues");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DynamicPropertyValues");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "DynamicPropertyValues");

            migrationBuilder.DropColumn(
                name: "IntegrationKey",
                table: "DynamicPropertyValues");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "DynamicPropertyValues");
        }
    }
}
