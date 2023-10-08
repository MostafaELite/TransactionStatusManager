namespace Presenstance
{
    public class TransactionInfo
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime NumberOfRetries { get; set; }

        public DateTime LastRetryOn { get; set; }

        public string? LastResponseMessage { get; set; }

        public DateTime? NexSendOn { get; set; }

        public required string Payload { get; set; }
    }
}
