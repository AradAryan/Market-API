using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class Payment : BaseModel
    {
        public Guid InvoiceId { get; set; }
    }
}
