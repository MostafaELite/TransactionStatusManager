using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Presenstance
{
    public class TransasctionInfoContext : DbContext
    {
        public TransasctionInfoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TransactionInfo> TransactionInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            var testData = new[]
            {
                new TransactionInfo { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Payload ="Test Payload"},
                new TransactionInfo { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Payload ="Test Payload"},
                new TransactionInfo { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Payload ="Test Payload"},
                new TransactionInfo { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Payload ="Test Payload"},
                new TransactionInfo { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Payload ="Test Payload"},
                new TransactionInfo { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Payload ="Test Payload"},
                new TransactionInfo { Id = Guid.NewGuid(), CreatedOn = DateTime.Now, Payload ="Test Payload"}
            };

            modelBuilder.Entity<TransactionInfo>()
                .HasData(testData);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
        }


    }
}
