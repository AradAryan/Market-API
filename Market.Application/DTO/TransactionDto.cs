namespace Market.Application
{
    public class TransactionDto : BaseDto
    {
        public Guid TransactionId { get; set; }
        public DateTime CreateDate { get; set; }
        public Transactiontype Type { get; set; }

        public enum Transactiontype
        {
            None = 0,
        }
    }
}
