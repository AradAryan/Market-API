using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    //Done
    //TODO Category = Name , CategoryId
    //TODO CategoryOption = Name , CategoryOptionId , CategoryId
    //TODO CategoryOptionValue = CategoryOptionValueId , Name , CategoryoptionId , ProductValueId
    public class Category : BaseModel
    {
        public string? Name { get; set; }
    }
}
