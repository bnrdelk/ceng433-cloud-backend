﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cloudBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewFieldCommentToBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Books");
        }
    }
}
