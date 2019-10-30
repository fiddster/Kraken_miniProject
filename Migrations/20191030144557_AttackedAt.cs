using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kraken_WeaponSystem.Migrations
{
    public partial class AttackedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AttackedAt",
                table: "Target",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttackedAt",
                table: "Target");
        }
    }
}
