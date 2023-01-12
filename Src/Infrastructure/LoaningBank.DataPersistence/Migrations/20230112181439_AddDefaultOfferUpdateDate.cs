using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoaningBank.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultOfferUpdateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Offers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}
