using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class CategoryOptionValue : BaseModel
    {
        public string? Name { get; set; }
        public Guid CategoryOptionId { get; set; }
        public Guid ProductValueId { get; set; }
    }
}
