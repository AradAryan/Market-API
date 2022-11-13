using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class ShopProductOptionValue : BaseModel
    {
        public Guid ProductId { get; set; }
        public Guid OptionValueId { get; set; }
        public Guid ShopId { get; set; }
    }
}
