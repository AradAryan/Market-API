using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class ProductPrice : BaseModel
    {
        public string? Description { get; set; }
        public Guid ProductOptionValueId { get; set; }
        public Guid PriceId { get; set; }
    }
}
