using Microsoft.EntityFrameworkCore;

namespace Presenstance
{
    public class TransasctionStatusContext : DbContext
    {
        public DbSet<TransactionInfo> Transactions { get; set; }
    }
}
