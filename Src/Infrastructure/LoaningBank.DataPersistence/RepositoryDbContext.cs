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
                    pd.Property(y => y.FirstName).HasColumnName("Debtor_FirstName");
                    pd.Property(y => y.LastName).HasColumnName("Debtor_LastName");
                    pd.Property(y => y.BirthDate).HasColumnName("Debtor_BirthDate");
                    pd.Property(y => y.GovernmentId).HasColumnName("Debtor_GovernmentId");
                    pd.Property(y => y.GovernmentIdType).HasColumnName("Debtor_GovernmentIdType");
                    pd.Property(y => y.JobType).HasColumnName("Debtor_JobType");
                    pd.Property(y => y.JobStartDate).HasColumnName("Debtor_JobStartDate");
                    pd.Property(y => y.JobEndDate).HasColumnName("Debtor_JobEndDate");
                });

            modelBuilder.Entity<Inquiry>()
                .Property(x => x.InquireDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Offer>()
                .Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Offer>()
                .Property(x => x.UpdateDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Offer>()
                .Property(x => x.DocumentKey)
                .HasDefaultValueSql("newid()");
        }
    }
}
