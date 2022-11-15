using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    //Done
    //TODO Brands have name , description , id 
    public class Brand : BaseModel
    {
        public string? Name { get; set; }
        public string? description { get; set; }
    }
}
