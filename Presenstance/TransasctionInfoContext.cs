using Microsoft.EntityFrameworkCore;

namespace Presenstance
{
    public class TransasctionInfoContext : DbContext
    {
        public DbSet<TransactionInfo> TransactionInfo { get; set; }
    }
}
