using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    public class Address : BaseModel
    {
        public string? Name { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Detail { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public int CityProvienceZoneId { get; set; }

    }
}
