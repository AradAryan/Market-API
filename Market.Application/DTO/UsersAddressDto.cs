namespace Market.Application
{
    public class UsersAddressDto : BaseDto
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
    }
}
