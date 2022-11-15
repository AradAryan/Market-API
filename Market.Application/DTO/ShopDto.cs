namespace Market.Application
{
    //Done with Conflicts
    //TODO Shop = Id guid , Name , Createdate, ExpireDate 
    //TODO Shop , Account , Reseller Inherit from Users
    //TODO UsersAddress = UserId , AddressId
    //TODO Address = Id , latitude, longitude , detail , CityProvienceZoneId
    public class ShopDto : BaseDto
    {
        public string? Name { get; set; }
        public DateTime ExpireDate { get; set; }
        public Guid Account { get; set; }
    }
}
