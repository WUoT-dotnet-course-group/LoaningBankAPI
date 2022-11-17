using Microsoft.EntityFrameworkCore;

namespace LoaningBank.DataPersistence
{
    public sealed class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        {
        }
    }
}
