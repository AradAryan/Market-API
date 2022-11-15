using Market.Domain.Models.Base;

namespace Market.Domain.Models
{
    //Done
    //TODO Product =Id , BrandId ,Name , Description => linked to CategoryOptionValue
    //TODO OptionForProduct = OptionId , Name ... like Size , Class , Length , ....
    //TODO OptionValueForProduct = OptionValueId, OptionId , Name ... like (Size = Xl , M , L , ...) , (Class = Private , Public , ...)
    //TODO ProductOptionValueForShop = ProductOptionValueId, ProductId , OptionValueId , ShopId 
    //TODO ProductPrice = ProductPriceId, ProductOptionValueId , PriceId
    //TODO Price = id GUid , createdate , expireDate , Price

    public class Product : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid BrandId { get; set; }
    }
}
