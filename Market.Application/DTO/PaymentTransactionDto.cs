namespace Market.Application
{
    public class PaymentTransactionDto : BaseDto
    {
        public Guid PaymentId { get; set; }
        public Guid TransactionId { get; set; }

    }
}
