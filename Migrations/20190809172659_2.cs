﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginReg.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLearned",
                table: "Cards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLearned",
                table: "Cards");
        }
    }
}
