namespace Market.Application
{
    public class ProductOptionDto : BaseDto
    {
        public string? Name { get; set; }
        public Guid OptionId { get; set; }
    }
}
