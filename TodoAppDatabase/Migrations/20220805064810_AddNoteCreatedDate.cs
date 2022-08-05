using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoAppDatabase.Migrations
{
    public partial class AddNoteCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Notes");
        }
    }
}
