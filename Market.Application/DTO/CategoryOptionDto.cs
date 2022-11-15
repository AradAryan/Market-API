namespace Market.Application
{
    public class CategoryOptionDto : BaseDto
    {
        public string? Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CategoryOptionId { get; set; }
    }
}
