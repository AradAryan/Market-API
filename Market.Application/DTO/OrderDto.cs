namespace Market.Application
{
    public class OrderDto : BaseDto
    {
        public Guid InvoiceId { get; set; }
        public Guid ProductPriceId { get; set; }
    }
}
