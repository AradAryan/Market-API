namespace Market.Domain.Models
{
    public class ResponseModel
    {
        public bool Succeed { get; set; }
        public object? Data { get; set; }
        public string? Message { get; set; }
    }
}
