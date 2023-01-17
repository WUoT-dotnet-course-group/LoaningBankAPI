using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoaningBank.DataPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddInquirySearchView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "CREATE VIEW InquirySearch as " +
                    "SELECT i.ID as InquiryID, o.ID as OfferID, i.LoanValue, i.NumberOfInstallments, i.InquireDate, o.Status, o.Percentage, o.CreateDate as OfferCreateDate, o.UpdateDate as OfferUpdateDate, o.ApprovedBy " +
                    "FROM Inquiries i LEFT JOIN Offers o ON o.InquiryID = i.ID;"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DROP VIEW InquirySearch;"
            );
        }
    }
}
