﻿using LoaningBank.Domain.Entities;
using LoaningBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoaningBank.DataPersistence.Repositories
{
    internal class OfferRepository : IOfferRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public OfferRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(Offer offer)
        {
            await _dbContext.Offers.AddAsync(offer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Offer> GetById(Guid id) => await _dbContext.Offers.SingleAsync(x => x.ID == id);
    }
}
