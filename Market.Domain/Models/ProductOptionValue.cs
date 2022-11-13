using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class ProductOptionValue : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid OptionId { get; set; }
        public Guid ProductOptionId { get; set; }
    }
}
