namespace Market.Application
{
    public class PriceDto : BaseDto
    {
        public double Amount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
