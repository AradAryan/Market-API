namespace Market.Application
{
    public class ProductPriceDto : BaseDto
    {
        public string? Description { get; set; }
        public Guid ProductOptionValueId { get; set; }
        public Guid PriceId { get; set; }
    }
}
