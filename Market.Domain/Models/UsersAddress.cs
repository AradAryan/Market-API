using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class UsersAddress : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
    }
}
