using Microsoft.EntityFrameworkCore;

namespace Presenstance
{
    public class TransasctionInfoContext : DbContext
    {
        public TransasctionInfoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TransactionInfo> TransactionInfo { get; set; }
    }
}
