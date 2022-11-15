namespace Market.Application
{
    //Done
    //TODO Category = Name , CategoryId
    //TODO CategoryOption = Name , CategoryOptionId , CategoryId
    //TODO CategoryOptionValue = CategoryOptionValueId , Name , CategoryoptionId , ProductValueId
    public class CategoryDto : BaseDto
    {
        public string? Name { get; set; }
    }
}
