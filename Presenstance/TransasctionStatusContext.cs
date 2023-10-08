using Microsoft.EntityFrameworkCore;

namespace Presenstance
{
    public class TransasctionStatusContext : DbContext
    {
        public DbSet<TrasnactionRequest> Transactions { get; set; }
    }
}
