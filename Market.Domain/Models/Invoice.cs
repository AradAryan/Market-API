using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class Invoice : BaseModel
    {
        public Guid ProductPriceId { get; set; }
        public Guid AccountId { get; set; }
        public Guid ShopId { get; set; }
    }
}
