using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdealSysApp.Migrations
{
    public partial class ProductPropertyAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicProperties_Products_ProductId",
                table: "DynamicProperties");

            migrationBuilder.DropIndex(
                name: "IX_DynamicProperties_ProductId",
                table: "DynamicProperties");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DynamicProperties");

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DynamicPropertyId = table.Column<long>(nullable: false),
                    DynamicPropertyValueId = table.Column<long>(nullable: true),
                    IdentityId = table.Column<string>(nullable: true),
                    IntegrationKey = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProperties_DynamicProperties_DynamicPropertyId",
                        column: x => x.DynamicPropertyId,
                        principalTable: "DynamicProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProperties_DynamicPropertyValues_DynamicPropertyValueId",
                        column: x => x.DynamicPropertyValueId,
                        principalTable: "DynamicPropertyValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductProperties_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductProperties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_DynamicPropertyId",
                table: "ProductProperties",
                column: "DynamicPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_DynamicPropertyValueId",
                table: "ProductProperties",
                column: "DynamicPropertyValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_IdentityId",
                table: "ProductProperties",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ProductId",
                table: "ProductProperties",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "DynamicProperties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DynamicProperties_ProductId",
                table: "DynamicProperties",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicProperties_Products_ProductId",
                table: "DynamicProperties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
