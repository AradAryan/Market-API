namespace Market.Application
{
    public class InvoiceDto : BaseDto
    {
        public Guid ProductPriceId { get; set; }
        public Guid AccountId { get; set; }
        public Guid ShopId { get; set; }
    }
}
