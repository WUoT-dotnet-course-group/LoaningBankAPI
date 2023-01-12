using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoaningBank.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterOfferDocumentLinkColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentLink",
                table: "Offers");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentKey",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newid()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentKey",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "DocumentLink",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
