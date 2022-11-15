namespace Market.Application
{
    public class ProductOptionValueDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid OptionId { get; set; }
        public Guid ProductOptionId { get; set; }
    }
}
