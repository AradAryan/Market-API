using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class CategoryOption : BaseModel
    {
        public string? Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CategoryOptionId { get; set; }
    }
}
