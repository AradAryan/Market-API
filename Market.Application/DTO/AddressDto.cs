namespace Market.Application
{
    public class AddressDto : BaseDto
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
