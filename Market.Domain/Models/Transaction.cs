using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class Transaction : BaseModel
    {
        public Guid TransactionId { get; set; }
        public DateTime CreateDate { get; set; }
        public Transactiontype Type { get; set; }

        public enum Transactiontype
        {
            None = 0,
        }
    }
}
