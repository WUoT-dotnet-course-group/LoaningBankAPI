using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoaningBank.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingOfferFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "DocumentLink",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DocumentLinkValidDate",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<short>(
                name: "LoanPeriod",
                table: "Offers",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "LoanValue",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "MonthlyInstallment",
                table: "Offers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Percentage",
                table: "Offers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Offers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DocumentLink",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DocumentLinkValidDate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "LoanPeriod",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "LoanValue",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "MonthlyInstallment",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Offers");
        }
    }
}
