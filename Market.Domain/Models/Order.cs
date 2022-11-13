using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class Order : BaseModel
    {
        public Guid InvoiceId { get; set; }
        public Guid ProductPriceId { get; set; }
    }
}
