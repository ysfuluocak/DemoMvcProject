﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMvcProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IdDeletedForUserOperationClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserOperationClaims");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserOperationClaims",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
