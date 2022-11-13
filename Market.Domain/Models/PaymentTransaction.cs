using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class PaymentTransaction : BaseModel
    {
        public Guid PaymentId { get; set; }
        public Guid TransactionId { get; set; }

    }
}
