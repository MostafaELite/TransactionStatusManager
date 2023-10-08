using Microsoft.EntityFrameworkCore;

namespace Presenstance
{
    public class TransactionInfoRepo
    {
        private readonly TransasctionInfoContext db;

        public TransactionInfoRepo(TransasctionInfoContext db) => this.db = db;

        public async Task<IEnumerable<TransactionInfo>> GetRequestsToBeSent()
        {
            var jobs = db.TransactionInfo.Where(transaction => transaction.NexSendOn <= DateTime.Now || transaction.NexSendOn == null);
            return await jobs.ToArrayAsync();
        }
    }
}