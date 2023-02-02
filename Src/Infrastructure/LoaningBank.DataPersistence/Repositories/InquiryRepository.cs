using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.Enums;
using LoaningBank.DataPersistence.Utils;
using LoaningBank.Domain.Entities;
using LoaningBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoaningBank.DataPersistence.Repositories
{
    internal sealed class InquiryRepository : IInquiryRepository
    {
        private readonly RepositoryDbContext _dbContext;
        private readonly Lazy<Dictionary<string, OfferStatus>> _offerStatusesLazy;
        private Dictionary<string, OfferStatus> OfferStatuses => _offerStatusesLazy.Value;

        public InquiryRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
            _offerStatusesLazy = new(() =>
                Enum.GetValues<OfferStatus>()
                    .Select(x => new { Enum = x, Description = x.GetEnumDescription().ToLower() })
                    .ToDictionary(x => x.Description, y => y.Enum)
            );
        }

        public async Task<Inquiry> Add(Inquiry inquiry)
        {
            var result = await _dbContext.Inquiries.AddAsync(inquiry);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Inquiry> GetById(Guid id) => await _dbContext.Inquiries.SingleAsync(x => x.ID == id);

        public async Task<PaginatedResponse<InquirySearch>> Get<TResult>(int pageIndex, int pageSize, SortOrder sortOrder, string sortHeader, string filter)
        {
            var offersToFilter = OfferStatuses.Where(x => x.Key.Contains(filter)).Select(x => x.Value).ToList();
            var query = _dbContext.InquirySearch
                .Where(x =>
                    string.IsNullOrWhiteSpace(filter) ||
                    x.NumberOfInstallments.ToString().Contains(filter) ||
                    (x.Percentage != null && x.Percentage.ToString()!.Contains(filter)) ||
                    (x.OfferCreateDate != null && x.OfferCreateDate.ToString()!.Contains(filter)) ||
                    (x.OfferUpdateDate != null && x.OfferUpdateDate.ToString()!.Contains(filter)) ||
                    (x.ApprovedBy != null && x.ApprovedBy.ToLower().Contains(filter)) ||
                    (offersToFilter.Any() && ((x.Status != null && offersToFilter.Contains((OfferStatus)x.Status)) || (x.Status == null && offersToFilter.Contains(OfferStatus.Unknown)))));

            if (sortOrder is not SortOrder.Undefined)
            {
                query = query.Sort<TResult, InquirySearch>(sortOrder, sortHeader);
            }

            return await query.Paginate(pageIndex, pageSize);
        }
    }
}
