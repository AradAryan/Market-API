namespace Market.Application
{
    public class ShopProductOptionValueDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public Guid OptionValueId { get; set; }
        public Guid ShopId { get; set; }
    }
}
