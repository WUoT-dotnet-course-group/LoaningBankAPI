using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoaningBank.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoanValue = table.Column<int>(type: "int", nullable: false),
                    NumberOfInstallments = table.Column<short>(type: "smallint", nullable: false),
                    InquireDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DebtorFirstName = table.Column<string>(name: "Debtor_FirstName", type: "nvarchar(max)", nullable: false),
                    DebtorLastName = table.Column<string>(name: "Debtor_LastName", type: "nvarchar(max)", nullable: false),
                    DebtorBirthDate = table.Column<DateTime>(name: "Debtor_BirthDate", type: "datetime2", nullable: false),
                    DebtorGovernmentId = table.Column<string>(name: "Debtor_GovernmentId", type: "nvarchar(max)", nullable: false),
                    DebtorGovernmentIdType = table.Column<int>(name: "Debtor_GovernmentIdType", type: "int", nullable: false),
                    DebtorJobType = table.Column<int>(name: "Debtor_JobType", type: "int", nullable: false),
                    DebtorJobStartDate = table.Column<DateTime>(name: "Debtor_JobStartDate", type: "datetime2", nullable: false),
                    DebtorJobEndDate = table.Column<DateTime>(name: "Debtor_JobEndDate", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InquiryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Offers_Inquiries_InquiryID",
                        column: x => x.InquiryID,
                        principalTable: "Inquiries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_InquiryID",
                table: "Offers",
                column: "InquiryID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Inquiries");
        }
    }
}
