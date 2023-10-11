using Microsoft.EntityFrameworkCore;

namespace Presenstance
{
    public class TransactionInfoRepo
    {
        private readonly TransasctionInfoContext db;

        public TransactionInfoRepo(TransasctionInfoContext db) => this.db = db;

        public async Task<IEnumerable<TransactionInfo>> GetRequestsToBeSent()
        {
            var jobs = db.TransactionInfo.Where(transaction => transaction.NextSendOn <= DateTime.Now || transaction.NextSendOn == null);
            return await jobs.ToArrayAsync();
        }

        public async Task UpdateRequests(IEnumerable<TransactionInfo> updatedRequests)
        {
            if (!updatedRequests.Any())
                return;

            db.UpdateRange(updatedRequests);
            await db.SaveChangesAsync();
        }
    }
}