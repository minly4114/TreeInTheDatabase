using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TreeInTheDatabase.Migrations
{
    public partial class AddChangesNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Parameters",
                table: "Nodes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeNode",
                table: "Nodes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ChangesNodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NodeId = table.Column<int>(nullable: true),
                    DateChanges = table.Column<DateTime>(nullable: false),
                    Parameters = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangesNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangesNodes_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangesNodes_NodeId",
                table: "ChangesNodes",
                column: "NodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangesNodes");

            migrationBuilder.DropColumn(
                name: "Parameters",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "TypeNode",
                table: "Nodes");
        }
    }
}
