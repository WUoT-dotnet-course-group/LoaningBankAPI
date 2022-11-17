using LoaningBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoaningBank.DataPersistence
{
    public sealed class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inquiry>()
                .OwnsOne(
                x => x.PersonalData,
                pd =>
                {
                    pd.Property(y => y.FirstName).HasColumnName("DebtorFirstName");
                    pd.Property(y => y.LastName).HasColumnName("DebtorLastName");
                    pd.Property(y => y.GovernmentId).HasColumnName("DebtorGovernmentId");
                    pd.Property(y => y.GovernmentIdType).HasColumnName("DebtorGovernmentIdType");
                });
        }
    }
}
