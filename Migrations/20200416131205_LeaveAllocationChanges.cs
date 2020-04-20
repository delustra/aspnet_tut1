using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace aspnet_tut1.Migrations
{
    public partial class LeaveAllocationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveTypeViewModel");

            migrationBuilder.AddColumn<int>(
                name: "DefaultDays",
                table: "LeaveAllocations",
                nullable: false,
                defaultValue: 0);

     
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailedLeaveTypeViewModel");

            migrationBuilder.DropColumn(
                name: "DefaultDays",
                table: "LeaveAllocations");

            migrationBuilder.CreateTable(
                name: "LeaveTypeViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypeViewModel", x => x.Id);
                });
        }
    }
}
