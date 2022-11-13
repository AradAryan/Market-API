using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class Price : BaseModel
    {
        public double Amount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
