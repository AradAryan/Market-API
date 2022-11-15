namespace Market.Application
{
    public class CategoryOptionValueDto : BaseDto
    {
        public string? Name { get; set; }
        public Guid CategoryOptionId { get; set; }
        public Guid ProductValueId { get; set; }
    }
}
